using System.Text.Json;
using System.Text.Json.Serialization;

namespace XRPL.NET.Converters;

public class XahauEpochConverter : JsonConverter<DateTime>
{
    private static readonly DateTime XahauEpoch = new(DateTime.UnixEpoch.Ticks + TimeSpan.FromSeconds(946684800).Ticks, DateTimeKind.Utc);

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetUInt32();
        return XahauEpoch.AddSeconds(value);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(Convert.ToUInt32((value - XahauEpoch).TotalSeconds));
    }
}
