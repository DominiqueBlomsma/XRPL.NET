using System.Text.Json.Serialization;
using XRPL.NET.Converters;
using XRPL.NET.Models.LedgerObjectTypes;

namespace XRPL.NET.Models.Methods.Ledger;

/// <summary>
/// https://xrpl.org/ledger_entry.html#response-format
/// </summary>
public class LedgerEntryResponse
{
    /// <summary>
    /// The unique ID of this <see href="https://xrpl.org/ledger-object-types.html">ledger object</see>.
    /// </summary>
    [JsonPropertyName("index")]
    public string Index { get; set; } = default!;

    /// <summary>
    /// (Omitted if "binary": true specified.) Object containing the data of this ledger object, according to the <see href="https://xrpl.org/ledger-object-types.html">ledger format</see>.
    /// </summary>
    [JsonPropertyName("node")]
    public LedgerObjectBase? Node { get; set; }

    /// <summary>
    /// (Omitted unless "binary":true specified) The <see href="https://xrpl.org/serialization.html">binary representation</see> of the ledger object, as hexadecimal.
    /// </summary>
    [JsonPropertyName("node_binary")]
    public string? NodeBinary { get; set; }
}
