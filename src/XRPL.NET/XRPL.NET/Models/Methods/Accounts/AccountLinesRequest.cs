using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_lines.html#request-format
/// </summary>
public class AccountLinesRequest : LedgerRequestBase, IPaginationMarker
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's Address.
    /// </summary>
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// The Address of a second account. If provided, show only lines of trust connecting the two accounts.
    /// </summary>
    [JsonPropertyName("peer")]
    public string? Peer { get; set; }

    /// <summary>
    /// Limit the number of trust lines to retrieve. The server is not required to honor this value. Must be within the inclusive range 10 to 400.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Value from a previous paginated response. Resume retrieving data where that response left off. 
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
}
