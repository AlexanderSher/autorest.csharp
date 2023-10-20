// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace MgmtScopeResource.Models
{
    public partial class DeploymentProperties : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Template))
            {
                writer.WritePropertyName("template"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Template);
#else
                using var document = JsonDocument.Parse(Template);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
            if (Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(Parameters);
#else
                using var document = JsonDocument.Parse(Parameters);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
            writer.WritePropertyName("mode"u8);
            writer.WriteStringValue(Mode.ToSerialString());
            writer.WriteEndObject();
        }
    }
}
