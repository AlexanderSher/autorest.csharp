// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel.Core;
using System.Text.Json;

namespace OpenAI.Models
{
    public partial class FineTuningJobEvent
    {
        internal static FineTuningJobEvent DeserializeFineTuningJobEvent(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            string @object = default;
            DateTimeOffset createdAt = default;
            FineTuningJobEventLevel level = default;
            string message = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("object"u8))
                {
                    @object = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created_at"u8))
                {
                    createdAt = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                if (property.NameEquals("level"u8))
                {
                    level = new FineTuningJobEventLevel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
            }
            return new FineTuningJobEvent(id, @object, createdAt, level, message);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The result to deserialize the model from. </param>
        internal static FineTuningJobEvent FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeFineTuningJobEvent(document.RootElement);
        }
    }
}
