﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record BoolExpression(ValueExpression Untyped) : TypedValueExpression(typeof(bool), Untyped)
    {
    }

    internal sealed record EnumerableExpression(CSharpType ItemType, ValueExpression Untyped) : TypedValueExpression(typeof(IEnumerable<>), Untyped)
    {
        public BoolExpression Any() => new(new InvokeStaticMethodExpression(typeof(Enumerable), nameof(Enumerable.Any), new[]{Untyped}, CallAsExtension: true));
    }

    internal sealed record KeyValuePairExpression(ValueExpression Untyped) : TypedValueExpression(typeof(KeyValuePair<,>), Untyped)
    {
        public ValueExpression Key => new MemberExpression(Untyped, nameof(KeyValuePair<string, string>.Key));
        public ValueExpression Value => new MemberExpression(Untyped, nameof(KeyValuePair<string, string>.Value));
    }
}
