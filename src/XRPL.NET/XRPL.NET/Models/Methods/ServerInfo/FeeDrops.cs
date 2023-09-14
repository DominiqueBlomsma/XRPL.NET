using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class FeeDrops
{
    [JsonPropertyName("base_fee")]
    public string BaseFee { get; set; } = default!;

    [JsonPropertyName("median_fee")]
    public string MedianFee { get; set; } = default!;

    [JsonPropertyName("minimum_fee")]
    public string MinimumFee { get; set; } = default!;

    [JsonPropertyName("open_ledger_fee")]
    public string OpenLedgerFee { get; set; } = default!;
}
