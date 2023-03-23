// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace CognitiveSearch.Models
{
    public partial class IndexerLimits
    {
        internal static IndexerLimits DeserializeIndexerLimits(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<TimeSpan> maxRunTime = default;
            Optional<long> maxDocumentExtractionSize = default;
            Optional<long> maxDocumentContentCharactersToExtract = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxRunTime"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    maxRunTime = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("maxDocumentExtractionSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    maxDocumentExtractionSize = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("maxDocumentContentCharactersToExtract"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    maxDocumentContentCharactersToExtract = property.Value.GetInt64();
                    continue;
                }
            }
            return new IndexerLimits(Optional.ToNullable(maxRunTime), Optional.ToNullable(maxDocumentExtractionSize), Optional.ToNullable(maxDocumentContentCharactersToExtract));
        }
    }
}
