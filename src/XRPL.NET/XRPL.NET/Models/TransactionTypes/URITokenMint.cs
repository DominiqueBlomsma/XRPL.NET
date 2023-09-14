using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;

namespace XRPL.NET.Models.TransactionTypes;

[TransactionType("URITokenMint")]
public class URITokenMint : TransactionBase
{
    public URITokenMint()
    {
        TransactionType = nameof(URITokenMint);
    }

    /// <summary>
    /// A bit-map of boolean flags enabled for this URI Token.
    /// </summary>
    [JsonPropertyName("Flags")]
    public URITokenFlags Flags { get; set; }

    /// <summary>
    /// The URI the token points to.
    /// </summary>
    [JsonPropertyName("URI")]
    public string URI { get; set; } = default!;

    /// <summary>
    /// An SHA512-Half integrity digest of the contents pointed to by the URI
    /// </summary>
    [JsonPropertyName("Digest")]
    public string? Digest { get; set; }
}
