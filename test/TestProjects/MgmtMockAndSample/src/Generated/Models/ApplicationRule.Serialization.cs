// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class ApplicationRule : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(SourceAddresses))
            {
                writer.WritePropertyName("sourceAddresses");
                writer.WriteStartArray();
                foreach (var item in SourceAddresses)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(DestinationAddresses))
            {
                writer.WritePropertyName("destinationAddresses");
                writer.WriteStartArray();
                foreach (var item in DestinationAddresses)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(Protocols))
            {
                writer.WritePropertyName("protocols");
                writer.WriteStartArray();
                foreach (var item in Protocols)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TargetFqdns))
            {
                writer.WritePropertyName("targetFqdns");
                writer.WriteStartArray();
                foreach (var item in TargetFqdns)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(TargetUrls))
            {
                writer.WritePropertyName("targetUrls");
                writer.WriteStartArray();
                foreach (var item in TargetUrls)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(FqdnTags))
            {
                writer.WritePropertyName("fqdnTags");
                writer.WriteStartArray();
                foreach (var item in FqdnTags)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(SourceIpGroups))
            {
                writer.WritePropertyName("sourceIpGroups");
                writer.WriteStartArray();
                foreach (var item in SourceIpGroups)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(TerminateTLS))
            {
                writer.WritePropertyName("terminateTLS");
                writer.WriteBooleanValue(TerminateTLS.Value);
            }
            if (Optional.IsCollectionDefined(WebCategories))
            {
                writer.WritePropertyName("webCategories");
                writer.WriteStartArray();
                foreach (var item in WebCategories)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Description))
            {
                writer.WritePropertyName("description");
                writer.WriteStringValue(Description);
            }
            writer.WritePropertyName("ruleType");
            writer.WriteStringValue(RuleType.ToString());
            writer.WriteEndObject();
        }

        internal static ApplicationRule DeserializeApplicationRule(JsonElement element)
        {
            Optional<IList<string>> sourceAddresses = default;
            Optional<IList<string>> destinationAddresses = default;
            Optional<IList<FirewallPolicyRuleApplicationProtocol>> protocols = default;
            Optional<IList<string>> targetFqdns = default;
            Optional<IList<string>> targetUrls = default;
            Optional<IList<string>> fqdnTags = default;
            Optional<IList<string>> sourceIpGroups = default;
            Optional<bool> terminateTLS = default;
            Optional<IList<string>> webCategories = default;
            Optional<string> name = default;
            Optional<string> description = default;
            FirewallPolicyRuleType ruleType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sourceAddresses"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    sourceAddresses = array;
                    continue;
                }
                if (property.NameEquals("destinationAddresses"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    destinationAddresses = array;
                    continue;
                }
                if (property.NameEquals("protocols"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<FirewallPolicyRuleApplicationProtocol> array = new List<FirewallPolicyRuleApplicationProtocol>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(FirewallPolicyRuleApplicationProtocol.DeserializeFirewallPolicyRuleApplicationProtocol(item));
                    }
                    protocols = array;
                    continue;
                }
                if (property.NameEquals("targetFqdns"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    targetFqdns = array;
                    continue;
                }
                if (property.NameEquals("targetUrls"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    targetUrls = array;
                    continue;
                }
                if (property.NameEquals("fqdnTags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    fqdnTags = array;
                    continue;
                }
                if (property.NameEquals("sourceIpGroups"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    sourceIpGroups = array;
                    continue;
                }
                if (property.NameEquals("terminateTLS"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    terminateTLS = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("webCategories"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    webCategories = array;
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("description"))
                {
                    description = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ruleType"))
                {
                    ruleType = new FirewallPolicyRuleType(property.Value.GetString());
                    continue;
                }
            }
            return new ApplicationRule(name.Value, description.Value, ruleType, Optional.ToList(sourceAddresses), Optional.ToList(destinationAddresses), Optional.ToList(protocols), Optional.ToList(targetFqdns), Optional.ToList(targetUrls), Optional.ToList(fqdnTags), Optional.ToList(sourceIpGroups), Optional.ToNullable(terminateTLS), Optional.ToList(webCategories));
        }
    }
}
