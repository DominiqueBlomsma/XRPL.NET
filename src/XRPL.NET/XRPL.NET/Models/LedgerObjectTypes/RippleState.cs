using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.LedgerObjectTypes;

/// <summary>
/// https://xrpl.org/ripplestate.html
/// </summary>
[LedgerEntryType("RippleState")]
public class RippleState : LedgerObjectBase
{
    /// <summary>
    /// The balance of the trust line, from the perspective of the low account.
    /// A negative balance indicates that the high account holds tokens issued by the low account.
    /// The issuer in this is always set to the neutral value <see href="https://xrpl.org/accounts.html#special-addresses">ACCOUNT_ONE</see>.
    /// </summary>
    [JsonPropertyName("Balance")]
    public Currency? Balance { get; set; }

    /// <summary>
    /// A bit-map of boolean flags enabled for this account.
    /// </summary>
    [JsonPropertyName("Flags")]
    public RippleStateFlags Flags { get; set; }

    /// <summary>
    /// The limit that the high account has set on the trust line.
    /// The issuer is the address of the high account that set this limit.
    /// </summary>
    [JsonPropertyName("HighLimit")]
    public Currency HighLimit { get; set; } = default!;

    /// <summary>
    /// (Omitted in some historical ledgers) A hint indicating which page of the high account's owner directory links to this object, in case the directory consists of multiple pages.
    /// </summary>
    [JsonPropertyName("HighNode")]
    public ulong? HighNode { get; set; }

    /// <summary>
    /// The inbound quality set by the high account, as an integer in the implied ratio HighQualityIn:1,000,000,000. As a special case, the value 0 is equivalent to 1 billion, or face value.
    /// </summary>
    [JsonPropertyName("HighQualityIn")]
    public uint? HighQualityIn { get; set; }

    /// <summary>
    /// The outbound quality set by the high account, as an integer in the implied ratio HighQualityOut:1,000,000,000. As a special case, the value 0 is equivalent to 1 billion, or face value.
    /// </summary>
    [JsonPropertyName("HighQualityOut")]
    public uint? HighQualityOut { get; set; }

    /// <summary>
    /// The limit that the low account has set on the trust line.
    /// The issuer is the address of the low account that set this limit.
    /// </summary>
    [JsonPropertyName("LowLimit")]
    public Currency LowLimit { get; set; } = default!;

    /// <summary>
    /// (Omitted in some historical ledgers) A hint indicating which page of the low account's owner directory links to this object, in case the directory consists of multiple pages.
    /// </summary>
    [JsonPropertyName("LowNode")]
    public ulong? LowNode { get; set; }

    /// <summary>
    /// The inbound quality set by the low account, as an integer in the implied ratio LowQualityIn:1,000,000,000. As a special case, the value 0 is equivalent to 1 billion, or face value.
    /// </summary>
    [JsonPropertyName("LowQualityIn")]
    public uint? LowQualityIn { get; set; }

    /// <summary>
    /// The outbound quality set by the low account, as an integer in the implied ratio LowQualityOut:1,000,000,000. As a special case, the value 0 is equivalent to 1 billion, or face value.
    /// </summary>
    [JsonPropertyName("LowQualityOut")]
    public uint? LowQualityOut { get; set; }

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
