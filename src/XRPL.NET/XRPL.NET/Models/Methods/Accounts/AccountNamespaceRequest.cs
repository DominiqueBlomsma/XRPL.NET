using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Accounts;

public class AccountNamespaceRequest : LedgerRequestBase, IPaginationMarker
{
    /// <summary>
    /// A unique identifier for the account, most commonly the account's <see href="https://xrpl.org/basic-data-types.html#addresses">xAddress</see>.
    /// </summary>
    [Required]
    [JsonPropertyName("account")]
    public string Account { get; set; } = default!;

    [JsonPropertyName("namespace_id")]
    public string NamespaceId { get; set; } = default!;

    /// <summary>
    /// The maximum number of objects to include in the results.
    /// Must be within the inclusive range 10 to 400 on non-admin connections. The default is 200.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// Value from a previous paginated response.
    /// Resume retrieving data where that response left off.
    /// </summary>
    [JsonPropertyName("marker")]
    public object? Marker { get; set; }
}
