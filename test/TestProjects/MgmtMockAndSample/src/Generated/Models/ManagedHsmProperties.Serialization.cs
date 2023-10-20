// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtMockAndSample.Models
{
    public partial class ManagedHsmProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Settings))
            {
                writer.WritePropertyName("settings"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Settings);
#else
                using var document = JsonDocument.Parse(Settings);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
            if (Optional.IsDefined(ProtectedSettings))
            {
                writer.WritePropertyName("protectedSettings"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(ProtectedSettings);
#else
                using var document = JsonDocument.Parse(ProtectedSettings);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
            if (Optional.IsDefined(RawMessage))
            {
                writer.WritePropertyName("rawMessage"u8);
                writer.WriteBase64StringValue(RawMessage, "D");
            }
            if (Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsCollectionDefined(InitialAdminObjectIds))
            {
                writer.WritePropertyName("initialAdminObjectIds"u8);
                writer.WriteStartArray();
                foreach (var item in InitialAdminObjectIds)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsDefined(EnableSoftDelete))
            {
                writer.WritePropertyName("enableSoftDelete"u8);
                writer.WriteBooleanValue(EnableSoftDelete.Value);
            }
            if (Optional.IsDefined(SoftDeleteRetentionInDays))
            {
                writer.WritePropertyName("softDeleteRetentionInDays"u8);
                writer.WriteNumberValue(SoftDeleteRetentionInDays.Value);
            }
            if (Optional.IsDefined(EnablePurgeProtection))
            {
                writer.WritePropertyName("enablePurgeProtection"u8);
                writer.WriteBooleanValue(EnablePurgeProtection.Value);
            }
            if (Optional.IsDefined(CreateMode))
            {
                writer.WritePropertyName("createMode"u8);
                writer.WriteStringValue(CreateMode.Value.ToSerialString());
            }
            if (Optional.IsDefined(NetworkAcls))
            {
                writer.WritePropertyName("networkAcls"u8);
                writer.WriteObjectValue(NetworkAcls);
            }
            if (Optional.IsDefined(PublicNetworkAccess))
            {
                writer.WritePropertyName("publicNetworkAccess"u8);
                writer.WriteStringValue(PublicNetworkAccess.Value.ToString());
            }
            writer.WriteEndObject();
        }

        internal static ManagedHsmProperties DeserializeManagedHsmProperties(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<BinaryData> settings = default;
            Optional<BinaryData> protectedSettings = default;
            Optional<byte[]> rawMessage = default;
            Optional<Guid> tenantId = default;
            Optional<IList<string>> initialAdminObjectIds = default;
            Optional<Uri> hsmUri = default;
            Optional<bool> enableSoftDelete = default;
            Optional<int> softDeleteRetentionInDays = default;
            Optional<bool> enablePurgeProtection = default;
            Optional<CreateMode> createMode = default;
            Optional<string> statusMessage = default;
            Optional<ProvisioningState> provisioningState = default;
            Optional<MhsmNetworkRuleSet> networkAcls = default;
            Optional<IReadOnlyList<MhsmPrivateEndpointConnectionItem>> privateEndpointConnections = default;
            Optional<PublicNetworkAccess> publicNetworkAccess = default;
            Optional<DateTimeOffset> scheduledPurgeDate = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("settings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    settings = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("protectedSettings"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    protectedSettings = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
                if (property.NameEquals("rawMessage"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rawMessage = property.Value.GetBytesFromBase64("D");
                    continue;
                }
                if (property.NameEquals("tenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("initialAdminObjectIds"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    initialAdminObjectIds = array;
                    continue;
                }
                if (property.NameEquals("hsmUri"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    hsmUri = new Uri(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("enableSoftDelete"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enableSoftDelete = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("softDeleteRetentionInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    softDeleteRetentionInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("enablePurgeProtection"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    enablePurgeProtection = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("createMode"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    createMode = property.Value.GetString().ToCreateMode();
                    continue;
                }
                if (property.NameEquals("statusMessage"u8))
                {
                    statusMessage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("provisioningState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    provisioningState = new ProvisioningState(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("networkAcls"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    networkAcls = MhsmNetworkRuleSet.DeserializeMhsmNetworkRuleSet(property.Value);
                    continue;
                }
                if (property.NameEquals("privateEndpointConnections"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MhsmPrivateEndpointConnectionItem> array = new List<MhsmPrivateEndpointConnectionItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(MhsmPrivateEndpointConnectionItem.DeserializeMhsmPrivateEndpointConnectionItem(item));
                    }
                    privateEndpointConnections = array;
                    continue;
                }
                if (property.NameEquals("publicNetworkAccess"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    publicNetworkAccess = new PublicNetworkAccess(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("scheduledPurgeDate"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.ValueKind == JsonValueKind.String && property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    scheduledPurgeDate = property.Value.GetDateTimeOffset("O");
                    continue;
                }
            }
            return new ManagedHsmProperties(settings.Value, protectedSettings.Value, rawMessage.Value, Optional.ToNullable(tenantId), Optional.ToList(initialAdminObjectIds), hsmUri.Value, Optional.ToNullable(enableSoftDelete), Optional.ToNullable(softDeleteRetentionInDays), Optional.ToNullable(enablePurgeProtection), Optional.ToNullable(createMode), statusMessage.Value, Optional.ToNullable(provisioningState), networkAcls.Value, Optional.ToList(privateEndpointConnections), Optional.ToNullable(publicNetworkAccess), Optional.ToNullable(scheduledPurgeDate));
        }
    }
}
