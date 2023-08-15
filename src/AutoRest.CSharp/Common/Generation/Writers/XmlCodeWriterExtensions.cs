﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class XmlCodeWriterExtensions
    {
        public static Dictionary<XmlPropertySerialization, CodeWriterDeclaration> ToDeserializeObjectCall(this CodeWriter writer, XmlObjectSerialization objectSerialization, CodeWriterDeclaration variable)
        {
            var propertyVariables = new Dictionary<XmlPropertySerialization, CodeWriterDeclaration>();

            CollectProperties(propertyVariables, objectSerialization);

            foreach (var propertyVariable in propertyVariables)
            {
                var property = propertyVariable.Key;
                writer.Line($"{property.ValueType} {propertyVariable.Value:D} = default;");
            }

            foreach (XmlObjectAttributeSerialization attribute in objectSerialization.Attributes)
            {
                var attributeVariable = new CodeWriterDeclaration(attribute.SerializationConstructorParameterName + "Attribute");
                using (writer.Scope($"if ({variable}.Attribute({attribute.SerializedName:L}) is {typeof(XAttribute)} {attributeVariable:D})"))
                {
                    writer.Line($"{propertyVariables[attribute]} = {GetDeserializeValueCallFormattable(attribute.ValueSerialization, $"{attributeVariable}")};");
                }
            }

            foreach (XmlObjectElementSerialization elem in objectSerialization.Elements)
            {
                writer.ToDeserializeCall(elem.ValueSerialization, propertyVariables[elem], variable);
            }

            foreach (XmlObjectArraySerialization embeddedArray in objectSerialization.EmbeddedArrays)
            {
                writer.ToDeserializeCall(embeddedArray.ArraySerialization, propertyVariables[embeddedArray], variable);
            }

            if (objectSerialization.ContentSerialization is { } contentSerialization)
            {
                writer.Line($"{propertyVariables[contentSerialization]} = {GetDeserializeValueCallFormattable(contentSerialization.ValueSerialization, $"{variable}.Value")};");
            }

            return propertyVariables;
        }

        private static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDeclaration propertyVariable, CodeWriterDeclaration variable)
        {
            if (serialization is XmlArraySerialization { Wrapped: false })
            {
                writer.DeserializeElementIntoVariable(serialization, variable, propertyVariable);
                return;
            }

            var elementVariable = new CodeWriterDeclaration(serialization.Name.ToVariableName() + "Element");
            using (writer.Scope($"if ({variable}.Element({serialization.Name:L}) is {typeof(XElement)} {elementVariable:D})"))
            {
                writer.DeserializeElementIntoVariable(serialization, elementVariable, propertyVariable);
            }
        }

        private static void DeserializeElementIntoVariable(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDeclaration xElement, CodeWriterDeclaration variable)
            => writer.Line($"{variable} = {writer.ToDeserializeElementCall(serialization, xElement)};");

        private static FormattableString ToDeserializeElementCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDeclaration variable)
        {
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    var childElementVariable = new CodeWriterDeclaration("e");

                    writer.Line($"var {arrayVariable:D} = new {arraySerialization.Type}();");
                    using (writer.Scope($"foreach (var {childElementVariable:D} in {variable}.Elements({arraySerialization.ValueSerialization.Name:L}))"))
                    {
                        writer.Line($"{arrayVariable}.Add({writer.ToDeserializeElementCall(arraySerialization.ValueSerialization, childElementVariable)});");
                    }

                    return $"{arrayVariable:I}";
                case XmlDictionarySerialization dictionarySerialization:
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"var {dictionaryVariable:D} = new {dictionarySerialization.Type}();");

                    var elementVariable = new CodeWriterDeclaration("e");

                    using (writer.Scope($"foreach (var {elementVariable:D} in {variable}.Elements())"))
                    {
                        writer.Line($"{dictionaryVariable}.Add({elementVariable}.Name.LocalName, {writer.ToDeserializeElementCall(dictionarySerialization.ValueSerialization, elementVariable)});");
                    }

                    return $"{dictionaryVariable}";
                case XmlElementValueSerialization valueSerialization:
                    writer.UseNamespace(typeof(XElementExtensions).Namespace!);
                    return GetDeserializeValueCallFormattable(valueSerialization.Value, $"{variable}");
                default:
                    throw new InvalidOperationException($"Unexpected {nameof(XmlElementSerialization)} type.");
            }
        }

        private static FormattableString GetDeserializeValueCallFormattable(XmlValueSerialization serialization, FormattableString reference)
        {
            var type = serialization.Type;

            if (type.IsFrameworkType)
            {
                var frameworkType = type.FrameworkType;
                if (frameworkType == typeof(bool) ||
                    frameworkType == typeof(char) ||
                    frameworkType == typeof(short) ||
                    frameworkType == typeof(int) ||
                    frameworkType == typeof(long) ||
                    frameworkType == typeof(float) ||
                    frameworkType == typeof(double) ||
                    frameworkType == typeof(decimal) ||
                    frameworkType == typeof(string)
                )
                {
                    return $"({type}){reference}";
                }

                if (frameworkType == typeof(ResourceIdentifier))
                {
                    return $"new {typeof(ResourceIdentifier)}(({typeof(string)}){reference})";
                }

                if (frameworkType == typeof(ResourceType))
                {
                    return $"({typeof(string)}){reference}";
                }

                if (frameworkType == typeof(Guid))
                {
                    return $"new {typeof(Guid)}({reference}.Value)";
                }

                if (frameworkType == typeof(Uri))
                {
                    return $"new {typeof(Uri)}(({typeof(string)}){reference})";
                }

                var methodName = string.Empty;

                if (frameworkType == typeof(byte[]))
                {
                    methodName = "GetBytesFromBase64Value";
                }

                if (frameworkType == typeof(DateTimeOffset))
                {
                    methodName = "GetDateTimeOffsetValue";
                }

                if (frameworkType == typeof(TimeSpan))
                {
                    methodName = "GetTimeSpanValue";
                }

                if (frameworkType == typeof(object))
                {
                    methodName = "GetObjectValue";
                }

                return $"{reference}.{methodName}({serialization.Format.ToFormatSpecifier():L})";
            }

            switch (type.Implementation)
            {
                case ObjectType _:
                    var nonNullable = type.WithNullable(false);
                    return $"{nonNullable}.Deserialize{nonNullable.Name}({reference})";

                case EnumType clientEnum:
                    return clientEnum.IsExtensible
                        ? $"new {clientEnum.Type}({reference}.Value)"
                        : (FormattableString)$"{reference}.Value.To{clientEnum.Type:D}()";

                default:
                    throw new NotSupportedException();
            }
        }

        private static void CollectProperties(Dictionary<XmlPropertySerialization, CodeWriterDeclaration> propertyVariables, XmlObjectSerialization element)
        {
            foreach (var attribute in element.Attributes)
            {
                propertyVariables.Add(attribute, new CodeWriterDeclaration(attribute.SerializationConstructorParameterName));
            }

            foreach (var attribute in element.Elements)
            {
                propertyVariables.Add(attribute, new CodeWriterDeclaration(attribute.SerializationConstructorParameterName));
            }

            foreach (var attribute in element.EmbeddedArrays)
            {
                propertyVariables.Add(attribute, new CodeWriterDeclaration(attribute.SerializationConstructorParameterName));
            }

            if (element.ContentSerialization != null)
            {
                propertyVariables.Add(element.ContentSerialization, new CodeWriterDeclaration(element.ContentSerialization.SerializationConstructorParameterName));
            }
        }
    }
}
