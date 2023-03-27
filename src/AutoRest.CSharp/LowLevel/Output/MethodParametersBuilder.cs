﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal class MethodParametersBuilder
    {
        internal sealed record ParameterLink(IReadOnlyList<Parameter> ConvenienceParameters, IReadOnlyList<Parameter> ProtocolParameters, IReadOnlyList<JsonPropertySerialization>? IntermediateSerialization)
        {
            public ParameterLink(Parameter parameter) : this(new[]{parameter}, new[]{parameter}, null){}
            public ParameterLink(Parameter convenienceParameters, Parameter protocolParameters) : this(new[]{convenienceParameters}, new[]{protocolParameters}, null){}
        }

        private static readonly Dictionary<string, RequestConditionHeaders> ConditionRequestHeader = new(StringComparer.OrdinalIgnoreCase)
        {
            ["If-Match"] = RequestConditionHeaders.IfMatch,
            ["If-None-Match"] = RequestConditionHeaders.IfNoneMatch,
            ["If-Modified-Since"] = RequestConditionHeaders.IfModifiedSince,
            ["If-Unmodified-Since"] = RequestConditionHeaders.IfUnmodifiedSince
        };

        private readonly TypeFactory _typeFactory;
        private readonly InputOperation _operation;
        private readonly List<RequestPartSource> _requestParts;
        private readonly List<Parameter> _createMessageParameters;
        private readonly List<ParameterLink> _parameterLinks;

        public MethodParametersBuilder(TypeFactory typeFactory, InputOperation operation)
        {
            _typeFactory = typeFactory;
            _operation = operation;

            _requestParts = new List<RequestPartSource>();
            _createMessageParameters = new List<Parameter>();
            _parameterLinks = new List<ParameterLink>();
        }

        public IReadOnlyList<RequestPartSource> RequestParts => _requestParts;
        public IReadOnlyList<Parameter> CreateMessageParameters => _createMessageParameters;
        public IReadOnlyList<ParameterLink> ParameterLinks => _parameterLinks;

        public void BuildHlc()
        {
            var parameters = new List<Parameter>();
            foreach (var inputParameter in _operation.Parameters.Where(rp => !RestClientBuilder.IsIgnoredHeaderParameter(rp)))
            {
                var parameter = Parameter.FromInputParameter(inputParameter, _typeFactory.CreateType(inputParameter.Type), _typeFactory);
                // Grouped and flattened parameters shouldn't be added to methods
                if (inputParameter.Kind == InputOperationParameterKind.Method)
                {
                    parameters.Add(parameter);
                }

                var serializationFormat = SerializationBuilder.GetSerializationFormat(inputParameter.Type);
                _requestParts.Add(new RequestPartSource(inputParameter.NameInRequest, inputParameter, parameter, serializationFormat));
            }

            _createMessageParameters.AddRange(parameters.OrderBy(p => p.IsOptionalInSignature));
            _parameterLinks.AddRange(_createMessageParameters.Select(p => new ParameterLink(p)));
            _parameterLinks.Add(new ParameterLink(new[]{KnownParameters.CancellationTokenParameter}, Array.Empty<Parameter>(), null));
        }

        public void BuildDpg()
        {
            var operationParameters = _operation.Parameters.Where(rp => !RestClientBuilder.IsIgnoredHeaderParameter(rp));

            var requiredPathParameters = new Dictionary<string, InputParameter>();
            var optionalPathParameters = new Dictionary<string, InputParameter>();
            var requiredRequestParameters = new List<InputParameter>();
            var optionalRequestParameters = new List<InputParameter>();

            var requestConditionHeaders = RequestConditionHeaders.None;
            var requestConditionSerializationFormat = SerializationFormat.Default;
            InputParameter? bodyParameter = null;
            InputParameter? contentTypeRequestParameter = null;
            InputParameter? requestConditionRequestParameter = null;

            foreach (var operationParameter in operationParameters)
            {
                switch (operationParameter)
                {
                    case { Location: RequestLocation.Body }:
                        bodyParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header, IsContentType: true }
                        when contentTypeRequestParameter == null:
                        contentTypeRequestParameter = operationParameter;
                        break;
                    case { Location: RequestLocation.Header }
                        when ConditionRequestHeader.TryGetValue(operationParameter.NameInRequest, out var header):
                        if (operationParameter.IsRequired)
                        {
                            throw new NotSupportedException("Required conditional request headers are not supported.");
                        }

                        requestConditionHeaders |= header;
                        requestConditionRequestParameter ??= operationParameter;
                        requestConditionSerializationFormat = requestConditionSerializationFormat == SerializationFormat.Default
                                ? SerializationBuilder.GetSerializationFormat(operationParameter.Type)
                                : requestConditionSerializationFormat;
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: null }:
                        requiredPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { Location: RequestLocation.Uri or RequestLocation.Path, DefaultValue: not null }:
                        optionalPathParameters.Add(operationParameter.NameInRequest, operationParameter);
                        break;
                    case { IsRequired: true, DefaultValue: null }:
                        requiredRequestParameters.Add(operationParameter);
                        break;
                    default:
                        optionalRequestParameters.Add(operationParameter);
                        break;
                }
            }

            AddWaitForCompletion();
            AddUriOrPathParameters(_operation.Uri, requiredPathParameters);
            AddUriOrPathParameters(_operation.Path, requiredPathParameters);
            AddQueryOrHeaderParameters(requiredRequestParameters);
            AddBody(bodyParameter, contentTypeRequestParameter, _operation.RequestMediaTypes);
            AddUriOrPathParameters(_operation.Uri, optionalPathParameters);
            AddUriOrPathParameters(_operation.Path, optionalPathParameters);
            AddQueryOrHeaderParameters(optionalRequestParameters);
            AddRequestConditionHeaders(requestConditionHeaders, requestConditionRequestParameter, requestConditionSerializationFormat);
            AddRequestContext();
        }

        private void AddWaitForCompletion()
        {
            if (_operation.LongRunning != null)
            {
                _parameterLinks.Add(new ParameterLink(KnownParameters.WaitForCompletion));
            }
        }

        private void AddUriOrPathParameters(string uriPart, IReadOnlyDictionary<string, InputParameter> requestParameters)
        {
            foreach ((ReadOnlySpan<char> span, bool isLiteral) in StringExtensions.GetPathParts(uriPart))
            {
                if (isLiteral)
                {
                    continue;
                }

                var text = span.ToString();
                if (requestParameters.TryGetValue(text, out var requestParameter))
                {
                    AddReferenceAndParameter(text, requestParameter);
                }
            }
        }

        private void AddQueryOrHeaderParameters(List<InputParameter> inputParameters)
        {
            foreach (var inputParameter in inputParameters)
            {
                AddReferenceAndParameter(inputParameter.NameInRequest, inputParameter);
            }
        }

        private void AddBody(InputParameter? inputBodyParameter, InputParameter? contentTypeRequestParameter, IReadOnlyList<string>? requestMediaTypes)
        {
            if (inputBodyParameter == null)
            {
                return;
            }

            AddReferenceAndParameter(inputBodyParameter.NameInRequest, inputBodyParameter);

            if (contentTypeRequestParameter == null)
            {
                return;
            }

            if (requestMediaTypes?.Count > 1)
            {
                AddContentTypeRequestParameter(contentTypeRequestParameter, requestMediaTypes);
            }
            else
            {
                AddReferenceAndParameter(contentTypeRequestParameter, typeof(ContentType));
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
                    _createMessageParameters.Add(KnownParameters.MatchConditionsParameter);
                    _parameterLinks.Add(new ParameterLink(KnownParameters.MatchConditionsParameter));
                    AddReference(KnownParameters.MatchConditionsParameter.Name, null, KnownParameters.MatchConditionsParameter, serializationFormat);
                    break;
                case RequestConditionHeaders.IfMatch:
                case RequestConditionHeaders.IfNoneMatch:
                    AddReferenceAndParameter(requestConditionRequestParameter, typeof(ETag));
                    break;
                default:
                    var parameter = KnownParameters.RequestConditionsParameter with { Validation = new Validation(ValidationType.AssertNull, conditionHeaderFlag) };
                    _createMessageParameters.Add(parameter);
                    _parameterLinks.Add(new ParameterLink(parameter));
                    AddReference(parameter.Name, null, parameter, serializationFormat);
                    break;
            }
        }

        private void AddRequestContext()
        {
            _createMessageParameters.Add(KnownParameters.RequestContext);
            _parameterLinks.Add(new ParameterLink(KnownParameters.CancellationTokenParameter, KnownParameters.RequestContext));
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
                _createMessageParameters.Add(protocolMethodParameter);
                _parameterLinks.Add(new ParameterLink(Array.Empty<Parameter>(), new[]{ protocolMethodParameter }, null));
                return;
            }

            if (inputParameter.Location == RequestLocation.None)
            {
                _parameterLinks.Add(new ParameterLink(new[]{ protocolMethodParameter }, Array.Empty<Parameter>(), null));
                return;
            }

            _createMessageParameters.Add(protocolMethodParameter);
            if (inputParameter is { Kind: InputOperationParameterKind.Spread })
            {
                _parameterLinks.Add(CreateSpreadParameterLink(inputParameter, protocolMethodParameter));
            }
            else
            {
                var convenienceMethodParameterType = inputParameter is { Location: RequestLocation.Body, Type: InputListType }
                    ? new CSharpType(typeof(object))
                    : _typeFactory.CreateType(inputParameter.Type);

                var convenienceMethodParameter = Parameter.FromInputParameter(inputParameter, convenienceMethodParameterType, _typeFactory);
                _parameterLinks.Add(new ParameterLink(convenienceMethodParameter, protocolMethodParameter));
            }
        }

        private ParameterLink CreateSpreadParameterLink(InputParameter inputParameter, Parameter protocolMethodParameter)
        {
            var model = inputParameter.Type as InputModelType;
            var requiredConvenienceMethodParameters = new List<Parameter>();
            var optionalConvenienceMethodParameters = new List<Parameter>();
            var intermediateSerialization = new List<JsonPropertySerialization>();
            while (model is not null)
            {
                foreach (var property in model.Properties)
                {
                    if (property is { IsReadOnly: true, IsDiscriminator: false, Type: not InputLiteralType })
                    {
                        continue;
                    }

                    var convenienceMethodParameterType = TypeFactory.GetInputType(_typeFactory.CreateType(property.Type));
                    Parameter.CreateDefaultValue(ref convenienceMethodParameterType, _typeFactory, property.DefaultValue, InputOperationParameterKind.Method, property.IsRequired, out var defaultValue, out var initializer);
                    var validation = property.IsRequired && initializer == null ? Parameter.GetValidation(convenienceMethodParameterType, inputParameter.Location, false) : Validation.None;
                    var parameter = new Parameter(property.Name, property.Description, convenienceMethodParameterType, defaultValue, validation, initializer);

                    var serializedName = property.SerializedName ?? property.Name;
                    var optionalViaNullability = parameter is { IsOptionalInSignature: true, Type.IsNullable: false } && !TypeFactory.IsCollectionType(parameter.Type);
                    var valueSerialization = SerializationBuilder.BuildJsonSerialization(property.Type, parameter.Type, false);
                    var propertySerialization = new JsonPropertySerialization(string.Empty, parameter.Name, serializedName, parameter.Type, parameter.Type, valueSerialization, !parameter.IsOptionalInSignature, false, false, optionalViaNullability);

                    if (parameter.IsOptionalInSignature)
                    {
                        optionalConvenienceMethodParameters.Add(parameter);
                    }
                    else
                    {
                        requiredConvenienceMethodParameters.Add(parameter);
                    }
                    intermediateSerialization.Add(propertySerialization);
                }

                model = model.BaseModel;
            }

            var convenienceMethodParameters = requiredConvenienceMethodParameters.Concat(optionalConvenienceMethodParameters).ToArray();
            return new ParameterLink(convenienceMethodParameters, new[] { protocolMethodParameter }, intermediateSerialization);
        }

        private void AddContentTypeRequestParameter(InputParameter inputParameter, IReadOnlyList<string> requestMediaTypes)
        {
            var name = inputParameter.Name.ToVariableName();
            var description = Parameter.CreateDescription(inputParameter, typeof(ContentType), requestMediaTypes);
            var parameter = new Parameter(name, description, typeof(ContentType), null, Validation.None, null, RequestLocation: RequestLocation.Header);

            _createMessageParameters.Add(parameter);
            _parameterLinks.Add(new ParameterLink(new[]{ parameter }, new[]{ parameter }, null));
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
    }
}
