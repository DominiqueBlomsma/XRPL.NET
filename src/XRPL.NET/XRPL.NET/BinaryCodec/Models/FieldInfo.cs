using System.Text.Json.Serialization;

namespace XRPL.NET.BinaryCodec.Models;

public class FieldInfo
{
    /// <summary>
    /// nth is the sort code, meaning "nth of type." It is is combined with the type code in order to construct the Field ID of this field. The Field ID is only used for sorting the fields.
    /// Since there are multiple fields with the same data type, the nth is used to deterministically order each field among other fields of the same data type.
    /// </summary>
    [JsonPropertyName("nth")]
    public int NthOfType { get; set; }

    /// <summary>
    /// If true, the field is Variable Length encoded and <see href="https://xrpl.org/serialization.html#length-prefixing">length-prefixed</see>.
    /// </summary>
    [JsonPropertyName("isVLEncoded")]
    public bool IsVariableLengthEncoded { get; set; }

    [JsonPropertyName("isSerialized")]
    public bool IsSerialized { get; set; }

    [JsonPropertyName("isSigningField")]
    public bool IsSigningField { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } =default!;
}
