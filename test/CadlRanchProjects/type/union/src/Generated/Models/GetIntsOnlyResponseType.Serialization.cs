// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure;

namespace _Type.Union.Models
{
    public partial class GetIntsOnlyResponseType
    {
        internal static GetIntsOnlyResponseType DeserializeGetIntsOnlyResponseType(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BinaryData prop = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("prop"u8))
                {
                    prop = BinaryData.FromString(property.Value.GetRawText());
                    continue;
                }
            }
            return new GetIntsOnlyResponseType(prop);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static GetIntsOnlyResponseType FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeGetIntsOnlyResponseType(document.RootElement);
        }
    }
}
