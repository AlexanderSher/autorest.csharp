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

namespace AzureSample.ResourceManager.Sample.Models
{
    public partial class AzureSampleResourceManagerSamplePlan : IUtf8JsonSerializable, IJsonModel<AzureSampleResourceManagerSamplePlan>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<AzureSampleResourceManagerSamplePlan>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<AzureSampleResourceManagerSamplePlan>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureSampleResourceManagerSamplePlan>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureSampleResourceManagerSamplePlan)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher"u8);
                writer.WriteStringValue(Publisher);
            }
            if (Optional.IsDefined(Product))
            {
                writer.WritePropertyName("product"u8);
                writer.WriteStringValue(Product);
            }
            if (Optional.IsDefined(PromotionCode))
            {
                writer.WritePropertyName("promotionCode"u8);
                writer.WriteStringValue(PromotionCode);
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

        AzureSampleResourceManagerSamplePlan IJsonModel<AzureSampleResourceManagerSamplePlan>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureSampleResourceManagerSamplePlan>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AzureSampleResourceManagerSamplePlan)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeAzureSampleResourceManagerSamplePlan(document.RootElement, options);
        }

        internal static AzureSampleResourceManagerSamplePlan DeserializeAzureSampleResourceManagerSamplePlan(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string publisher = default;
            string product = default;
            string promotionCode = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publisher"u8))
                {
                    publisher = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("product"u8))
                {
                    product = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("promotionCode"u8))
                {
                    promotionCode = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new AzureSampleResourceManagerSamplePlan(name, publisher, product, promotionCode, serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (Optional.IsDefined(Name) || hasPropertyOverride)
            {
                builder.Append("  name: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Name.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Name}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Name}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Publisher), out propertyOverride);
            if (Optional.IsDefined(Publisher) || hasPropertyOverride)
            {
                builder.Append("  publisher: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Publisher.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Publisher}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Publisher}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Product), out propertyOverride);
            if (Optional.IsDefined(Product) || hasPropertyOverride)
            {
                builder.Append("  product: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Product.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Product}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Product}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PromotionCode), out propertyOverride);
            if (Optional.IsDefined(PromotionCode) || hasPropertyOverride)
            {
                builder.Append("  promotionCode: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (PromotionCode.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{PromotionCode}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{PromotionCode}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<AzureSampleResourceManagerSamplePlan>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureSampleResourceManagerSamplePlan>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(AzureSampleResourceManagerSamplePlan)} does not support writing '{options.Format}' format.");
            }
        }

        AzureSampleResourceManagerSamplePlan IPersistableModel<AzureSampleResourceManagerSamplePlan>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<AzureSampleResourceManagerSamplePlan>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeAzureSampleResourceManagerSamplePlan(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(AzureSampleResourceManagerSamplePlan)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AzureSampleResourceManagerSamplePlan>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
