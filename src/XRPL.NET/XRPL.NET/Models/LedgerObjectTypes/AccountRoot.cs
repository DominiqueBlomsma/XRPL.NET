using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.LedgerObjectTypes;

[LedgerEntryType("AccountRoot")]
public class AccountRoot : LedgerObjectBase
{
    /// <summary>
    /// The identifying (classic) address of this <see href="https://xrpl.org/accounts.html">account</see>.
    /// </summary>
    [JsonPropertyName("Account")]
    public string Account { get; set; } = default!;

    /// <summary>
    /// The identifying hash of the transaction most recently sent by this account. This field must be enabled to use the <see href="https://xrpl.org/transaction-common-fields.html#accounttxnid">AccountTxnID transaction field</see>.
    /// To enable it, send an <see href="https://xrpl.org/accountset.html#accountset-flags">AccountSet transaction with the asfAccountTxnID flag enabled</see>.
    /// </summary>
    [JsonPropertyName("AccountTxnID")]
    public string? AccountTxnID { get; set; }

    /// <summary>
    /// The account's current <see href="https://xrpl.org/basic-data-types.html#specifying-currency-amounts">XRP balance in drops</see>, represented as a string.
    /// </summary>
    [JsonPropertyName("Balance")]
    public Currency? Balance { get; set; }

    /// <summary>
    /// How many total of this account's issued <see href="https://xrpl.org/non-fungible-tokens.html">non-fungible tokens</see> have been burned. This number is always equal or less than <see cref="MintedNFTokens"/>.
    /// </summary>
    [JsonPropertyName("BurnedNFTokens")]
    public uint? BurnedNFTokens { get; set; }

    /// <summary>
    /// A domain associated with this account. In JSON, this is the hexadecimal for the ASCII representation of the domain.
    /// <see href="https://github.com/ripple/rippled/blob/55dc7a252e08a0b02cd5aa39e9b4777af3eafe77/src/ripple/app/tx/impl/SetAccount.h#L34">Cannot be more than 256 bytes in length</see>. 
    /// </summary>
    [JsonPropertyName("Domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// The md5 hash of an email address. Clients can use this to look up an avatar through services such as <see href="https://en.gravatar.com/">Gravatar</see>.
    /// </summary>
    [JsonPropertyName("EmailHash")]
    public string? EmailHash { get; set; }

    /// <summary>
    /// A bit-map of boolean flags enabled for this account.
    /// </summary>
    [JsonPropertyName("Flags")]
    public AccountRootFlags Flags { get; set; }

    /// <summary>
    /// A public key that may be used to send encrypted messages to this account. In JSON, uses hexadecimal.
    /// Must be exactly 33 bytes, with the first byte indicating the key type: 0x02 or 0x03 for secp256k1 keys, 0xED for Ed25519 keys.
    /// </summary>
    [JsonPropertyName("MessageKey")]
    public string? MessageKey { get; set; }

    /// <summary>
    /// How many total <see href="https://xrpl.org/non-fungible-tokens.html">non-fungible tokens</see> have been minted by and on behalf of this account.
    /// </summary>
    [JsonPropertyName("MintedNFTokens")]
    public uint? MintedNFTokens { get; set; }

    /// <summary>
    /// Another account that can mint <see href="https://xrpl.org/non-fungible-tokens.html">non-fungible tokens</see> on behalf of this account.
    /// </summary>
    [JsonPropertyName("NFTokenMinter")]
    public string? NFTokenMinter { get; set; }

    /// <summary>
    /// The number of objects this account owns in the ledger, which contributes to its owner reserve.
    /// </summary>
    [JsonPropertyName("OwnerCount")]
    public uint OwnerCount { get; set; }

    /// <summary>
    /// The identifying hash of the transaction that most recently modified this object.
    /// </summary>
    [JsonPropertyName("PreviousTxnID")]
    public string PreviousTxnID { get; set; } = default!;

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#ledger-index">index of the ledger</see> that contains the transaction that most recently modified this object.
    /// </summary>
    [JsonPropertyName("PreviousTxnLgrSeq")]
    public uint PreviousTxnLgrSeq { get; set; }

    /// <summary>
    /// The address of a <see href="https://xrpl.org/cryptographic-keys.html">key pair</see> that can be used to sign transactions for this account instead of the master key. Use a <see href="https://xrpl.org/setregularkey.html">SetRegularKey transaction</see> to change this value.
    /// </summary>
    [JsonPropertyName("RegularKey")]
    public string? RegularKey { get; set; }

    /// <summary>
    /// The <see href="https://xrpl.org/basic-data-types.html#account-sequence">sequence number</see> of the next valid transaction for this account.
    /// </summary>
    [JsonPropertyName("Sequence")]
    public uint Sequence { get; set; }

    /// <summary>
    /// How many <see href="https://xrpl.org/tickets.html">Tickets</see> this account owns in the ledger. This is updated automatically to ensure that the account stays within the hard limit of 250 Tickets at a time. This field is omitted if the account has zero Tickets.
    /// </summary>
    [JsonPropertyName("TicketCount")]
    public uint? TicketCount { get; set; }

    /// <summary>
    /// How many significant digits to use for exchange rates of Offers involving currencies issued by this address. Valid values are 3 to 15, inclusive.
    /// </summary>
    [JsonPropertyName("TickSize")]
    public byte? TickSize { get; set; }

    /// <summary>
    /// A <see href="https://xrpl.org/transfer-fees.html">transfer fee</see> to charge other users for sending currency issued by this account to each other.
    /// </summary>
    [JsonPropertyName("TransferRate")]
    public uint? TransferRate { get; set; }

    [JsonPropertyName("RewardAccumulator")]
    public ulong? RewardAccumulator { get; set; }

    [JsonPropertyName("RewardLgrFirst")]
    public uint? RewardLgrFirst { get; set; }

    [JsonPropertyName("RewardLgrLast")]
    public uint? RewardLgrLast { get; set; }

    [JsonPropertyName("RewardTime")]
    public DateTime? RewardTime { get; set; }
}
