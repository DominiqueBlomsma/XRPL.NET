using System.Text.Json.Serialization;
using XRPL.NET.Attributes;
using XRPL.NET.Flags;
using XRPL.NET.Models.BasicDataTypes;

namespace XRPL.NET.Models.TransactionTypes;

[TransactionType("Payment")]
public class Payment : TransactionBase
{
    public Payment()
    {
        TransactionType = nameof(Payment);
    }

    /// <summary>
    /// A bit-map of boolean flags enabled for this account.
    /// </summary>
    [JsonPropertyName("Flags")]
    public PaymentFlags Flags { get; set; }

    /// <summary>
    /// The amount of currency to deliver. For non-XRP amounts, the nested field names MUST be lower-case. If the <see href="https://xrpl.org/payment.html#payment-flags">tfPartialPayment flag</see> is set, deliver up to this amount instead.
    /// </summary>
    [JsonPropertyName("Amount")]
    public Currency Amount { get; set; } = default!;

    /// <summary>
    /// The unique address of the account receiving the payment.
    /// </summary>
    [JsonPropertyName("Destination")]
    public string Destination { get; set; } = default!;

    /// <summary>
    /// (Optional) Arbitrary tag that identifies the reason for the payment to the destination, or a hosted recipient to pay.
    /// </summary>
    [JsonPropertyName("DestinationTag")]
    public uint? DestinationTag { get; set; }

    /// <summary>
    /// (Optional) Arbitrary 256-bit hash representing a specific reason or identifier for this payment.
    /// </summary>
    [JsonPropertyName("InvoiceID")]
    public string? InvoiceId { get; set; }

    /// <summary>
    /// (Optional, auto-fillable) Array of payment paths to be used for this transaction. Must be omitted for XRP-to-XRP transactions.
    /// </summary>
    [JsonPropertyName("Paths")]
    public PathSet[][]? Paths { get; set; }

    /// <summary>
    /// (Optional) Highest amount of source currency this transaction is allowed to cost, including <see href="https://xrpl.org/transfer-fees.html">transfer fees</see>, exchange rates, and <see href="https://en.wikipedia.org/wiki/Slippage_%28finance%29">slippage</see>.
    /// Does not include the <see href="https://xrpl.org/transaction-cost.html">XRP destroyed as a cost for submitting the transaction</see>.
    /// For non-XRP amounts, the nested field names MUST be lower-case. Must be supplied for cross-currency/cross-issue payments. Must be omitted for XRP-to-XRP payments.
    /// </summary>
    [JsonPropertyName("SendMax")]
    public Currency? SendMax { get; set; }

    /// <summary>
    /// (Optional) Minimum amount of destination currency this transaction should deliver. Only valid if this is a <see href="https://xrpl.org/partial-payments.html">partial payment</see>. For non-XRP amounts, the nested field names are lower-case.
    /// </summary>
    [JsonPropertyName("DeliverMin")]
    public Currency? DeliverMin { get; set; }
}
