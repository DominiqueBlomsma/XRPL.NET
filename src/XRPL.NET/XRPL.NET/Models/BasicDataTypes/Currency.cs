using System.Text.Json.Serialization;
using XRPL.NET.Helpers;

namespace XRPL.NET.Models.BasicDataTypes;

public class Currency
{
    /// <summary>
    /// Arbitrary currency code for the token.
    /// </summary>
    [JsonPropertyName("currency")]
    public string CurrencyCode { get; set; } = default!;

    /// <summary>
    /// Generally, the <see href="https://xrpl.org/accounts.html">account</see> that issues this token. In special cases, this can refer to the account that holds the token instead.
    /// </summary>
    [JsonPropertyName("issuer")]
    public string Issuer { get; set; } = default!;

    /// <summary>
    /// Quoted decimal representation of the amount of the token. This can include scientific notation, such as 1.23e11 meaning 123,000,000,000.
    /// Both e and E may be used. This can be negative when displaying balances, but negative values are disallowed in other contexts such as specifying how much to send.
    /// </summary>
    [JsonPropertyName("value")]
    public string Value { get; set; } = default!;

    [JsonIgnore]
    public decimal ValueAsNumber => IsXrpValue ? XrplCurrencyHelper.StringDropsToDecimal(Value) : XrplCurrencyHelper.StringValueToDecimal(Value);

    [JsonIgnore]
    public ulong Drops => IsXrpValue ? XrplCurrencyHelper.StringDropsToULong(Value) : throw new InvalidOperationException("Currency value is not XRP");

    [JsonIgnore]
    public bool IsXrpValue => string.IsNullOrWhiteSpace(CurrencyCode) || CurrencyCode.Equals(XrplHelper.XRP);
}
