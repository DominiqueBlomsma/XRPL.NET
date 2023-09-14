using System.Text.Json.Serialization;

namespace XRPL.NET.Models.BasicDataTypes;

/// <summary>
/// The Paths field of a cross-currency <see href="https://xrpl.org/payment.html">Payment transaction</see> is a "PathSet", represented in JSON as an array of arrays. For more information on what paths are used for, see <see href="https://xrpl.org/paths.html">Paths</see>.
/// </summary>
public class PathSet
{
    /// <summary>
    /// (Optional) If present, this path step represents rippling through the specified address. MUST NOT be provided if this step specifies the currency or issuer fields.
    /// </summary>
    [JsonPropertyName("account")]
    public string? Account { get; set; }

    /// <summary>
    /// (Optional) If present, this path step represents changing currencies through an order book. The currency specified indicates the new currency. MUST NOT be provided if this step specifies the account field.
    /// </summary>
    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    /// <summary>
    /// (Optional) If present, this path step represents changing currencies and this address defines the issuer of the new currency.
    /// If omitted in a step with a non-XRP currency, a previous step of the path defines the issuer. If present when currency is omitted,
    /// indicates a path step that uses an order book between same-named currencies with different issuers. MUST be omitted if the currency is XRP.
    /// MUST NOT be provided if this step specifies the account field.
    /// </summary>
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    /// <summary>
    /// DEPRECATED (Optional) An indicator of which other fields are present.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("type")]
    public int? Type { get; set; }

    /// <summary>
    /// DEPRECATED: (Optional) A hexadecimal representation of the type field.
    /// </summary>
    [Obsolete]
    [JsonPropertyName("type_hex")]
    public string? TypeHex { get; set; }
}
