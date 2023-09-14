using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.Subscription;

public class SubscribeRequest
{
    /// <summary>
    /// (Optional) Array of string names of generic streams to subscribe to, as explained below
    /// </summary>
    [JsonPropertyName("streams")]
    public List<string>? Streams { get; set; }

    /// <summary>
    /// (Optional) Array with the unique addresses of accounts to monitor for validated transactions.
    /// The addresses must be in the XRP Ledger's <see href="https://xrpl.org/base58-encodings.html">base58</see> format. The server sends a notification for any transaction that affects at least one of these accounts.
    /// </summary>
    [JsonPropertyName("accounts")]
    public List<string>? Accounts { get; set; }

    /// <summary>
    /// (Optional) Like accounts, but include transactions that are not yet finalized.
    /// </summary>
    [JsonPropertyName("accounts_proposed")]
    public List<string>? AccountsProposed { get; set; }
}
