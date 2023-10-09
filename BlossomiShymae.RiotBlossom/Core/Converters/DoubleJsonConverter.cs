using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlossomiShymae.RiotBlossom.Core.Converters
{
    internal class DoubleJsonConverter : JsonConverter<double>
    {
        public override double Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
        {
            double value = 0;
            try
            {
                value = reader.GetDouble();
            }
            catch (InvalidOperationException)
            {
                value = double.Parse(reader.GetString() ?? throw new InvalidOperationException("Could not get value as a double."));
            }

            return value;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
            => writer.WriteNumberValue(value);
    }
}
