using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Helpers;
using XRPL.NET.Models.Methods.Ledger;

namespace XRPL.NET.Converters;

public class LedgerTransactionConverter : JsonConverter<LedgerTransaction>
{
    public override LedgerTransaction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = new LedgerTransaction();

        if (reader.TokenType == JsonTokenType.String)
        {
            result.Hash = reader.GetString();
        }
        else
        {
            using var jsonDoc = JsonDocument.ParseValue(ref reader);
            result.Transaction = XrplJsonHelper.DeserializeTransaction(jsonDoc, options);
        }

        return result;
    }

    public override void Write(Utf8JsonWriter writer, LedgerTransaction value, JsonSerializerOptions options)
    {
        if (!string.IsNullOrWhiteSpace(value.Hash))
        {
            writer.WriteStringValue(value.Hash);
        }
        else
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
