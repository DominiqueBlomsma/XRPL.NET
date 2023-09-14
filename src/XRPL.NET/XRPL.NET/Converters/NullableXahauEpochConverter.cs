using System.Text.Json;
using System.Text.Json.Serialization;

namespace XRPL.NET.Converters;

public class NullableXahauEpochConverter : JsonConverter<DateTime?>
{
    private static readonly DateTime XahauEpoch = new(DateTime.UnixEpoch.Ticks + TimeSpan.FromSeconds(946684800).Ticks, DateTimeKind.Utc);

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        var value = reader.GetUInt32();
        return XahauEpoch.AddSeconds(value);
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value != null)
        {
            writer.WriteNumberValue(Convert.ToUInt32((value.Value - XahauEpoch).TotalSeconds));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
