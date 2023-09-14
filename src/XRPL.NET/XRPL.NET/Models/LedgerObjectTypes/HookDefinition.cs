using System.Text.Json.Serialization;
using XRPL.NET.Attributes;

namespace XRPL.NET.Models.LedgerObjectTypes;

[LedgerEntryType("HookDefinition")]
public class HookDefinition : LedgerObjectBase
{
    [JsonPropertyName("Fee")]
    public string Fee { get; set; } = default!;
}
