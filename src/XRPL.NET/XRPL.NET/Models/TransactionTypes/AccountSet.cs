using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;

namespace XRPL.NET.Models.TransactionTypes;

/// <summary>
/// https://xrpl.org/accountset.html
/// </summary>
[TransactionType("AccountSet")]
public class AccountSet : TransactionBase
{
    public AccountSet()
    {
        TransactionType = nameof(AccountSet);
    }

    /// <summary>
    /// (Optional) Unique identifier of a flag to disable for this account.
    /// </summary>
    [JsonPropertyName("ClearFlag")]
    public AccountSetFlags? ClearFlag { get; set; }

    /// <summary>
    /// (Optional) A domain associated with this account. In JSON, this is the hexadecimal for the ASCII representation of the domain.
    /// <see href="https://github.com/ripple/rippled/blob/55dc7a252e08a0b02cd5aa39e9b4777af3eafe77/src/ripple/app/tx/impl/SetAccount.h#L34">Cannot be more than 256 bytes in length</see>. 
    /// </summary>
    [JsonPropertyName("Domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// (Optional) An arbitrary 128-bit value. Conventionally, clients treat this as the md5 hash of an email address to use for displaying a <see href="https://en.gravatar.com/">Gravatar</see> image.
    /// </summary>
    [JsonPropertyName("EmailHash")]
    public string? EmailHash { get; set; }

    /// <summary>
    /// (Optional) Public key for sending encrypted messages to this account.
    /// To set the key, it must be exactly 33 bytes, with the first byte indicating the key type: 0x02 or 0x03 for secp256k1 keys, 0xED for Ed25519 keys. To remove the key, use an empty value.
    /// </summary>
    [JsonPropertyName("MessageKey")]
    public string? MessageKey { get; set; }

    /// <summary>
    /// (Optional) Another account that can mint NFTokens for you. (Added by the <see href="https://xrpl.org/known-amendments.html#nonfungibletokensv1_1">NonFungibleTokensV1_1 amendment</see>.)
    /// </summary>
    [JsonPropertyName("NFTokenMinter")]
    public string? NFTokenMinter { get; set; }

    /// <summary>
    /// (Optional) Integer flag to enable for this account.
    /// </summary>
    [JsonPropertyName("SetFlag")]
    public AccountSetFlags? SetFlag { get; set; }

    /// <summary>
    /// (Optional) The fee to charge when users transfer this account's tokens, represented as billionths of a unit.
    /// Cannot be more than 2000000000 or less than 1000000000, except for the special case 0 meaning no fee.
    /// </summary>
    [JsonPropertyName("TransferRate")]
    public uint? TransferRate { get; set; }

    /// <summary>
    /// (Optional) Tick size to use for offers involving a currency issued by this address.
    /// The exchange rates of those offers is rounded to this many significant digits. Valid values are 3 to 15 inclusive, or 0 to disable. (Added by the <see href="https://xrpl.org/known-amendments.html#ticksize">TickSize amendment</see>)
    /// </summary>
    [JsonPropertyName("TickSize")]
    public byte? TickSize { get; set; }

    /// <summary>
    /// (Optional) An arbitrary 256-bit value.
    /// If specified, the value is stored as part of the account but has no inherent meaning or requirements.
    /// </summary>
    [JsonPropertyName("WalletLocator")]
    public string? WalletLocator { get; set; }

    /// <summary>
    /// (Optional) Not used. This field is valid in AccountSet transactions but does nothing.
    /// </summary>
    [JsonPropertyName("WalletSize")]
    public uint? WalletSize { get; set; }
}
