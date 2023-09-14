using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Models.TransactionTypes;

namespace XRPL.NET.Models.LedgerObjectTypes;

[LedgerEntryType("Hook")]
public class Hook : LedgerObjectBase
{
    /// <summary>
    /// The identifying (classic) address of this <see href="https://xrpl.org/accounts.html">account</see>.
    /// </summary>
    [JsonPropertyName("Account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// A bit-map of boolean flags enabled for this hook.
    /// </summary>
    [JsonPropertyName("Flags")]
    public uint Flags { get; set; }

    [JsonPropertyName("Hooks")]
    public List<HookSet> Hooks { get; set; } = default!;

    [JsonPropertyName("OwnerNode")]
    public ulong OwnerNode { get; set; }

    /// <summary>
    /// The outbound quality set by the low account, as an integer in the implied ratio LowQualityOut:1,000,000,000. As a special case, the value 0 is equivalent to 1 billion, or face value.
    /// </summary>
    [JsonPropertyName("PreviousTxnID")]
    public string PreviousTxnId { get; set; } = default!;

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">index of the ledger</see> that contains the transaction that most recently modified this object.
    /// </summary>
    [JsonPropertyName("PreviousTxnLgrSeq")]
    public uint? PreviousTxnLgrSeq { get; set; }
}
