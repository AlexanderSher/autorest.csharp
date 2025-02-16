// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager;

namespace MgmtDiscriminator.Models
{
    public partial class CacheExpirationActionParameters : IUtf8JsonSerializable, IJsonModel<CacheExpirationActionParameters>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<CacheExpirationActionParameters>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<CacheExpirationActionParameters>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CacheExpirationActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CacheExpirationActionParameters)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("cacheBehavior"u8);
            writer.WriteStringValue(CacheBehavior.ToString());
            writer.WritePropertyName("cacheType"u8);
            writer.WriteStringValue(CacheType.ToString());
            if (Optional.IsDefined(CacheDuration))
            {
                if (CacheDuration != null)
                {
                    writer.WritePropertyName("cacheDuration"u8);
                    writer.WriteStringValue(CacheDuration.Value, "c");
                }
                else
                {
                    writer.WriteNull("cacheDuration");
                }
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        CacheExpirationActionParameters IJsonModel<CacheExpirationActionParameters>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CacheExpirationActionParameters>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CacheExpirationActionParameters)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeCacheExpirationActionParameters(document.RootElement, options);
        }

        internal static CacheExpirationActionParameters DeserializeCacheExpirationActionParameters(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            CacheExpirationActionParametersTypeName typeName = default;
            CacheBehavior cacheBehavior = default;
            CacheType cacheType = default;
            TimeSpan? cacheDuration = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new CacheExpirationActionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheBehavior"u8))
                {
                    cacheBehavior = new CacheBehavior(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheType"u8))
                {
                    cacheType = new CacheType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("cacheDuration"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        cacheDuration = null;
                        continue;
                    }
                    cacheDuration = property.Value.GetTimeSpan("c");
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new CacheExpirationActionParameters(typeName, cacheBehavior, cacheType, cacheDuration, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TypeName), out propertyOverride);
            builder.Append("  typeName: ");
            if (hasPropertyOverride)
            {
                builder.AppendLine($"{propertyOverride}");
            }
            else
            {
                builder.AppendLine($"'{TypeName.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(CacheBehavior), out propertyOverride);
            builder.Append("  cacheBehavior: ");
            if (hasPropertyOverride)
            {
                builder.AppendLine($"{propertyOverride}");
            }
            else
            {
                builder.AppendLine($"'{CacheBehavior.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(CacheType), out propertyOverride);
            builder.Append("  cacheType: ");
            if (hasPropertyOverride)
            {
                builder.AppendLine($"{propertyOverride}");
            }
            else
            {
                builder.AppendLine($"'{CacheType.ToString()}'");
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(CacheDuration), out propertyOverride);
            if (Optional.IsDefined(CacheDuration) || hasPropertyOverride)
            {
                builder.Append("  cacheDuration: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    var formattedTimeSpan = TypeFormatters.ToString(CacheDuration.Value, "P");
                    builder.AppendLine($"'{formattedTimeSpan}'");
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<CacheExpirationActionParameters>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CacheExpirationActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(CacheExpirationActionParameters)} does not support writing '{options.Format}' format.");
            }
        }

        CacheExpirationActionParameters IPersistableModel<CacheExpirationActionParameters>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<CacheExpirationActionParameters>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeCacheExpirationActionParameters(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(CacheExpirationActionParameters)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CacheExpirationActionParameters>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
