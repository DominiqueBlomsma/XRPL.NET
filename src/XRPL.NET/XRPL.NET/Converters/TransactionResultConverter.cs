using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Converters;

public class TransactionResultConverter : JsonConverter<TransactionResult>
{
    public override TransactionResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new TransactionResult();
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                result.Result = reader.GetString();
                break;
            case JsonTokenType.Number when reader.TryGetInt32(out var intValue):
                result.ResultCode = intValue;
                break;
            default:
                throw new JsonException($"Unable to parse {typeToConvert.Name} with type {reader.TokenType}.");
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, TransactionResult value, JsonSerializerOptions options)
    {
        if (value.ResultCode.HasValue)
        {
            writer.WriteNumberValue(value.ResultCode.Value);
        }
        else
        {
            writer.WriteStringValue(value.Result);
        }
    }
}
