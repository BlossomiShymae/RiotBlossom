using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Core
{
    internal class StringJsonConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            string? value;
            try
            {
                value = reader.GetString();
            }
            catch (InvalidOperationException)
            {
                value = $"{reader.GetInt32()}";
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            => writer.WriteStringValue(value);
    }
}
