using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Core.Converters
{
    internal class IntJsonConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            double floating = reader.GetDouble();
            int integer = (int)floating;
            return integer == floating ? integer : reader.GetInt32();
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value);
    }
}
