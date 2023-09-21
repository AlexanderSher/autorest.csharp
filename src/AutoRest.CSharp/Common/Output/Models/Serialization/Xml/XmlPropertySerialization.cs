﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal abstract class XmlPropertySerialization : PropertySerialization
    {
        public string PropertyName { get; }

        protected XmlPropertySerialization(string serializedName, ObjectTypeProperty property)
            : base(property.Declaration.Name.ToVariableName(), new MemberExpression(null, property.Declaration.Name), serializedName, property.Declaration.Type, property.ValueType, property.SchemaProperty?.Required ?? property.InputModelProperty?.IsRequired ?? false, property.SchemaProperty?.ReadOnly ?? property.InputModelProperty?.IsReadOnly ?? false)
        {
            PropertyName = property.Declaration.Name;
        }
    }
}
