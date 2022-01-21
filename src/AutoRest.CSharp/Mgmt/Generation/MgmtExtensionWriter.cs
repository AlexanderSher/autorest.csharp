﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtExtensionWriter : MgmtClientBaseWriter
    {
        protected MgmtExtensions _extensions;

        protected virtual string DiagnosticOptionsVariable { get; } = "diagnosticOptions";

        protected bool IsArmCore;
        public MgmtExtensionWriter(CodeWriter writer, MgmtExtensions extensions, BuildContext<MgmtOutputLibrary> context, Type extensionType, bool isArmCore = false) : base(writer, extensions, context)
        {
            _extensions = extensions;
            IsArmCore = isArmCore;
            ExtensionOperationVariableType = extensionType;
        }

        protected abstract string Description { get; }
        protected abstract string ExtensionOperationVariableName { get; }
        protected Type ExtensionOperationVariableType { get; }

        protected override string IdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string BranchIdVariableName => $"{ExtensionOperationVariableName}.Id";

        protected override string ContextProperty => ExtensionOperationVariableName;

        protected void WriteProviderDefaultNamespace(CodeWriter writer)
        {
            writer.Line($"private static string _defaultRpNamespace = {typeof(ClientDiagnostics)}.GetResourceProviderNamespace(typeof({TypeNameOfThis}).Assembly);");
        }

        protected void WriteMethodWrapper(MgmtClientOperation clientOperation, bool async)
        {
            // we need to identify this operation belongs to which category: NormalMethod, NormalListMethod, LROMethod or PagingMethod
            if (clientOperation.IsLongRunningOperation() && !clientOperation.IsPagingOperation(Context))
            {
                // this is a non-pageable long-running operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType!, async, false, true);
            }
            else if (clientOperation.IsLongRunningOperation() && clientOperation.IsPagingOperation(Context))
            {
                // this is a pageable long-running operation
                throw new NotImplementedException($"Pageable LRO is not implemented yet, please use `remove-operation` directive to remove the following operationIds: {string.Join(", ", clientOperation.Select(o => o.OperationId))}");
            }
            else if (clientOperation.IsPagingOperation(Context))
            {
                // this is a paging operation
                var itemType = clientOperation.First(restOperation => restOperation.IsPagingOperation(Context)).GetPagingMethod(Context)!.PagingResponse.ItemType;
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, GetActualItemType(clientOperation, itemType), async, true, false);
            }
            else if (clientOperation.IsListOperation(Context, out var itemType))
            {
                // this is a normal list operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, GetActualItemType(clientOperation, itemType), async, true, false);
            }
            else
            {
                // this is a normal operation
                WriteMethodWrapperImpl(clientOperation, clientOperation.Name, clientOperation.ReturnType!, async, false, false);
            }
        }

        private void WriteMethodSignatureWrapper(CSharpType actualItemType, string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging, bool isLro)
        {
            _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            if (isLro)
                _writer.WriteXmlDocumentationParameter("waitForCompletion", $"Waits for the completion of the long running operations.");

            foreach (var parameter in methodParameters)
            {
                _writer.WriteXmlDocumentationParameter(parameter);
            }
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationMgmtRequiredParametersException(methodParameters);
            if (isPaging)
                _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = isPaging ? actualItemType.WrapPageable(isAsync) : actualItemType.WrapAsync(isAsync);
            string asyncText = isPaging ? string.Empty : GetAsyncKeyword(isAsync);
            _writer.Append($"public static {asyncText} {responseType} {CreateMethodName(methodName, isAsync)}(this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ");

            if (isLro)
                _writer.Append($"bool waitForCompletion, ");
            foreach (var parameter in methodParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");
        }

        private CSharpType GetActualItemType(MgmtClientOperation clientOperation, CSharpType itemType)
        {
            var wrapResource = WrapResourceDataType(itemType, clientOperation.First());
            CSharpType actualItemType = wrapResource?.Type ?? itemType;
            return actualItemType;
        }

        protected void WriteExtensionClientGet()
        {
            _writer.Line();
            using (_writer.Scope($"private static {ExtensionOperationVariableType.Name}ExtensionClient GetExtensionClient({ExtensionOperationVariableType} {ExtensionOperationVariableName})"))
            {
                using (_writer.Scope($"return {ExtensionOperationVariableName}.GetCachedClient(({ArmClientReference}) =>"))
                {
                    _writer.Line($"return new {ExtensionOperationVariableType.Name}ExtensionClient({ArmClientReference}, {ExtensionOperationVariableName}.Id);");
                }
                _writer.Line($");");
            }
        }

        private void WriteMethodWrapperImpl(
            MgmtClientOperation clientOperation,
            string methodName,
            CSharpType itemType,
            bool async,
            bool isPaging,
            bool isLro)
        {
            _writer.Line();
            // write the extra information about the request path, operation id, etc
            if (ShowRequestPathAndOperationId)
                WriteRequestPathAndOperationId(clientOperation);
            BuildParameters(clientOperation, out var operationMappings, out var parameterMappings, out var methodParameters);
            WriteMethodSignatureWrapper(itemType, methodName, methodParameters, async, isPaging, isLro);
            using (_writer.Scope())
            {
                WriteMethodBodyWrapper(methodName, methodParameters, async, isPaging, isLro);
            }
        }

        private void WriteMethodBodyWrapper(string methodName, IReadOnlyList<Parameter> methodParameters, bool isAsync, bool isPaging, bool isLro)
        {
            string asyncText = isAsync ? "Async" : string.Empty;
            string configureAwait = isAsync & !isPaging ? ".ConfigureAwait(false)" : string.Empty;
            string awaitText = isAsync & !isPaging ? " await" : string.Empty;
            _writer.Append($"return{awaitText} GetExtensionClient({ExtensionOperationVariableName}).{methodName}{asyncText}(");
            bool isFirst = true;
            if (isLro)
            {
                _writer.Append($"waitForCompletion");
                isFirst = false;
            }
            foreach (var parameter in methodParameters)
            {
                if (!isFirst)
                {
                    _writer.Append($", ");
                }
                _writer.Append($"{parameter.Name}");
                isFirst = false;
            }
            if (!isFirst)
                _writer.Append($", ");
            _writer.Line($"cancellationToken){configureAwait};");
        }

        protected void WriteGetRestOperations(MgmtRestClient restClient)
        {
            _writer.Line();
            _writer.Append($"private static {restClient.Type} Get{restClient.Type.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, string applicationId, ");
            // TODO: Use https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783 rest client parameters
            foreach (var parameter in restClient.Parameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Append($")");

            using (_writer.Scope())
            {
                _writer.Append($"return new {restClient.Type}(clientDiagnostics, pipeline, applicationId, ");
                foreach (var parameter in restClient.Parameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
            _writer.Line();
        }

        protected override void WriteResourceCollectionEntry(Resource resource)
        {
            var collection = resource.ResourceCollection;
            if (collection == null)
                throw new InvalidOperationException($"We are about to write a {resource.Type.Name} resource entry, but it does not have a collection, this cannot happen");
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {collection.Type.Name} along with the instance operations that can be performed on it.");
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationParameters(collection.ExtraConstructorParameters);
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{collection.Type}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {ExtensionOperationVariableType} {ExtensionOperationVariableName}, ";
            _writer.Append($"public {modifier} {collection.Type.Name} Get{resource.Type.Name.ResourceNameToPlural()}({instanceParameter}");
            foreach (var parameter in collection.ExtraConstructorParameters)
            {
                _writer.WriteParameter(parameter);
            }
            _writer.RemoveTrailingComma();
            _writer.Line($")");
            using (_writer.Scope())
            {
                _writer.Append($"return new {collection.Type.Name}({ExtensionOperationVariableName}, ");
                foreach (var parameter in collection.ExtraConstructorParameters)
                {
                    _writer.Append($"{parameter.Name}, ");
                }
                _writer.RemoveTrailingComma();
                _writer.Line($");");
            }
        }

        protected override void WriteSingletonResourceEntry(Resource resource, string singletonResourceSuffix)
        {
            _writer.WriteXmlDocumentationSummary($"Gets an object representing a {resource.Type.Name} along with the instance operations that can be performed on it.");
            if (!IsArmCore)
            {
                _writer.WriteXmlDocumentationParameter($"{ExtensionOperationVariableName}", $"The <see cref=\"{ExtensionOperationVariableType}\" /> instance the method will execute against.");
            }
            _writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resource.Type.Name}\" /> object.");
            var modifier = IsArmCore ? "virtual" : "static";
            var instanceParameter = IsArmCore ? string.Empty : $"this {ExtensionOperationVariableType} {ExtensionOperationVariableName}";
            using (_writer.Scope($"public {modifier} {resource.Type.Name} Get{resource.Type.Name}({instanceParameter})"))
            {
                _writer.Line($"return new {resource.Type.Name}({ExtensionOperationVariableName}, new {typeof(Azure.Core.ResourceIdentifier)}({ExtensionOperationVariableName}.Id + \"/{singletonResourceSuffix}\"));");
            }
        }

        protected override void WriteLROMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            // TODO -- find a way to properly get the LRO response type here. Temporarily we are using the first one
            var lroObjectType = clientOperation.ReturnType!; // LRO return type will never be null

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteLROMethodSignature(lroObjectType, methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeNameOfThis}.{methodName}", Array.Empty<DiagnosticAttribute>());

                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticsPropertyName(clientOperation.RestClient)))
                {
                    WriteLROMethodBody(lroObjectType, operationMappings, parameterMappings, async);
                }
                _writer.Line();
            }
        }

        protected override void WriteLROMethodBranch(CSharpType lroObjectType, MgmtRestOperation operation, IEnumerable<ParameterMapping> parameterMapping, bool async)
        {
            _writer.Append($"var response = {GetAwait(async)} ");
            _writer.Append($"{GetRestFieldName(operation.RestClient)}.{CreateMethodName(operation.Method.Name, async)}(");
            WriteArguments(_writer, parameterMapping);
            _writer.Line($"cancellationToken){GetConfigureAwait(async)};");

            WriteLROResponse(lroObjectType, GetClientDiagnosticsPropertyName(operation.RestClient), "Pipeline", operation, parameterMapping, async);
        }

        // this method checks if the giving opertion corresponding to a list of resources. If it does, this resource will need a GetByName method.
        protected bool CheckGetAllAsGenericMethod(MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (clientOperation.First().IsListMethod(out var itemType))
            {
                if (Context.Library.TryGetTypeProvider(itemType.Name, out var provider) && provider is ResourceData data)
                {
                    var resourcesOfResourceData = Context.Library.FindResources(data);
                    // TODO -- what if we have multiple resources corresponds to the same resource data?
                    // We are not able to determine which resource this opertion belongs, since the list in subsrcirption operation does not have any parenting relationship with other operations.
                    // temporarily directly return and doing nothing when this happens
                    if (resourcesOfResourceData.Count() > 1)
                        return false;
                    // only one resource, this needs a GetByName method
                    resource = resourcesOfResourceData.First();
                    return true;
                }
            }

            return false;
        }


        protected static string GetClientDiagnosticsPropertyName(RestClient client)
        {
            return $"{client.OperationGroup.Key}ClientDiagnostics";
        }

        protected override void WritePagingMethodBody(CSharpType itemType, Diagnostic diagnostic, IDictionary<RequestPath, MgmtRestOperation> operationMappings, IDictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, bool async, MgmtClientOperation clientOperation)
        {
            // if we only have one branch, we would not need those if-else statements
            var branch = operationMappings.Keys.First();
            WritePagingMethodBranch(itemType, diagnostic, GetClientDiagnosticsPropertyName(clientOperation.RestClient), operationMappings[branch], parameterMappings[branch], async);
        }

        protected override void WriteNormalMethod(MgmtClientOperation clientOperation, Dictionary<RequestPath, MgmtRestOperation> operationMappings,
            Dictionary<RequestPath, IEnumerable<ParameterMapping>> parameterMappings, IReadOnlyList<Parameter> methodParameters,
            string methodName, bool async, bool shouldThrowExceptionWhenNull = false)
        {
            // TODO -- since we are combining multiple operations under different parents, which description should we leave here?
            var returnType = WrapResourceDataType(clientOperation.ReturnType, clientOperation.First())?.Type ?? clientOperation.ReturnType;

            _writer.WriteXmlDocumentationSummary($"{clientOperation.Description}");
            WriteNormalMethodSignature(GetResponseType(returnType, async), methodName, methodParameters, async, clientOperation.Accessibility, true);

            using (_writer.Scope())
            {
                _writer.WriteParameterNullOrEmptyChecks(methodParameters);

                var diagnostic = new Diagnostic($"{TypeOfThis.Name}.{methodName}", Array.Empty<DiagnosticAttribute>());

                using (WriteDiagnosticScope(_writer, diagnostic, GetClientDiagnosticsPropertyName(clientOperation.RestClient)))
                {
                    WriteNormalMethodBody(operationMappings, parameterMappings, async, shouldThrowExceptionWhenNull: shouldThrowExceptionWhenNull);
                }
                _writer.Line();
            }
        }

        /// <summary>
        /// In the extension class, we need to find the correct resource class that links to this resource data, if this is a resource data
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override Resource? WrapResourceDataType(CSharpType? type, MgmtRestOperation operation)
        {
            if (!IsResourceDataType(type, operation, out var data))
                return null;

            // we need to find the correct resource type that links with this resource data
            var candidates = Context.Library.FindResources(data);

            // return null when there is no match
            if (!candidates.Any())
                return null;

            // when we only find one result, just return it.
            if (candidates.Count() == 1)
                return candidates.Single();

            // if there is more candidates than one, we are going to some more matching to see if we could determine one
            var resourceType = operation.RequestPath.GetResourceType(Config);
            var filteredResources = candidates.Where(resource => resource.ResourceType == resourceType);

            if (filteredResources.Count() == 1)
                return filteredResources.Single();

            return null;
        }

        /// <summary>
        /// In the extension class, we need to check the type is a resource data or not
        /// </summary>
        /// <param name="type"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        protected override bool IsResourceDataType(CSharpType? type, MgmtRestOperation operation, [MaybeNullWhen(false)] out ResourceData data)
        {
            data = null;
            if (type == null || type.IsFrameworkType)
                return false;

            if (Context.Library.TryGetTypeProvider(type.Name, out var provider))
            {
                data = provider as ResourceData;
                return data != null;
            }
            return false;
        }

        protected override ResourceTypeSegment GetBranchResourceType(RequestPath branch)
        {
            // we should never have a branch in the operations in an extension class, therefore throwing an exception here
            throw new InvalidOperationException();
        }

        private class ExtensionContextScope : IDisposable
        {
            private readonly CodeWriter.CodeWriterScope _scope;
            private readonly CodeWriter _writer;
            private readonly bool _async;

            public ExtensionContextScope(CodeWriter.CodeWriterScope scope, CodeWriter writer, bool async)
            {
                _scope = scope;
                _writer = writer;
                _async = async;
            }

            public void Dispose()
            {
                _scope.Dispose();

                _writer.Line($"){GetConfigureAwait(_async)};");
            }
        }
    }
}
