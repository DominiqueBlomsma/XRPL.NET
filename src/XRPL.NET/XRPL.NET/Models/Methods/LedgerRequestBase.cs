using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods;

public class LedgerRequestBase
{
    [JsonExtensionData]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BasicDataTypes.Ledger? Ledger { get; set; }
}
