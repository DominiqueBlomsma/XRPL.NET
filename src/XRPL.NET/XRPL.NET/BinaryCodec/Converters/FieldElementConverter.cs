using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.BinaryCodec.Models;

namespace XRPL.NET.BinaryCodec.Converters;

internal class FieldElementConverter : JsonConverter<FieldElement>
{
    public override FieldElement Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        var field = new FieldElement
        {
            FieldName = element[0].GetString() ?? throw new ArgumentNullException(nameof(FieldElement.FieldName), $"Failed to get {nameof(FieldElement.FieldName)} of {nameof(FieldElement)}."),
            Info = element[1].Deserialize<FieldInfo>() ?? throw new ArgumentNullException(nameof(FieldElement.Info), $"Failed to get {nameof(FieldElement.Info)} of {nameof(FieldElement)}.")
        };
        return field;
    }

    public override void Write(Utf8JsonWriter writer, FieldElement value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        writer.WriteStringValue(value.FieldName);
        JsonSerializer.Serialize(writer, value.Info, options);
        writer.WriteEndArray();
    }
}