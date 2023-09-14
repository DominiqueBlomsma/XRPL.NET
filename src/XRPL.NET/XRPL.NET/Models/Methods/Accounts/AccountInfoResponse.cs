using System.Text.Json.Serialization;
using XRPL.NET.Models.LedgerObjectTypes;

namespace XRPL.NET.Models.Methods.Accounts;

/// <summary>
/// https://xrpl.org/account_info.html#response-format
/// </summary>
public class AccountInfoResponse
{
    [JsonPropertyName("account_data")]
    public AccountRoot AccountData { get; set; } = default!;
}
