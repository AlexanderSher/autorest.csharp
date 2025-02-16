// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure;
using Azure.Core;

namespace body_complex.Models
{
    [PersistableModelProxy(typeof(UnknownDotFish))]
    public partial class DotFish : IUtf8JsonSerializable, IJsonModel<DotFish>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DotFish>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<DotFish>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotFish>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DotFish)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("fish.type"u8);
            writer.WriteStringValue(FishType);
            if (Optional.IsDefined(Species))
            {
                writer.WritePropertyName("species"u8);
                writer.WriteStringValue(Species);
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

        DotFish IJsonModel<DotFish>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotFish>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DotFish)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDotFish(document.RootElement, options);
        }

        internal static DotFish DeserializeDotFish(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("fish.type", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "DotSalmon": return DotSalmon.DeserializeDotSalmon(element, options);
                }
            }
            return UnknownDotFish.DeserializeUnknownDotFish(element, options);
        }

        BinaryData IPersistableModel<DotFish>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotFish>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(DotFish)} does not support writing '{options.Format}' format.");
            }
        }

        DotFish IPersistableModel<DotFish>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DotFish>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeDotFish(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DotFish)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DotFish>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static DotFish FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeDotFish(document.RootElement);
        }

        /// <summary> Convert into a Utf8JsonRequestContent. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue<DotFish>(this, new ModelReaderWriterOptions("W"));
            return content;
        }
    }
}
