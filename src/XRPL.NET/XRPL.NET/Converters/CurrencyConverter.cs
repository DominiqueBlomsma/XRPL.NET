using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Converters;

public class CurrencyConverter : JsonConverter<Currency>
{
    public override Currency? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new Currency
            {
                Value = reader.GetString()!
            };
        }

        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        return JsonSerializer.Deserialize<Currency>(jsonDoc.RootElement.GetRawText());
    }

    public override void Write(Utf8JsonWriter writer, Currency value, JsonSerializerOptions options)
    {
        if (value.IsXrpValue)
        {
            writer.WriteStringValue(value.Value);
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
