using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Converters;
using XRPL.NET.Enums;
using XRPL.NET.Extensions;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Helpers;

public static class XrplJsonHelper
{
    public static string MediaType = "application/json";

    public static JsonSerializerOptions SerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new JsonStringEnumMemberConverter<LedgerIndexType>(),
            new CurrencyConverter(),
            new LedgerTransactionConverter(),
            new ULongStringConverter(),
            new TransactionResultConverter(),
            new XahauEpochConverter(),
            new NullableULongStringConverter(),
            new NullableXahauEpochConverter()
        }
    };

    /// <summary>
    /// Deserialize a JsonDocument to an implementation of an XRPL TransactionType.
    /// </summary>
    /// <param name="throwException">Throws an exception if the TransactionType is not implemented if set to true, otherwise; deserialized to TransactionBase</param>
    /// <exception cref="JsonException">Thrown if JSON property TransactionType is missing in the <paramref name="document"/>.</exception>
    /// <exception cref="NotImplementedException">Thrown if <paramref name="throwException"/> set to true and implementation of TransactionType is missing.</exception>
    public static TransactionBase? DeserializeTransaction(JsonDocument document, JsonSerializerOptions options, bool throwException = false)
    {
        var transactionType = document.RootElement.GetProperty(nameof(TransactionBase.TransactionType)).GetString();
        if (transactionType == null)
        {
            throw new JsonException($"Missing '{nameof(TransactionBase.TransactionType)}' to deserialize the transaction");
        }

        var type = AttributeExtensions.GetTransactionType(transactionType, throwException);
        return (TransactionBase?)document.RootElement.Deserialize(type, options);
    }
}
