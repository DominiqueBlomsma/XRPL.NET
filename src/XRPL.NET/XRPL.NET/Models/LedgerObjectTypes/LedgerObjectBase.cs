using System.Text.Json.Serialization;
using XRPL.NET.Converters;

namespace XRPL.NET.Models.LedgerObjectTypes;

[JsonConverter(typeof(LedgerEntryConverter))]
public class LedgerObjectBase
{
    [JsonPropertyName("LedgerEntryType")]
    public string LedgerEntryType { get; set; } = default!;

    [JsonPropertyName("index")]
    public string? Index { get; set; }
}
