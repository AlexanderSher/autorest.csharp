﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Samples.Models
{
    /// <summary>
    /// A <see cref="InputExampleParameterValue"/> represents a value for a parameter, which could either be a <see cref="InputExampleValue"/>, or a <see cref="FormattableString"/> as a literal
    /// </summary>
    internal record InputExampleParameterValue
    {
        public string Name { get; }

        public CSharpType Type { get; }

        public ValueExpression Expression { get; }

        public InputExampleParameterValue(Parameter parameter, ValueExpression expression)
        {
            Name = parameter.Name;
            Type = parameter.Type;
            Expression = expression;
        }
    }
}
