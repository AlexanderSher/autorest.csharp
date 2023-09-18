﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record BinaryDataExpression(ValueExpression Untyped) : TypedValueExpression(typeof(BinaryData), Untyped)
    {
        public BinaryDataExpression(TypedValueExpression typed) : this(ValidateType(typed, typeof(BinaryData))) {}

        public FrameworkTypeExpression ToObjectFromJson(Type responseType)
            => new(responseType, new InvokeInstanceMethodExpression(Untyped, nameof(BinaryData.ToObjectFromJson), Array.Empty<ValueExpression>(), new[]{new CSharpType(responseType)}, false));

        public static BinaryDataExpression FromStream(ResponseExpression response, bool async)
        {
            var methodName = async ? nameof(BinaryData.FromStreamAsync) : nameof(BinaryData.FromStream);
            return new BinaryDataExpression(new InvokeStaticMethodExpression(typeof(BinaryData), methodName, new[]{response.ContentStream}));
        }

        public ValueExpression ToStream() => Invoke(nameof(BinaryData.ToStream));

        public ValueExpression ToArray() => Invoke(nameof(BinaryData.ToArray));

        public static BinaryDataExpression FromBytes(ValueExpression data)
            => new(new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromBytes), new[]{data}));

        public static BinaryDataExpression FromObjectAsJson(ValueExpression data)
            => new(new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromObjectAsJson), new[]{data}));

        public static BinaryDataExpression FromString(ValueExpression data)
            => new(new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromString), new[]{data}));
    }
}
