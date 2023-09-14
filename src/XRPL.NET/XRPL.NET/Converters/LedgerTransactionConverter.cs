using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Extensions;
using XRPL.NET.Models.Methods.Ledger;
using XRPL.NET.Models.TransactionTypes;

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

            var transactionType = jsonDoc.RootElement.GetProperty(nameof(TransactionBase.TransactionType)).GetString();
            if (transactionType != null)
            {
                var type = AttributeExtensions.GetTransactionType(transactionType, false);
                result.Transaction = (TransactionBase?)jsonDoc.RootElement.Deserialize(type, options);
            }
            else
            {
                throw new JsonException($"Missing '{nameof(TransactionBase.TransactionType)}' to deserialize the transaction");
            }
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
