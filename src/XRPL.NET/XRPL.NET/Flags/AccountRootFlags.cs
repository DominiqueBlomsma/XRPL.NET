namespace XRPL.NET.Flags;

/// <summary>
/// There are several options which can be either enabled or disabled for an account. These options can be changed with an AccountSet transaction.
/// In the ledger, flags are represented as binary values that can be combined with bitwise-or operations.
/// The bit values for the flags in the ledger are different than the values used to enable or disable those flags in a transaction.
/// </summary>
[Flags]
public enum AccountRootFlags : uint
{
    /// <summary>
    /// The account has used its free SetRegularKey transaction.
    /// </summary>
    lsfPasswordSpent = 65536,
    /// <summary>
    /// Requires incoming payments to specify a Destination Tag.
    /// </summary>
    lsfRequireDestTag = 131072,
    /// <summary>
    /// This account must individually approve other users for those users to hold this account's issued currencies.
    /// </summary>
    lsfRequireAuth = 262144,
    /// <summary>
    ///  Client applications should not send XRP to this account. Not enforced by rippled.
    /// </summary>
    lsfDisallowXRP = 524288,
    /// <summary>
    /// Disallows use of the master key to sign transactions for this account.
    /// </summary>
    lsfDisableMaster = 1048576,
    /// <summary>
    /// This address cannot freeze trust lines connected to it. Once enabled, cannot be disabled.
    /// </summary>
    lsfNoFreeze = 2097152,
    /// <summary>
    /// All assets issued by this address are frozen.
    /// </summary>
    lsfGlobalFreeze = 4194304,
    /// <summary>
    /// Enable rippling on this addresses' trust lines by default. Required for issuing addresses; discouraged for others.
    /// </summary>
    lsfDefaultRipple = 8388608,
    /// <summary>
    /// This account can only receive funds from transactions it sends, and from preauthorized accounts.<br/>
    /// (It has DepositAuth enabled.)
    /// </summary>
    lsfDepositAuth = 16777216
}