using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Ledger;

public class LedgerEntryRippleState
{
    /// <summary>
    /// (Required if ripple_state is specified) 2-length array of account Addresses, defining the two accounts linked by this RippleState object.
    /// </summary>
    [Required]
    [MinLength(2, ErrorMessage = "2-length array of account Addresses")]
    [MaxLength(2, ErrorMessage = "2-length array of account Addresses")]
    [JsonPropertyName("accounts")]
    public List<string> Accounts { get; set; } = default!;

    /// <summary>
    /// (Required if ripple_state is specified) <see href="https://xrpl.org/currency-formats.html#currency-codes">Currency Code</see> of the <see href="https://xrpl.org/ripplestate.html">RippleState object</see> to retrieve.
    /// </summary>
    [Required]
    [JsonPropertyName("currency")]
    public string Currency { get; set; } = default!;
}
