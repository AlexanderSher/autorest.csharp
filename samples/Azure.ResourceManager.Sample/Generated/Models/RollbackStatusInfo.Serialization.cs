// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sample.Models
{
    public partial class RollbackStatusInfo
    {
        internal static RollbackStatusInfo DeserializeRollbackStatusInfo(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> successfullyRolledbackInstanceCount = default;
            Optional<int> failedRolledbackInstanceCount = default;
            Optional<ApiError> rollbackError = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("successfullyRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    successfullyRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("failedRolledbackInstanceCount"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    failedRolledbackInstanceCount = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rollbackError"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    rollbackError = ApiError.DeserializeApiError(property.Value);
                    continue;
                }
            }
            return new RollbackStatusInfo(Optional.ToNullable(successfullyRolledbackInstanceCount), Optional.ToNullable(failedRolledbackInstanceCount), rollbackError.Value);
        }
    }
}
