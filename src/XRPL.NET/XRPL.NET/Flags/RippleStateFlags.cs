namespace XRPL.NET.Flags;

[Flags]
public enum RippleStateFlags : uint
{
    /// <summary>
    /// This RippleState object <see href="https://xrpl.org/ripplestate.html#contributing-to-the-owner-reserve">contributes to the low account's owner reserve</see>.
    /// </summary>
    lsfLowReserve = 65536,

    /// <summary>
    /// This RippleState object <see href="https://xrpl.org/ripplestate.html#contributing-to-the-owner-reserve">contributes to the high account's owner reserve</see>.
    /// </summary>
    lsfHighReserve = 131072,

    /// <summary>
    /// The low account has authorized the high account to hold tokens issued by the low account.
    /// </summary>
    lsfLowAuth = 262144,

    /// <summary>
    /// The high account has authorized the low account to hold tokens issued by the high account.
    /// </summary>
    lsfHighAuth = 524288,

    /// <summary>
    /// The low account <see href="https://xrpl.org/rippling.html">has disabled rippling</see> from this trust line.
    /// </summary>
    lsfLowNoRipple = 1048576,

    /// <summary>
    /// The high account <see href="https://xrpl.org/rippling.html">has disabled rippling</see> from this trust line.
    /// </summary>
    lsfHighNoRipple = 2097152,

    /// <summary>
    /// The low account has frozen the trust line, preventing the high account from transferring the asset.
    /// </summary>
    lsfLowFreeze = 4194304,

    /// <summary>
    /// The high account has frozen the trust line, preventing the low account from transferring the asset.
    /// </summary>
    lsfHighFreeze = 8388608
}
