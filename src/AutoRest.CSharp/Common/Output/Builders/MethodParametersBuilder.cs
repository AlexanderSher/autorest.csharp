﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class MethodParametersBuilder
    {
        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private readonly InputOperation _operation;
        private readonly TypeFactory _typeFactory;
        private readonly List<RequestPartSource> _requestParts;
        private readonly List<Parameter> _createMessageParameters;
        private readonly List<Parameter> _protocolParameters;
        private readonly List<Parameter> _convenienceParameters;
        private readonly Dictionary<Parameter, ValueExpression> _arguments;
        private readonly Dictionary<Parameter, MethodBodyStatement> _conversions;

        public MethodParametersBuilder(InputOperation operation, TypeFactory typeFactory)
        {
            _operation = operation;
            _typeFactory = typeFactory;
            _requestParts = new List<RequestPartSource>();
            _createMessageParameters = new List<Parameter>();
            _protocolParameters = new List<Parameter>();
            _convenienceParameters = new List<Parameter>();
            _arguments = new Dictionary<Parameter, ValueExpression>();
            _conversions = new Dictionary<Parameter, MethodBodyStatement>();
        }

        public ClientMethodParameters BuildParameters(IEnumerable<InputParameter> sortedParameters)
        {
            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            InputParameter? requestConditionRequestParameter = null;

            AddWaitForCompletion();
            foreach (var inputParameter in sortedParameters)
            {
                switch (inputParameter)
                {
                    case { Location: RequestLocation.Header } when ConditionRequestHeader.TryGetValue(inputParameter.NameInRequest, out var header):
                        if (inputParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= inputParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                                ? SerializationBuilder.GetSerializationFormat(inputParameter.Type)
                                : requestConditionSerializationFormat;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true }:
                        AddContentTypeRequestParameter(inputParameter);
                        break;
                    default:
                        AddReferenceAndParameter(inputParameter.NameInRequest, inputParameter);
                        break;
                }
            }

            AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter, requestConditionSerializationFormat);
            AddRequestContext();

            return new ClientMethodParameters
            (
                _requestParts,
                _createMessageParameters,
                _protocolParameters,
                _convenienceParameters,
                true,
                _arguments,
                _conversions
            );
        }

        public ClientMethodParameters BuildParametersLegacy(IEnumerable<InputParameter> unsortedParameters, IEnumerable<InputParameter> sortedParameters)
        {
            var parameters = new Dictionary<InputParameter, Parameter>();
            (InputParameter, Parameter)? flatten = null;
            foreach (var inputParameter in sortedParameters)
            {
                var parameter = Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(inputParameter.Type), _typeFactory);
                // Grouped and flattened parameters shouldn't be added to methods
                if (inputParameter.Kind == InputOperationParameterKind.Method)
                {
                    AddCreateMessageParameter(parameter);
                    _protocolParameters.Add(parameter);
                }
                else if (inputParameter.Kind == InputOperationParameterKind.Flattened)
                {
                    flatten = (inputParameter, parameter);
                }

                parameters.Add(inputParameter, parameter);
            }

            _convenienceParameters.AddRange(_protocolParameters);
            _convenienceParameters.Add(KnownParameters.CancellationTokenParameter);

            // for legacy logic, adding request parts unsorted
            foreach (var inputParameter in unsortedParameters)
            {
                var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);
                _requestParts.Add(new RequestPartSource(inputParameter.NameInRequest, inputParameter, parameters[inputParameter], serializationFormat));
            }

            if (flatten is not null)
            {
                var (inputParameter, outputParameter) = flatten.Value;
                CreateFlattenedConversions(inputParameter, outputParameter);
            }

            return new ClientMethodParameters
            (
                _requestParts,
                _createMessageParameters,
                _protocolParameters,
                _convenienceParameters,
                false,
                _arguments,
                _conversions
            );
        }

        private void AddWaitForCompletion()
        {
            if (_operation.LongRunning != null)
            {
                _convenienceParameters.Add(KnownParameters.WaitForCompletion);
                _protocolParameters.Add(KnownParameters.WaitForCompletion);
            }
        }

        private void AddRequestConditionHeaders(RequestConditionHeaders conditionHeaderFlag, InputParameter? requestConditionRequestParameter, SerializationFormat serializationFormat)
        {
            if (conditionHeaderFlag == RequestConditionHeaders.None || requestConditionRequestParameter == null)
            {
                return;
            }

            switch (conditionHeaderFlag)
            {
                case RequestConditionHeaders.IfMatch | RequestConditionHeaders.IfNoneMatch:
                    AddCreateMessageParameter(KnownParameters.MatchConditionsParameter);
                    _protocolParameters.Add(KnownParameters.MatchConditionsParameter);
                    _convenienceParameters.Add(KnownParameters.MatchConditionsParameter);
                    AddReference(KnownParameters.MatchConditionsParameter.Name, null, KnownParameters.MatchConditionsParameter, serializationFormat);
                    break;
                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    AddReferenceAndParameter(requestConditionRequestParameter, typeof(ETag));
                    break;
                default:
                    var parameter = KnownParameters.RequestConditionsParameter with { Validation = new Validation(ValidationType.AssertNull, conditionHeaderFlag) };
                    AddCreateMessageParameter(parameter);
                    _protocolParameters.Add(parameter);
                    _convenienceParameters.Add(parameter);
                    AddReference(parameter.Name, null, parameter, serializationFormat);
                    break;
            }
        }

        private void AddRequestContext()
        {
            AddCreateMessageParameter(KnownParameters.RequestContext);
            _protocolParameters.Add(KnownParameters.RequestContext);
            _convenienceParameters.Add(KnownParameters.CancellationTokenParameter);

            if (_operation.Paging is not null)
            {
                _conversions[KnownParameters.RequestContext]
                    = Declare(IfCancellationTokenCanBeCanceled(CancellationTokenExpression.KnownParameter), out var requestContext);
                _arguments[KnownParameters.RequestContext] = requestContext;
            }
            else
            {
                _conversions[KnownParameters.RequestContext]
                    = Declare(RequestContextExpression.FromCancellationToken(), out var requestContext);
                _arguments[KnownParameters.RequestContext] = requestContext;
            }
        }

        private void AddReferenceAndParameter(InputParameter inputParameter, Type parameterType)
        {
            var type = new CSharpType(parameterType, inputParameter.Type.IsNullable);
            var protocolMethodParameter = Parameter.FromInputParameter(inputParameter, type, _typeFactory);

            AddReference(inputParameter.NameInRequest, inputParameter, protocolMethodParameter, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
            AddParameter(inputParameter, protocolMethodParameter);
        }

        private void AddReferenceAndParameter(string nameInRequest, InputParameter inputParameter)
        {
            var protocolMethodParameter = inputParameter.Location == RequestLocation.Body
                ? inputParameter.IsRequired ? KnownParameters.RequestContent : KnownParameters.RequestContentNullable
                : Parameter.FromInputParameter(inputParameter, ChangeTypeForProtocolMethod(inputParameter.Type), _typeFactory);

            AddReference(nameInRequest, inputParameter, protocolMethodParameter, SerializationBuilder.GetSerializationFormat(inputParameter.Type));
            AddParameter(inputParameter, protocolMethodParameter);
        }

        private void AddParameter(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            if (inputParameter.Kind is InputOperationParameterKind.Client or InputOperationParameterKind.Constant)
            {
                // BUG: For constant bodies and bodies assigned from client, DPG still creates RequestContent parameter. Most likely, this is incorrect.
                if (inputParameter.Location != RequestLocation.Body)
                {
                    return;
                }
            }

            if (inputParameter.Kind == InputOperationParameterKind.Grouped)
            {
                AddCreateMessageParameter(protocolMethodParameter);
                _protocolParameters.Add(protocolMethodParameter);
                return;
            }

            if (inputParameter.Location == RequestLocation.None)
            {
                _convenienceParameters.Add(protocolMethodParameter);
                return;
            }

            if (inputParameter.Kind == InputOperationParameterKind.Spread)
            {
                CreateSpreadParameters(inputParameter, protocolMethodParameter);
            }
            else
            {
                var convenienceMethodParameterType = inputParameter is { Location: RequestLocation.Body, Type: InputListType }
                    ? new CSharpType(typeof(object))
                    : _typeFactory.CreateType(inputParameter.Type);

                var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, convenienceMethodParameterType, _typeFactory);
                AddCreateMessageParameter(protocolMethodParameter);
                _protocolParameters.Add(protocolMethodParameter);
                _convenienceParameters.Add(convenienceMethodParameter);

                if (protocolMethodParameter == convenienceMethodParameter)
                {
                    _arguments[protocolMethodParameter] = convenienceMethodParameter;
                }
                else
                {
                    var argumentConversion = CreateConversion(convenienceMethodParameter, protocolMethodParameter);
                    if (_operation.Paging is not null)
                    {
                        // in paging methods, every request parameter is used twice, so even conversions that can be inlined must be cached
                        _conversions[protocolMethodParameter] = new DeclareVariableStatement(protocolMethodParameter.Type, protocolMethodParameter.Name, argumentConversion, out var argument);
                        _arguments[protocolMethodParameter] = argument;
                    }
                    else
                    {
                        _arguments[protocolMethodParameter] = argumentConversion;
                    }
                }
            }
        }

        private void CreateSpreadParameters(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            var model = inputParameter.Type as InputModelType;
            var requiredConvenienceMethodParameters = new List<Parameter>();
            var optionalConvenienceMethodParameters = new List<Parameter>();
            var conversion = new List<MethodBodyStatement>
            {
                Var(protocolMethodParameter.Name, Utf8JsonRequestContentExpression.New(), out var requestContent),
                Var("writer", requestContent.JsonWriter, out var utf8JsonWriter),
                utf8JsonWriter.WriteStartObject()
            };

            while (model is not null)
            {
                foreach (var property in model.Properties)
                {
                    if (property is { IsReadOnly: true, IsDiscriminator: false, Type: not InputLiteralType })
                    {
                        continue;
                    }

                    Parameter parameter = CreateSpreadParameter(inputParameter, property);

                    if (parameter.IsOptionalInSignature)
                    {
                        optionalConvenienceMethodParameters.Add(parameter);
                    }
                    else
                    {
                        requiredConvenienceMethodParameters.Add(parameter);
                    }

                    conversion.Add(CreatePropertySerializationStatement(property, utf8JsonWriter, parameter));
                }

                model = model.BaseModel;
            }

            conversion.Add(utf8JsonWriter.WriteEndObject());
            _conversions[protocolMethodParameter] = conversion;

            AddCreateMessageParameter(protocolMethodParameter);
            _protocolParameters.Add(protocolMethodParameter);
            _convenienceParameters.AddRange(requiredConvenienceMethodParameters.Concat(optionalConvenienceMethodParameters));
            _arguments[protocolMethodParameter] = requestContent;
        }

        private void CreateFlattenedConversions(InputParameter flattenParameter, Parameter parameter)
        {
            var conversion = new List<MethodBodyStatement>
            {
                Var("content", Utf8JsonRequestContentExpression.New(), out var content),
                content.JsonWriter.WriteStartObject()
            };

            foreach (var (_, inputParameter, outputParameter, _) in _requestParts)
            {
                if (inputParameter is { FlattenedBodyProperty: { } property })
                {
                    conversion.Add(CreatePropertySerializationStatement(property, content.JsonWriter, outputParameter));
                }
            }

            conversion.Add(content.JsonWriter.WriteEndObject());
            _conversions[parameter] = conversion;
            _arguments[parameter] = content;
        }

        private Parameter CreateSpreadParameter(InputParameter inputParameter, InputModelProperty property)
        {
            var parameterType = TypeFactory.GetInputType(_typeFactory.CreateType(property.Type));
            Parameter.CreateDefaultValue(ref parameterType, _typeFactory, property.DefaultValue, false, property.IsRequired, out var defaultValue, out var initializer);
            var validation = property.IsRequired && initializer == null
                ? Parameter.GetValidation(parameterType, inputParameter.Location, false)
                : Validation.None;

            return new Parameter(property.Name, property.Description, parameterType, defaultValue, validation, initializer);
        }

        private void AddCreateMessageParameter(Parameter parameter) => _createMessageParameters.Add(parameter with {DefaultValue = null});

        private static MethodBodyStatement CreatePropertySerializationStatement(InputModelProperty property, Utf8JsonWriterExpression jsonWriter, Parameter parameter)
        {
            var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, parameter.Type, false);

            var propertyName = property.SerializedName ?? property.Name;
            var writePropertyStatement = new[]
            {
                jsonWriter.WritePropertyName(propertyName),
                JsonSerializationMethodsBuilder.SerializeExpression(jsonWriter, valueSerialization, parameter)
            };

            var writeNullStatement = property.IsRequired ? jsonWriter.WriteNull(propertyName) : null;
            if (parameter.Type.IsNullable)
            {
                return new IfElseStatement(IsNotNull(parameter), writePropertyStatement, writeNullStatement);
            }

            return writePropertyStatement;
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter)
        {
            if (_operation.RequestMediaTypes?.Count > 1)
            {
                AddContentTypeRequestParameter(inputParameter, _operation.RequestMediaTypes);
            }
            else
            {
                AddReferenceAndParameter(inputParameter, typeof(ContentType));
            }
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter, IEnumerable<string> requestMediaTypes)
        {
            var name = inputParameter.Name.ToVariableName();
            var description = Parameter.CreateDescription(inputParameter, typeof(ContentType), requestMediaTypes);
            var parameter = new Parameter(name, description, typeof(ContentType), null, Validation.None, null, RequestLocation: RequestLocation.Header);

            AddCreateMessageParameter(parameter);
            _protocolParameters.Add(parameter);
            _convenienceParameters.Add(parameter);
            AddReference(inputParameter.NameInRequest, inputParameter, parameter, SerializationFormat.Default);
        }

        private void AddReference(string nameInRequest, InputParameter? inputParameter, Parameter parameter, SerializationFormat serializationFormat)
        {
            // DPG would do ungrouping in protocol method rather than in create request methods
            _requestParts.Add(new RequestPartSource(nameInRequest, inputParameter != null ? inputParameter with { GroupedBy = null } : null, parameter, serializationFormat));
        }

        private CSharpType ChangeTypeForProtocolMethod(InputType type) => type switch
        {
            InputEnumType enumType => _typeFactory.CreateType(enumType.EnumValueType).WithNullable(enumType.IsNullable),
            InputModelType modelType => new CSharpType(typeof(object), modelType.IsNullable),
            _ => _typeFactory.CreateType(type).WithNullable(type.IsNullable)
        };

        private static RequestContextExpression IfCancellationTokenCanBeCanceled(CancellationTokenExpression cancellationToken)
            => new(new TernaryConditionalOperator(cancellationToken.CanBeCanceled, RequestContextExpression.New(cancellationToken), Null));

        private static ValueExpression CreateConversion(Parameter fromParameter, Parameter toParameter)
        {
            ValueExpression fromExpression = NullConditional(fromParameter);
            return fromParameter.Type.IsFrameworkType
                ? CreateConversion(fromExpression, fromParameter.Type.FrameworkType, toParameter.Type)
                : CreateConversion(fromExpression, fromParameter.Type.Implementation, toParameter.Type);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, Type fromFrameworkType, CSharpType toType)
        {
            if ((fromFrameworkType == typeof(BinaryData) || fromFrameworkType == typeof(string)) && toType.EqualsIgnoreNullable(typeof(RequestContent)))
            {
                return fromExpression;
            }

            return RequestContentExpression.Create(fromExpression);
        }

        private static ValueExpression CreateConversion(ValueExpression fromExpression, TypeProvider fromTypeImplementation, CSharpType toType)
        {
            return fromTypeImplementation switch
            {
                EnumType enumType           when toType.EqualsIgnoreNullable(typeof(string)) => new EnumExpression(enumType, fromExpression).ToSerial(),
                SerializableObjectType type when toType.EqualsIgnoreNullable(typeof(RequestContent)) => new SerializableObjectTypeExpression(type, fromExpression).ToRequestContent(),
                _ => fromExpression
            };
        }
    }
}
