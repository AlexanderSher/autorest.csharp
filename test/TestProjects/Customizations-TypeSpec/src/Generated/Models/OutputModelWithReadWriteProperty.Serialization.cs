// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using CustomizationsInTsp;

namespace CustomizationsInTsp.Models
{
    public partial class OutputModelWithReadWriteProperty : IUtf8JsonSerializable, IJsonModel<OutputModelWithReadWriteProperty>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<OutputModelWithReadWriteProperty>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<OutputModelWithReadWriteProperty>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModelWithReadWriteProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputModelWithReadWriteProperty)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(PropertyReadWriteToReadOnly))
            {
                writer.WritePropertyName("propertyReadWriteToReadOnly"u8);
                writer.WriteStringValue(PropertyReadWriteToReadOnly);
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

        OutputModelWithReadWriteProperty IJsonModel<OutputModelWithReadWriteProperty>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModelWithReadWriteProperty>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(OutputModelWithReadWriteProperty)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeOutputModelWithReadWriteProperty(document.RootElement, options);
        }

        internal static OutputModelWithReadWriteProperty DeserializeOutputModelWithReadWriteProperty(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string propertyReadWriteToReadOnly = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("propertyReadWriteToReadOnly"u8))
                {
                    propertyReadWriteToReadOnly = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new OutputModelWithReadWriteProperty(propertyReadWriteToReadOnly, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<OutputModelWithReadWriteProperty>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModelWithReadWriteProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(OutputModelWithReadWriteProperty)} does not support '{options.Format}' format.");
            }
        }

        OutputModelWithReadWriteProperty IPersistableModel<OutputModelWithReadWriteProperty>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<OutputModelWithReadWriteProperty>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeOutputModelWithReadWriteProperty(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(OutputModelWithReadWriteProperty)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<OutputModelWithReadWriteProperty>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static OutputModelWithReadWriteProperty FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeOutputModelWithReadWriteProperty(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(this);
            return content;
        }
    }
}
