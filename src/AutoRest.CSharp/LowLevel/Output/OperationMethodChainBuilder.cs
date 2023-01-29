﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.ClientMethodLines;
using static AutoRest.CSharp.Output.Models.InlineableExpressions;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using Configuration = AutoRest.CSharp.Input.Configuration;

namespace AutoRest.CSharp.Output.Models
{
    internal class OperationMethodChainBuilder
    {
        private readonly ClientFields _fields;
        private readonly string _clientName;
        private readonly bool _headAsBoolean;
        private readonly RestClientMethod _createMessageMethod;
        private readonly RestClientMethod? _createNextPageMessageMethod;
        private readonly IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> _parameterLinks;
        private readonly RequestConditionHeaders _conditionHeaderFlag;
        private readonly IReadOnlyList<Parameter> _protocolMethodParameters;
        private readonly IReadOnlyList<Parameter> _convenienceMethodParameters;
        private readonly CSharpType? _responseType;
        private readonly CSharpType _protocolMethodReturnType;
        private readonly CSharpType _convenienceMethodReturnType;

        private InputOperation Operation { get; }

        public OperationMethodChainBuilder(InputOperation operation, ClientFields fields, string clientName, TypeFactory typeFactory, RestClientMethod createMessageMethod, RestClientMethod? createNextPageMessageMethod, IReadOnlyList<CreateMessageMethodsBuilder.ParameterLink> parameterLinks, RequestConditionHeaders conditionHeaderFlag)
        {
            _fields = fields;
            _clientName = clientName;

            Operation = operation;
            _headAsBoolean = operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean;
            _createMessageMethod = createMessageMethod;
            _createNextPageMessageMethod = createNextPageMessageMethod;
            _parameterLinks = parameterLinks;
            _protocolMethodParameters = parameterLinks.SelectMany(p => p.ProtocolParameters).ToList();
            _convenienceMethodParameters = parameterLinks.SelectMany(p => p.ConvenienceParameters).ToList();
            _conditionHeaderFlag = conditionHeaderFlag;
            _responseType = _headAsBoolean ? null : GetResponseType(operation, typeFactory);
            _protocolMethodReturnType = _headAsBoolean ? typeof(Response<bool>) : GetProtocolMethodReturnType(operation, _responseType);
            _convenienceMethodReturnType = _responseType is not null ? GetConvenienceMethodReturnType(operation, _responseType) : _protocolMethodReturnType;
        }

        public LowLevelClientMethod BuildOperationMethodChain()
        {
            var protocolMethodSignature = BuildProtocolMethod(false).Signature;
            var methods = ShouldConvenienceMethodGenerated()
                ? new[]{ BuildConvenienceMethod(true), BuildConvenienceMethod(false) }
                : Array.Empty<Method>();

            var diagnostic = new Diagnostic($"{_clientName}.{_createMessageMethod.Name}");

            var requestBodyType = Operation.Parameters.FirstOrDefault(p => p.Location == RequestLocation.Body)?.Type;
            var responseBodyType = Operation.Responses.FirstOrDefault()?.BodyType;
            var protocolMethodPaging = Operation.Paging is { } paging ? new ProtocolMethodPaging(_createNextPageMessageMethod, paging.NextLinkName, paging.ItemName ?? "value") : null;
            return new LowLevelClientMethod(methods, protocolMethodSignature, _createMessageMethod, requestBodyType, responseBodyType, diagnostic, protocolMethodPaging, Operation.LongRunning, _conditionHeaderFlag);
        }

        private bool ShouldConvenienceMethodGenerated()
        {
            if (!Operation.GenerateConvenienceMethod)
            {
                return false;
            }

            // Pageable LRO's aren't supported yet
            if (Operation.Paging != null && Operation.LongRunning != null)
            {
                return false;
            }

            if (_responseType is not null)
            {
                return true;
            }

            return !_convenienceMethodParameters.Where(p => p != KnownParameters.CancellationTokenParameter)
                .SequenceEqual(_protocolMethodParameters.Where(p => p != KnownParameters.RequestContext));
        }
        
        private static CSharpType? GetResponseType(InputOperation operation, TypeFactory typeFactory)
        {
            var firstResponseBodyType = operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().FirstOrDefault();
            var responseType = firstResponseBodyType is not null ? typeFactory.CreateType(firstResponseBodyType) : null;
            if (operation.Paging is not { } paging)
            {
                return responseType;
            }

            if (responseType is null)
            {
                throw new InvalidOperationException($"Method {operation.Name} is pageable and has to have a return value");
            }

            if (responseType.IsFrameworkType || responseType.Implementation is not ModelTypeProvider modelType)
            {
                return TypeFactory.IsList(responseType) ? TypeFactory.GetElementType(responseType) : responseType;
            }

            var property = modelType.GetPropertyBySerializedName(paging.ItemName ?? "value");
            var propertyType = property.ValueType.WithNullable(false);
            if (!TypeFactory.IsList(propertyType))
            {
                throw new InvalidOperationException($"'{modelType.Declaration.Name}.{property.Declaration.Name}' property must be a collection of items");
            }

            return TypeFactory.GetElementType(property.ValueType);
        }

        private static CSharpType GetProtocolMethodReturnType(InputOperation operation, CSharpType? responseType)
            => (operation.Paging, operation.LongRunning, responseType) switch
            {
                { Paging: not null, LongRunning: not null }       => typeof(Operation<Pageable<BinaryData>>),
                { Paging: not null, LongRunning: null }           => typeof(Pageable<BinaryData>),
                { LongRunning: not null, responseType: not null } => typeof(Operation<BinaryData>),
                { LongRunning: not null, responseType: null }     => typeof(Operation),
                _                                                 => typeof(Response)
            };

        private static CSharpType GetConvenienceMethodReturnType(InputOperation operation, CSharpType responseType)
            => (operation.Paging, operation.LongRunning) switch
            {
                { Paging: not null, LongRunning: not null } => new CSharpType(typeof(Operation<>), new CSharpType(typeof(Pageable<>), responseType)),
                { Paging: not null, LongRunning: null }     => new CSharpType(typeof(Pageable<>), responseType),
                { LongRunning: not null }                   => new CSharpType(typeof(Operation<>), responseType),
                _                                           => new CSharpType(typeof(Response<>), responseType)
            };

        private Method BuildProtocolMethod(bool async)
        {
            var methodName = _createMessageMethod.Name;
            var signature = CreateProtocolMethodSignature(methodName, async);
            var body = new MethodBody(Array.Empty<MethodBodyBlock>());
            return new Method(signature, body);
        }

        private Method BuildConvenienceMethod(bool async)
        {
            var needNameChange = _protocolMethodParameters.Where(p => !p.IsOptionalInSignature)
                .SequenceEqual(_convenienceMethodParameters.Where(p => !p.IsOptionalInSignature));

            string methodName = _createMessageMethod.Name;
            if (needNameChange)
            {
                methodName = methodName.IsLastWordSingular()
                    ? $"{methodName}Value"
                    : $"{methodName.LastWordToSingular()}Values";
            }

            var signature = CreateConvenienceMethodSignature(methodName, async);
            var body = CreateConvenienceMethodBody(methodName, async);
            return new Method(signature, body);
        }

        private MethodSignature CreateProtocolMethodSignature(string name, bool async)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, _protocolMethodReturnType, null, _protocolMethodParameters, attributes).WithAsync(async);
        }

        private MethodSignature CreateConvenienceMethodSignature(string name, bool async)
        {
            var attributes = Operation.Deprecated is { } deprecated
                ? new[] { new CSharpAttribute(typeof(ObsoleteAttribute), deprecated) }
                : null;

            return new MethodSignature(name, _createMessageMethod.Summary, _createMessageMethod.Description, _createMessageMethod.Accessibility | Virtual, _convenienceMethodReturnType, null, _convenienceMethodParameters, attributes).WithAsync(async);
        }

        private MethodBody CreateConvenienceMethodBody(string methodName, bool async)
        {
            switch (Operation.Paging, Operation.LongRunning)
            {
                case { Paging: {} paging, LongRunning: null }:
                    return CreateConvenienceMethodBody(methodName, CreatePagingConvenienceMethodLines(methodName, paging, async), false);
                case { Paging: null, LongRunning: not null }:
                    return CreateConvenienceMethodBody(methodName, CreateLroConvenienceMethodLines(methodName, async), true);
                default:
                    return CreateConvenienceMethodBody(methodName, CreateConvenienceMethodLines(async), true);
            }
        }

        private MethodBody CreateConvenienceMethodBody(string methodName, IEnumerable<MethodBodySingleLine> mainBlockLines, bool checkForMethodName)
        {
            MethodBodyBlock mainBodyBlock = new MethodBodyLines(mainBlockLines.ToList());
            if (checkForMethodName && methodName != _createMessageMethod.Name)
            {
                mainBodyBlock = new DiagnosticScopeMethodBodyBlock(new Diagnostic($"{_clientName}.{methodName}"), _fields.ClientDiagnosticsProperty, mainBodyBlock);
            }
            return new MethodBody(new[] { new ParameterValidationBlock(_convenienceMethodParameters), mainBodyBlock });
        }

        private IEnumerable<MethodBodySingleLine> CreateConvenienceMethodLines(bool async)
        {
            var lines = new List<MethodBodySingleLine>();
            var protocolMethodName = _createMessageMethod.Name;

            lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
            lines.Add(Declare.Response(_protocolMethodReturnType, Call.ProtocolMethod(protocolMethodName, protocolMethodArguments, async), out var response));
            if (_responseType is not null)
            {
                lines.Add(Return(Call.Response.FromValue(_responseType, response)));
            }
            else
            {
                lines.Add(Return(response));
            }

            return lines;
        }

        private IEnumerable<MethodBodySingleLine> CreateLroConvenienceMethodLines(string methodName, bool async)
        {
            var lines = new List<MethodBodySingleLine>();
            var protocolMethodName = _createMessageMethod.Name;

            lines.CreateProtocolMethodArguments(_parameterLinks, out var protocolMethodArguments);
            if (_responseType != null)
            {
                lines.Add(Declare.Response(_protocolMethodReturnType, Call.ProtocolMethod(protocolMethodName, protocolMethodArguments, async), out var response));
                lines.Add(Return(Call.ProtocolOperationHelpers.Convert(_responseType, response, _fields.ClientDiagnosticsProperty.Declaration, $"{_clientName}.{methodName}")));
            }
            else
            {
                lines.Add(Return(Call.ProtocolMethod(protocolMethodName, protocolMethodArguments, async)));
            }

            return lines;
        }

        private IEnumerable<MethodBodySingleLine> CreatePagingConvenienceMethodLines(string methodName, OperationPaging paging, bool async)
        {
            var clientDiagnostics = _fields.ClientDiagnosticsProperty.Declaration;
            var pipeline = _fields.PipelineField.Declaration;
            var scopeName = $"{_clientName}.{methodName}";
            var itemPropertyName = paging.ItemName ?? "value";
            var nextLinkName = paging.NextLinkName;

            var lines = new List<MethodBodySingleLine>();
            CodeWriterDeclaration? createNextPageRequest = null;

            lines.CreatePageableMethodArguments(_parameterLinks, out var createRequestArguments, out var requestContextVariable);

            lines.Add(Declare.FirstPageRequest(null, _createMessageMethod.Name, createRequestArguments, out var createFirstPageRequest));
            if (_createNextPageMessageMethod is not null)
            {
                lines.Add(Declare.NextPageRequest(null, _createNextPageMessageMethod!.Name, createRequestArguments, out createNextPageRequest));
            }

            lines.Add(Return(Call.PageableHelpers.CreatePageable(createFirstPageRequest, createNextPageRequest, clientDiagnostics, pipeline, _responseType, scopeName, itemPropertyName, nextLinkName, requestContextVariable, async)));

            return lines;
        }
    }
}
