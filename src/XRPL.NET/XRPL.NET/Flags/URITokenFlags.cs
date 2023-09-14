namespace XRPL.NET.Flags;

[Flags]
public enum URITokenFlags : uint
{
    None = 0,

    /// <summary>
    /// The URIToken may be later burned by the Issuer.
    /// </summary>
    tfBurnable = 1 // 0x00000001
}
