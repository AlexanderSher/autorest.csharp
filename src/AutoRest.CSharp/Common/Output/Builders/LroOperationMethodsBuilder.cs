﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class LroOperationMethodsBuilder : NonPagingOperationMethodsBuilderBase
    {
        private readonly OperationLongRunning _longRunning;

        public LroOperationMethodsBuilder(OperationLongRunning longRunning, InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, GetReturnTypes(operation, typeFactory), clientMethodParameters)
        {
            _longRunning = longRunning;
        }

        private static ClientMethodReturnTypes GetReturnTypes(InputOperation operation, TypeFactory typeFactory)
        {
            var responseType = GetResponseType(operation, typeFactory);
            var protocol = responseType is not null ? typeof(Operation<BinaryData>) : typeof(Operation);
            var convenience = responseType is not null ? new CSharpType(typeof(Operation<>), responseType) : typeof(Operation);
            return new ClientMethodReturnTypes(responseType, protocol, convenience);
        }

        protected override MethodBodyStatement CreateProtocolMethodBody(bool async)
            => WrapInDiagnosticScope(ProtocolMethodName,
                Declare("message", InvokeCreateRequestMethod(null), out var message),
                Return(InvokeProtocolOperationHelpersProcessMessageMethod(CreateScopeName(ProtocolMethodName), message, _longRunning.FinalStateVia, async))
            );

        private ValueExpression InvokeProtocolOperationHelpersProcessMessageMethod(string scope, ValueExpression message, OperationFinalStateVia finalStateVia, bool async)
        {
            var processMessageMethodName = ResponseType is not null
                ? async ? nameof(ProtocolOperationHelpers.ProcessMessageAsync) : nameof(ProtocolOperationHelpers.ProcessMessage)
                : async ? nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValueAsync) : nameof(ProtocolOperationHelpers.ProcessMessageWithoutResponseValue);

            var arguments = new List<ValueExpression>
            {
                PipelineField,
                message,
                ClientDiagnosticsProperty,
                Literal(scope),
                FrameworkEnumValue(finalStateVia),
                KnownParameters.RequestContext,
                KnownParameters.WaitForCompletion
            };

            return new InvokeStaticMethodExpression(typeof(ProtocolOperationHelpers), processMessageMethodName, arguments, null, false, async);
        }

        protected override MethodBodyStatement CreateConvenienceMethodBody(string methodName, bool async)
        {
            return methodName != ProtocolMethodName
                ? WrapInDiagnosticScope(methodName, CreateConvenienceMethodLogic(methodName, async).AsStatement())
                : CreateConvenienceMethodLogic(methodName, async).AsStatement();
        }

        protected override Method BuildLegacyConvenienceMethod(CSharpType? lroType, bool async)
        {
            var methodName = $"Start{ProtocolMethodName}";
            var arguments = ConvenienceMethodParameters.Select(p => new ParameterReference(p)).ToList();

            var signature = CreateMethodSignature(methodName, ConvenienceAccessibility, ConvenienceMethodParameters, lroType!);
            var body = new[]
            {
                new ParameterValidationBlock(ConvenienceMethodParameters, true),
                WrapInDiagnosticScopeLegacy(methodName,
                    Var("originalResponse", InvokeProtocolMethod(RestClient, arguments, async), out var response),
                    Return(New(lroType!, new MemberReference(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, InvokeCreateRequestMethod(RestClient).Request, response))
                )
            };

            return new Method(signature.WithAsync(async), body);
        }

        private IEnumerable<MethodBodyStatement> CreateConvenienceMethodLogic(string methodName, bool async)
        {
            var protocolMethodArguments = new List<ValueExpression>();
            yield return AddProtocolMethodArguments(protocolMethodArguments).ToArray();

            if (ResponseType == null)
            {
                yield return Return(InvokeProtocolMethod(null, protocolMethodArguments, async));
            }
            else
            {
                yield return Declare(ProtocolMethodReturnType, "response", InvokeProtocolMethod(null, protocolMethodArguments, async), out var response);
                yield return Return(InvokeProtocolOperationHelpersConvertMethod((SerializableObjectType)ResponseType.Implementation, response, CreateScopeName(methodName)));
            }
        }
    }
}
