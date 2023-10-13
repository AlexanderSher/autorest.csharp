﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Common.Output.Expressions.ValueExpressions
{
    internal record NullConditionalExpression(ValueExpression Inner) : ValueExpression;
    internal record TypedNullConditionalExpression(TypedValueExpression Inner) : TypedValueExpression(Inner.Type, new NullConditionalExpression(Inner));
}
