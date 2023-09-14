using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Helpers;

namespace XRPL.NET.Converters;

/// <summary>
/// When representing these fields in JSON objects, most are represented as JSON numbers by default.
/// One exception is UInt64, which is represented as a string because some JSON decoders may try to represent these integers as 64-bit "double precision" floating point numbers,
/// which cannot represent all distinct UInt64 values with full precision.
///
/// https://xrpl.org/serialization.html#uint-fields
/// </summary>
public class ULongStringConverter : JsonConverter<ulong>
{
    public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (value == null)
        {
            throw new JsonException("ulong value should not be null.");
        }

        return XrplHelper.HexToULong(value);
    }

    public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
    {
        // TODO: Validate if value should be to lower (based on RewardAccumulator now).
        writer.WriteStringValue(value.ToString("X").ToLowerInvariant());
    }
}
