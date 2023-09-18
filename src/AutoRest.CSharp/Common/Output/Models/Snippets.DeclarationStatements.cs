﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static DeclarationStatement UsingDeclare(string name, StreamExpression value, out StreamExpression variable)
            => UsingDeclare(name, value, d => new StreamExpression(d), out variable);

        public static DeclarationStatement UsingDeclare(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => UsingDeclare(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement Declare(CSharpType responseType, string name, ResponseExpression value, out ResponseExpression variable)
        {
            var declare = new DeclareVariableStatement(responseType, name, value, out var untypedVariable);
            variable = new ResponseExpression(untypedVariable);
            return declare;
        }

        public static DeclarationStatement Declare(RequestContextExpression value, out RequestContextExpression variable)
            => Declare(KnownParameters.RequestContext.Name, value, d => new RequestContextExpression(d), out variable);

        public static DeclarationStatement Declare(string name, BinaryDataExpression value, out BinaryDataExpression variable)
            => Declare(name, value, d => new BinaryDataExpression(d), out variable);

        public static DeclarationStatement Declare(string name, JsonElementExpression value, out JsonElementExpression variable)
            => Declare(name, value, d => new JsonElementExpression(d), out variable);

        public static DeclarationStatement Declare(string name, ResponseExpression value, out ResponseExpression variable)
            => Declare(name, value, d => new ResponseExpression(d), out variable);

        public static DeclarationStatement Declare(string name, StreamReaderExpression value, out StreamReaderExpression variable)
            => Declare(name, value, d => new StreamReaderExpression(d), out variable);

        public static DeclarationStatement Declare(string name, TypedValueExpression value, out ValueExpression variable)
            => new DeclareVariableStatement(value.Type, name, value, out variable);

        public static DeclarationStatement Declare(VariableReference variable, ValueExpression value)
            => new DeclareVariableStatement(variable.Type, variable.Declaration, value);

        public static DeclarationStatement UsingVar(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => UsingVar(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement UsingVar(string name, JsonDocumentExpression value, out JsonDocumentExpression variable)
            => UsingVar(name, value, d => new JsonDocumentExpression(d), out variable);

        public static DeclarationStatement Var(string name, DictionaryExpression value, out DictionaryExpression variable)
            => Var(name, value, d => new DictionaryExpression(value.ValueType, d), out variable);

        public static DeclarationStatement Var(string name, FormUrlEncodedContentExpression value, out FormUrlEncodedContentExpression variable)
            => Var(name, value, d => new FormUrlEncodedContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => Var(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement Var(string name, ListExpression value, out ListExpression variable)
            => Var(name, value, d => new ListExpression(d), out variable);

        public static DeclarationStatement Var(string name, MultipartFormDataContentExpression value, out MultipartFormDataContentExpression variable)
            => Var(name, value, d => new MultipartFormDataContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, OperationExpression value, out OperationExpression variable)
            => Var(name, value, d => new OperationExpression(d), out variable);

        public static DeclarationStatement Var(string name, RawRequestUriBuilderExpression value, out RawRequestUriBuilderExpression variable)
            => Var(name, value, d => new RawRequestUriBuilderExpression(d), out variable);

        public static DeclarationStatement Var(string name, RequestExpression value, out RequestExpression variable)
            => Var(name, value, d => new RequestExpression(d), out variable);

        public static DeclarationStatement Var(string name, ResponseExpression value, out ResponseExpression variable)
            => Var(name, value, d => new ResponseExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonRequestContentExpression value, out Utf8JsonRequestContentExpression variable)
            => Var(name, value, d => new Utf8JsonRequestContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonWriterExpression value, out Utf8JsonWriterExpression variable)
            => Var(name, value, d => new Utf8JsonWriterExpression(d), out variable);

        public static DeclarationStatement Var(string name, XDocumentExpression value, out XDocumentExpression variable)
            => Var(name, value, d => new XDocumentExpression(d), out variable);

        public static DeclarationStatement Var(string name, XmlWriterContentExpression value, out XmlWriterContentExpression variable)
            => Var(name, value, d => new XmlWriterContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, TypedValueExpression value, out ValueExpression variable)
            => new DeclareVariableStatement(name, value, out variable);

        public static DeclarationStatement Var(VariableReference variable, ValueExpression value)
            => new DeclareVariableStatement(null, variable.Declaration, value);

        private static DeclarationStatement UsingDeclare<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new UsingDeclareVariableStatement(value.Type, declaration, value);
        }

        private static DeclarationStatement UsingVar<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new UsingDeclareVariableStatement(null, declaration, value);
        }

        private static DeclarationStatement Declare<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new DeclareVariableStatement(value.Type, declaration, value);
        }

        private static DeclarationStatement Var<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new DeclareVariableStatement(null, declaration, value);
        }
    }
}
