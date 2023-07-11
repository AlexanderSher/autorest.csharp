﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.Core.Pipeline;
using static AutoRest.CSharp.Output.Models.FieldModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal class ClientFields : IReadOnlyCollection<FieldDeclaration>
    {
        public FieldDeclaration? AuthorizationHeaderConstant { get; }
        public FieldDeclaration? AuthorizationApiKeyPrefixConstant { get; }
        public FieldDeclaration? ScopesConstant { get; }

        public FieldDeclaration ClientDiagnosticsProperty { get; }
        public FieldDeclaration PipelineField { get; }
        public FieldDeclaration? EndpointField { get; }
        public FieldDeclaration? UserAgentField { get; }

        public CodeWriterScopeDeclarations ScopeDeclarations { get; }

        private readonly FieldDeclaration? _apiVersionField;
        private readonly FieldDeclaration? _keyAuthField;
        private readonly FieldDeclaration? _tokenAuthField;
        private readonly IReadOnlyList<FieldDeclaration> _fields;
        private readonly IReadOnlyDictionary<string, FieldDeclaration> _parameterNamesToFields;
        private static readonly FormattableString ClientDiagnosticsDescription = $"The ClientDiagnostics is used to provide tracing support for the client library.";

        public IReadOnlyList<FieldDeclaration> CredentialFields { get; }

        public static ClientFields CreateForClient(IEnumerable<Parameter> parameters, InputAuth authorization) => new(parameters, authorization);

        public static ClientFields CreateForRestClient(IEnumerable<Parameter> parameters) => new(parameters.Where(p => p != KnownParameters.ApplicationId), null);

        private ClientFields(IEnumerable<Parameter> parameters, InputAuth? authorization)
        {
            ClientDiagnosticsProperty = new(ClientDiagnosticsDescription, Internal | ReadOnly, typeof(ClientDiagnostics), KnownParameters.ClientDiagnostics.Name.FirstCharToUpperCase(), writeAsProperty: true);
            PipelineField = new(Private | ReadOnly, typeof(HttpPipeline), "_" + KnownParameters.Pipeline.Name);

            var parameterNamesToFields = new Dictionary<string, FieldDeclaration>();
            var fields = new List<FieldDeclaration>();
            var credentialFields = new List<FieldDeclaration>();
            var properties = new List<FieldDeclaration>();

            if (authorization != null)
            {
                parameterNamesToFields[KnownParameters.Pipeline.Name] = PipelineField;
                parameterNamesToFields[KnownParameters.ClientDiagnostics.Name] = ClientDiagnosticsProperty;

                if (authorization.ApiKey is not null)
                {
                    AuthorizationHeaderConstant = new(Private | Const, typeof(string), "AuthorizationHeader", $"{authorization.ApiKey.Name:L}");
                    _keyAuthField = new(Private | ReadOnly, KnownParameters.KeyAuth.Type.WithNullable(false), "_" + KnownParameters.KeyAuth.Name);

                    fields.Add(AuthorizationHeaderConstant);
                    fields.Add(_keyAuthField);
                    if (authorization.ApiKey.Prefix is not null)
                    {
                        AuthorizationApiKeyPrefixConstant = new(Private | Const, typeof(string), "AuthorizationApiKeyPrefix", $"{authorization.ApiKey.Prefix:L}", SerializationFormat.Default);
                        fields.Add(AuthorizationApiKeyPrefixConstant);
                    }
                    credentialFields.Add(_keyAuthField);
                    parameterNamesToFields[KnownParameters.KeyAuth.Name] = _keyAuthField;
                }

                if (authorization.OAuth2 is not null)
                {
                    ScopesConstant = new(Private | Static | ReadOnly, typeof(string[]), "AuthorizationScopes", $"new string[]{{ {authorization.OAuth2.Scopes.GetLiteralsFormattable()} }}");
                    _tokenAuthField = new(Private | ReadOnly, KnownParameters.TokenAuth.Type.WithNullable(false), "_" + KnownParameters.TokenAuth.Name);

                    fields.Add(ScopesConstant);
                    fields.Add(_tokenAuthField);
                    credentialFields.Add(_tokenAuthField);
                    parameterNamesToFields[KnownParameters.TokenAuth.Name] = _tokenAuthField;
                }

                fields.Add(PipelineField);
            }
            else if (Configuration.AzureArm)
            {
                UserAgentField = new FieldDeclaration(Private | ReadOnly, typeof(TelemetryDetails), "_userAgent");
                fields.Add(UserAgentField);
            }

            foreach (Parameter parameter in parameters)
            {
                var field = CreateFieldFromParameter(parameter);

                if (field.WriteAsProperty)
                {
                    properties.Add(field);
                }
                else
                {
                    fields.Add(field);
                }
                parameterNamesToFields.Add(parameter.Name, field);

                if (parameter.Name == KnownParameters.Endpoint.Name && parameter.Type.EqualsIgnoreNullable(KnownParameters.Endpoint.Type))
                {
                    EndpointField = field;
                }

                if (parameter.IsApiVersionParameter)
                {
                    _apiVersionField = field;
                }
            }

            fields.AddRange(properties);
            if (authorization != null)
            {
                fields.Add(ClientDiagnosticsProperty);
            }

            _fields = fields;
            _parameterNamesToFields = parameterNamesToFields;
            CredentialFields = credentialFields;
            ScopeDeclarations = new CodeWriterScopeDeclarations(fields.Select(f => f.Declaration));
        }

        private FieldDeclaration CreateFieldFromParameter(Parameter parameter)
        {
            if (parameter == KnownParameters.ClientDiagnostics)
            {
                return ClientDiagnosticsProperty;
            }

            if (parameter == KnownParameters.Pipeline)
            {
                return PipelineField;
            }

            if (parameter.IsApiVersionParameter)
            {
                return new FieldDeclaration(Private | ReadOnly, typeof(string), "_" + parameter.Name);
            }

            return parameter.IsResourceIdentifier
                ? new FieldDeclaration($"{parameter.Description}", Public | ReadOnly, parameter.Type, parameter.Name.FirstCharToUpperCase(), writeAsProperty: true)
                : new FieldDeclaration(Private | ReadOnly, parameter.Type, "_" + parameter.Name);
        }

        public FieldDeclaration? GetFieldByParameter(string parameterName, CSharpType parameterType)
            => parameterName switch
            {
                "credential" when _keyAuthField != null && parameterType.EqualsIgnoreNullable(_keyAuthField.Type) => _keyAuthField,
                "credential" when _tokenAuthField != null && parameterType.EqualsIgnoreNullable(_tokenAuthField.Type) => _tokenAuthField,
                _ => _parameterNamesToFields.TryGetValue(parameterName, out var field) ? CheckFieldType(parameterType, field) : null
            };

        private FieldDeclaration? CheckFieldType(CSharpType parameterType, FieldDeclaration field)
        {
            if (field == _apiVersionField ? field.Type.Equals(typeof(string)) : field.Type.Equals(parameterType))
            {
                return field;
            }

            return null;
        }

        public FieldDeclaration? GetFieldByParameter(Parameter parameter)
            => GetFieldByParameter(parameter.Name, parameter.Type);

        public IEnumerator<FieldDeclaration> GetEnumerator() => _fields.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _fields.GetEnumerator();
        public int Count => _fields.Count;
    }
}
