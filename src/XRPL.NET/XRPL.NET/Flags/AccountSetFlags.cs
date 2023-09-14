namespace XRPL.NET.Flags;

[Flags]
public enum AccountSetFlags : uint
{
    /// <summary>
    /// Track the ID of this account's most recent transaction. Required for <see href="https://xrpl.org/transaction-common-fields.html#accounttxnid">AccountTxnID</see>
    /// </summary>
    asfAccountTxnID = 5,

    /// <summary>
    /// Enable to allow another account to mint non-fungible tokens (NFTokens) on this account's behalf.
    /// Specify the authorized account in the NFTokenMinter field of the <see href="https://xrpl.org/accountroot.html">AccountRoot</see> object.
    /// To remove an authorized minter, enable this flag and omit the NFTokenMinter field. (Added by the NonFungibleTokensV1_1 amendment.)
    /// </summary>
    asfAuthorizedNFTokenMinter = 10,

    /// <summary>
    /// Enable <see href="https://xrpl.org/rippling.html">rippling</see> on this account's trust lines by default.
    /// </summary>
    asfDefaultRipple = 8,

    /// <summary>
    /// Enable <see href="https://xrpl.org/depositauth.html">Deposit Authorization</see> on this account. (Added by the <see href="https://xrpl.org/known-amendments.html#depositauth">DepositAuth amendment</see>.)
    /// </summary>
    asfDepositAuth = 9,

    /// <summary>
    /// Disallow use of the master key pair. Can only be enabled if the account has configured another way to sign transactions,
    /// such as a <see href="https://xrpl.org/cryptographic-keys.html">Regular Key</see> or a <see href="https://xrpl.org/multi-signing.html">Signer List</see>.
    /// </summary>
    asfDisableMaster = 4,

    /// <summary>
    /// Block incoming Checks. (Requires the <see href="https://xrpl.org/known-amendments.html#disallowincoming">DisallowIncoming amendment</see>)
    /// </summary>
    asfDisallowIncomingCheck = 13,

    /// <summary>
    /// Block incoming NFTokenOffers. (Requires the <see href="https://xrpl.org/known-amendments.html#disallowincoming">DisallowIncoming amendment</see> )
    /// </summary>
    asfDisallowIncomingNFTokenOffer = 12,

    /// <summary>
    /// Block incoming Payment Channels. (Requires the <see href="https://xrpl.org/known-amendments.html#disallowincoming">DisallowIncoming amendment</see> )
    /// </summary>
    asfDisallowIncomingPayChan = 14,

    /// <summary>
    /// Block incoming trust lines. (Requires the <see href="https://xrpl.org/known-amendments.html#disallowincoming">DisallowIncoming amendment</see> )
    /// </summary>
    asfDisallowIncomingTrustline = 15,

    /// <summary>
    /// XRP should not be sent to this account. (Advisory; not enforced by the XRP Ledger protocol.)
    /// </summary>
    asfDisallowXRP = 3,

    /// <summary>
    /// <see href="https://xrpl.org/freezes.html">Freeze</see> all assets issued by this account.
    /// </summary>
    asfGlobalFreeze = 7,

    /// <summary>
    /// Permanently give up the ability to <see href="https://xrpl.org/freezes.html">freeze individual trust lines or disable Global Freeze</see>.
    /// This flag can never be disabled after being enabled.
    /// </summary>
    asfNoFreeze = 6,

    /// <summary>
    /// Require authorization for users to hold balances issued by this address. Can only be enabled if the address has no trust lines connected to it.
    /// </summary>
    asfRequireAuth = 2,

    /// <summary>
    /// Require a destination tag to send transactions to this account.
    /// </summary>
    asfRequireDest = 1
}
