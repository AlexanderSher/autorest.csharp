// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Request = Azure.Core.Request;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LongRunningOperationWriter
    {
        public void Write(CodeWriter writer, LongRunningOperation operation)
        {
            var pagingResponse = operation.PagingResponse;

            var operationType = operation.Type;
            var createResultAsyncSignature = GetCreateResultAsyncSignature(operation);

            using (writer.Namespace(operationType.Namespace))
            {
                writer.WriteXmlDocumentationSummary($"{operation.Description}");
                var baseType = GetBaseType(operation);
                var helperType = GetHelperType(operation);

                writer.Append($"{operation.Declaration.Accessibility} partial class {operationType.Name}: {baseType}");

                using (writer.Scope())
                {
                    WriteFields(writer, pagingResponse, helperType);

                    writer.Line();
                    writer.WriteXmlDocumentationSummary($"Initializes a new instance of {operationType.Name} for mocking.");
                    using (writer.Scope($"protected {operationType.Name:D}()"))
                    {
                    }

                    writer.Line();

                    WriteConstructor(writer, operation, pagingResponse, operationType, helperType, createResultAsyncSignature);
                    writer.Line();

                    writer
                        .WriteXmlDocumentationInheritDoc()
                        .Line($"#pragma warning disable CA1822")
                        .Line($"public override string Id => throw new NotImplementedException();")
                        .Line($"#pragma warning restore CA1822")
                        .Line();

                    WriteValueProperty(writer, operation);

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override bool HasCompleted => _operation.HasCompleted;");
                    writer.Line();

                    if (operation.ResultType != null)
                    {
                        writer.WriteXmlDocumentationInheritDoc();
                        writer.Line($"public override bool HasValue => _operation.HasValue;");
                        writer.Line();
                    }

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} GetRawResponse() => _operation.RawResponse;");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(Response)} UpdateStatus({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatus(cancellationToken);");
                    writer.Line();

                    writer.WriteXmlDocumentationInheritDoc();
                    writer.Line($"public override {typeof(ValueTask<Response>)} UpdateStatusAsync({typeof(CancellationToken)} cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);");
                    writer.Line();

                    WriteWaitForCompletionVariants(writer, operation);
                    writer.Line();

                    if (operation.ResultType != null && operation.ResultSerialization != null && createResultAsyncSignature != null)
                    {
                        if (pagingResponse != null)
                        {
                            WriteCreateResultAsync(writer, createResultAsyncSignature, operation.Diagnostics.ScopeName);
                            writer.Line();
                            WriteCreateEnumerableAsync(writer, operation.ResultSerialization, pagingResponse);
                        }
                        else
                        {
                            WriteCreateResultAsync(writer, operation.ResultSerialization, createResultAsyncSignature, operation.ResultType);
                        }
                    }
                }
            }
        }

        private static CSharpType GetBaseType(LongRunningOperation operation) => operation.ResultType != null ? new CSharpType(typeof(Operation<>), operation.ResultType) : new CSharpType(typeof(Operation));

        private static CSharpType GetValueTaskType(LongRunningOperation operation) => operation.ResultType != null ? new CSharpType(typeof(Response<>), operation.ResultType) : new CSharpType(typeof(Response));

        private static CSharpType GetHelperType(LongRunningOperation operation) => operation.ResultType != null ? new CSharpType(typeof(OperationInternal<>), operation.ResultType) : new CSharpType(typeof(OperationInternal));

        private static MethodSignature? GetCreateResultAsyncSignature(LongRunningOperation operation)
        {
            if (operation.ResultType == null)
            {
                return null;
            }

            var parameters = new[]
            {
                new Parameter("async", null, typeof(bool), null, ValidationType.None, null),
                new Parameter("response", null, typeof(Response), null, ValidationType.None, null),
                new Parameter("cancellationToken", null, typeof(CancellationToken), null, ValidationType.None, null),
            };

            var modifiers = operation.PagingResponse != null ? Private : Private | Async;
            return new MethodSignature("CreateResultAsync", null, modifiers, new CSharpType(typeof(ValueTask<>), operation.ResultType), null, parameters);
        }

        private static MethodSignature GetCreateEnumerableAsyncSignature(CSharpType returnType)
        {
            var parameters = new[]
            {
                new Parameter("response", null, typeof(Response), null, ValidationType.None, null),
                new Parameter("nextLink", null, typeof(string), null, ValidationType.None, null),
                new Parameter("pageSizeHint", null, typeof(int?), null, ValidationType.None, null),
                new Parameter("cancellationToken", null, typeof(CancellationToken), null, ValidationType.None, null) { Attributes = new[]{ new CSharpAttribute(typeof(EnumeratorCancellationAttribute)) }},
            };

            return new MethodSignature("CreateEnumerableAsync", null, Private | Async, returnType, null, parameters);
        }

        private static void WriteFields(CodeWriter writer, PagingResponseInfo? pagingResponse, CSharpType helperType)
        {
            writer.Line($"private readonly {helperType} _operation;");
            if (pagingResponse != null)
            {
                writer.Line($"private readonly {typeof(ClientDiagnostics)} _clientDiagnostics;");
                writer.Line($"private readonly {typeof(Func<string, CancellationToken, Task<Response>>)} _nextPageFunc;");
            }
        }

        private void WriteConstructor(CodeWriter writer, LongRunningOperation operation, PagingResponseInfo? pagingResponse, CSharpType lroType, CSharpType helperType, MethodSignature? createResultAsyncSignature)
        {
            writer.Append($"internal {lroType.Name}({typeof(ClientDiagnostics)} clientDiagnostics, {typeof(HttpPipeline)} pipeline, {typeof(Request)} request, {typeof(Response)} response");

            if (pagingResponse != null)
            {
                writer.Append($", {typeof(Func<string, CancellationToken, Task<Response>>)} nextPageFunc");
            }
            writer.Line($")");

            var nextLinkOperationVariable = new CodeWriterDeclaration("nextLinkOperation");
            using (writer.Scope())
            {
                var nextLinkOperationType = operation.ResultType != null
                    ? new CSharpType(typeof(IOperation<>), operation.ResultType)
                    : new CSharpType(typeof(IOperation));

                writer.Append($"{nextLinkOperationType} {nextLinkOperationVariable:D} = {typeof(NextLinkOperationImplementation)}.{nameof(NextLinkOperationImplementation.Create)}(");
                if (createResultAsyncSignature != null)
                {
                    writer.Append($"{createResultAsyncSignature.Name}, ");
                }
                writer
                    .Line($"pipeline, request.Method, request.Uri.ToUri(), response, {typeof(OperationFinalStateVia)}.{operation.FinalStateVia});")
                    .Line($"_operation = new {helperType}(clientDiagnostics, nextLinkOperation, response, { operation.Diagnostics.ScopeName:L});");

                if (pagingResponse != null)
                {
                    writer
                        .Line($"_clientDiagnostics = clientDiagnostics;")
                        .Line($"_nextPageFunc = nextPageFunc;");
                }
            }
        }

        protected virtual void WriteValueProperty(CodeWriter writer, LongRunningOperation operation)
        {
            if (operation.ResultType != null)
            {
                writer.WriteXmlDocumentationInheritDoc();
                writer.Line($"public override {operation.ResultType} Value => _operation.Value;");
                writer.Line();
            }
        }

        protected virtual void WriteWaitForCompletionVariants(CodeWriter writer, LongRunningOperation operation)
        {
            var valueTaskType = GetValueTaskType(operation);
            var waitForCompletionMethodName = operation.ResultType != null ? "WaitForCompletion" : "WaitForCompletionResponse";

            WriteWaitForCompletionMethods(writer, valueTaskType, waitForCompletionMethodName, false);
            WriteWaitForCompletionMethods(writer, valueTaskType, waitForCompletionMethodName, true);
        }

        private void WriteWaitForCompletionMethods(CodeWriter writer, CSharpType valueTaskType, string waitForCompletionMethodName, bool async)
        {
            var waitForCompletionType = async ? new CSharpType(typeof(ValueTask<>), valueTaskType) : valueTaskType;

            writer.WriteXmlDocumentationInheritDoc();
            writer.Line($"public override {waitForCompletionType} {waitForCompletionMethodName}{(async ? "Async" : string.Empty)}({typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompletionMethodName}{(async ? "Async" : string.Empty)}(cancellationToken);");
            writer.Line();

            writer.WriteXmlDocumentationInheritDoc();
            writer.Line($"public override {waitForCompletionType} {waitForCompletionMethodName}{(async ? "Async" : string.Empty)}({typeof(TimeSpan)} pollingInterval, {typeof(CancellationToken)} cancellationToken = default) => _operation.{waitForCompletionMethodName}{(async ? "Async" : string.Empty)}(pollingInterval, cancellationToken);");
            writer.Line();
        }

        private static void WriteCreateResultAsync(CodeWriter writer, ObjectSerialization resultSerialization, MethodSignature signature, CSharpType resultType)
        {
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteDeserializationForMethods(resultSerialization, (w, v) => w.Line($"return {v};"), "response", resultType);
            }
        }

        private static void WriteCreateResultAsync(CodeWriter writer, MethodSignature signature, string scopeName)
        {
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.Line($"return new {signature.ReturnType}({typeof(PageableHelpers)}.{nameof(PageableHelpers.CreateAsyncPageable)}(CreateEnumerableAsync, response, _clientDiagnostics, {scopeName:L}));");
            }
        }

        private static void WriteCreateEnumerableAsync(CodeWriter writer, ObjectSerialization resultSerialization, PagingResponseInfo pagingResponse)
        {
            var signature = GetCreateEnumerableAsyncSignature(new CSharpType(typeof(IAsyncEnumerable<>), pagingResponse.PageType));
            using (writer.WriteMethodDeclaration(signature))
            {
                var firstIterationVariable = new CodeWriterDeclaration("firstIteration");
                writer.Line($"bool {firstIterationVariable:D} = true;");
                using (writer.Scope($"while ({firstIterationVariable} || !string.IsNullOrEmpty(nextLink))"))
                {
                    using (writer.Scope($"if ({firstIterationVariable})"))
                    {
                        writer.Line($"{firstIterationVariable} = false;");
                    }
                    using (writer.Scope($"else"))
                    {
                        writer.Line($"response = await _nextPageFunc(nextLink, cancellationToken).ConfigureAwait(false);");
                    }

                    var resultVariable = new CodeWriterDeclaration("result");
                    writer
                        .Line()
                        .WriteDeserializationForMethods(resultSerialization, true, (w, v) => w.Line($"{pagingResponse.ResponseType} {resultVariable:D} = {v};"), "response", pagingResponse.ResponseType);

                    var pageVariable = new CodeWriterDeclaration("page");
                    writer
                        .Line($"{pagingResponse.PageType} {pageVariable:D} = Page.FromValues(result.Values, result.NextLink, response);")
                        .Line($"nextLink = {pageVariable}.ContinuationToken;")
                        .Line($"yield return {pageVariable};");
                }
            }
        }
    }
}
