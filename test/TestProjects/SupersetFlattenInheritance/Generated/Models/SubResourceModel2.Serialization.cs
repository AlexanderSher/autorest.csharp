// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace SupersetFlattenInheritance.Models
{
    public partial class SubResourceModel2 : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(IdPropertiesId))
            {
                writer.WritePropertyName("id"u8);
                writer.WriteStringValue(IdPropertiesId);
            }
            if (Optional.IsDefined(Foo))
            {
                writer.WritePropertyName("foo"u8);
                writer.WriteStringValue(Foo);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static SubResourceModel2 DeserializeSubResourceModel2(JsonElement element)
        {
            Optional<string> id = default;
            Optional<string> id0 = default;
            Optional<string> foo = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("id"u8))
                        {
                            id0 = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("foo"u8))
                        {
                            foo = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new SubResourceModel2(id.Value, id0.Value, foo.Value);
        }
    }
}
