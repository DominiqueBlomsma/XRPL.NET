using System.Runtime.Serialization;

namespace XRPL.NET.Enums;

/// <summary>
/// The rippled server makes a distinction between ledger versions that are open, closed, and validated.
/// A server has one open ledger, any number of closed but unvalidated ledgers, and an immutable history of validated ledgers.
/// <see href="https://xrpl.org/ledgers.html#open-closed-and-validated-ledgers">Open, Closed, and Validated Ledgers</see>
/// </summary>
public enum LedgerIndexType
{
    /// <summary>
    /// <see cref="Validated"/> for the most recent ledger that has been validated by consensus.
    /// </summary>
    [EnumMember(Value = "validated")]
    Validated,

    /// <summary>
    /// <see cref="Closed"/> for the most recent ledger that has been closed for modifications and proposed for validation.
    /// </summary>
    [EnumMember(Value = "closed")]
    Closed,

    /// <summary>
    /// <see cref="Current"/> for the server's current working version of the ledger.
    /// </summary>
    [EnumMember(Value = "current")]
    Current
}
