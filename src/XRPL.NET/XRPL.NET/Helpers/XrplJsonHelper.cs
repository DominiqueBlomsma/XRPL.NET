using System.Text.Json;
using System.Text.Json.Serialization;
using XRPL.NET.Converters;
using XRPL.NET.Enums;

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
}
