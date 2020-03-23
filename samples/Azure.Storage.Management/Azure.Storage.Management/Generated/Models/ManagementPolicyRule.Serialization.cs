// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Storage.Management.Models
{
    public partial class ManagementPolicyRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Enabled != null)
            {
                writer.WritePropertyName("enabled");
                writer.WriteBooleanValue(Enabled.Value);
            }
            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);
            writer.WritePropertyName("type");
            writer.WriteStringValue(Type);
            writer.WritePropertyName("definition");
            writer.WriteObjectValue(Definition);
            writer.WriteEndObject();
        }

        internal static ManagementPolicyRule DeserializeManagementPolicyRule(JsonElement element)
        {
            bool? enabled = default;
            string name = default;
            string type = default;
            ManagementPolicyDefinition definition = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("enabled"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    type = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("definition"))
                {
                    definition = ManagementPolicyDefinition.DeserializeManagementPolicyDefinition(property.Value);
                    continue;
                }
            }
            return new ManagementPolicyRule(enabled, name, type, definition);
        }
    }
}
