using System.Text.Json.Serialization;

namespace XRPL.NET.Models.Methods.ServerInfo;

public class State
{
    /// <summary>
    /// (May be omitted) If true, this server is <see href="https://xrpl.org/amendments.html#amendment-blocked-servers">amendment blocked</see>.
    /// If the server is not amendment blocked, the response omits this field.
    /// </summary>
    [JsonPropertyName("amendment_blocked")]
    public bool? AmendmentBlocked { get; set; }

    /// <summary>
    /// The version number of the running rippled version.
    /// </summary>
    [JsonPropertyName("build_version")]
    public string BuildVersion { get; set; } = default!;

    /// <summary>
    /// Range expression indicating the sequence numbers of the ledger versions the local rippled has in its database.
    /// It is possible to be a disjoint sequence, e.g. "2500-5000,32570-7695432". If the server does not have any complete ledgers (for example,
    /// it recently started syncing with the network), this is the string empty.
    /// </summary>
    [JsonPropertyName("complete_ledgers")]
    public string CompleteLedgers { get; set; } = default!;

    [JsonPropertyName("initial_sync_duration_us")]
    public string? InitialSyncDurationUs { get; set; }

    /// <summary>
    /// Amount of time spent waiting for I/O operations, in milliseconds. If this number is not very, very low, then the rippled server is probably having serious load issues.
    /// </summary>
    [JsonPropertyName("io_latency_ms")]
    public int IoLatencyMs { get; set; }

    /// <summary>
    /// The number of times this server has had over 250 transactions waiting to be processed at once.
    /// A large number here may mean that your server is unable to handle the transaction load of the XRP Ledger network.
    /// For detailed recommendations of future-proof server specifications, see <see href="https://xrpl.org/capacity-planning.html">Capacity Planning</see>.
    /// </summary>
    [JsonPropertyName("jq_trans_overflow")]
    public string JqTransOverflow { get; set; } = default!;

    /// <summary>
    /// Information about the last time the server closed a ledger, including the amount of time it took to reach a consensus and the number of trusted validators participating.
    /// </summary>
    [JsonPropertyName("last_close")]
    public LastClose LastClose { get; set; } = default!;

    /// <summary>
    /// This is the baseline amount of server load used in <see href="https://xrpl.org/transaction-cost.html">transaction cost</see> calculations.
    /// If the load_factor is equal to the load_base then only the base transaction cost is enforced.
    /// If the load_factor is higher than the load_base, then transaction costs are multiplied by the ratio between them.
    /// For example, if the load_factor is double the load_base, then transaction costs are doubled.
    /// </summary>
    [JsonPropertyName("load_base")]
    public int LoadBase { get; set; }

    /// <summary>
    /// The load factor the server is currently enforcing. The ratio between this value and the load_base determines the multiplier for transaction costs.
    /// The load factor is determined by the highest of the individual server's load factor, cluster's load factor, the <see href="https://xrpl.org/transaction-cost.html#open-ledger-cost">open ledger cost</see>, and the overall network's load factor.
    /// </summary>
    [JsonPropertyName("load_factor")]
    public int LoadFactor { get; set; }

    /// <summary>
    /// (May be omitted) The current multiplier to the <see href="https://xrpl.org/transaction-cost.html">transaction cost</see> to get into the open ledger, in <see href="https://xrpl.org/transaction-cost.html#fee-levels">fee levels</see>.
    /// </summary>
    [JsonPropertyName("load_factor_fee_escalation")]
    public int? LoadFactorFeeEscalation { get; set; }

    /// <summary>
    /// (May be omitted) The current multiplier to the <see href="https://xrpl.org/transaction-cost.html">transaction cost</see> to get into the queue, if the queue is full, in <see href="https://xrpl.org/transaction-cost.html#fee-levels">fee levels</see>.
    /// </summary>
    [JsonPropertyName("load_factor_fee_queue")]
    public int? LoadFactorFeeQueue { get; set; }

    /// <summary>
    /// (May be omitted) The <see href="https://xrpl.org/transaction-cost.html">transaction cost</see> with no load scaling, in <see href="https://xrpl.org/transaction-cost.html#fee-levels">fee levels</see>.
    /// </summary>
    [JsonPropertyName("load_factor_fee_reference")]
    public int? LoadFactorFeeReference { get; set; }

    /// <summary>
    /// (May be omitted) The load factor the server is enforcing, not including the <see href="https://xrpl.org/transaction-cost.html#open-ledger-cost">open ledger cost</see>. 
    /// </summary>
    [JsonPropertyName("load_factor_server")]
    public int? LoadFactorServer { get; set; }

    [JsonPropertyName("network_id")]
    public int NetworkId { get; set; }

    [JsonPropertyName("peer_disconnects")]
    public string? PeerDisconnects { get; set; }

    [JsonPropertyName("peer_disconnects_resources")]
    public string? PeerDisconnectsResources { get; set; }

    [JsonPropertyName("peers")]
    public int Peers { get; set; }

    /// <summary>
    /// Public key used to verify this server for peer-to-peer communications. This node key pair is automatically generated by the server the first time it starts up.
    /// (If deleted, the server can create a new pair of keys.) You can set a persistent value in the config file using the [node_seed] config option, which is useful for <see href="https://xrpl.org/clustering.html">clustering</see>.
    /// </summary>
    [JsonPropertyName("pubkey_node")]
    public string PubKeyNode { get; set; } = default!;

    /// <summary>
    /// (Admin only) Public key used by this node to sign ledger validations. This validation key pair is derived from the [validator_token] or [validation_seed] config field.
    /// </summary>
    [JsonPropertyName("pubkey_validator")]
    public string? PubKeyValidator { get; set; }

    /// <summary>
    /// A string indicating to what extent the server is participating in the network.
    /// See <see href="https://xrpl.org/rippled-server-states.html">Possible Server States</see> for more details.
    /// </summary>
    [JsonPropertyName("server_state")]
    public string ServerState { get; set; } = default!;

    /// <summary>
    /// The number of consecutive microseconds the server has been in the current state. 
    /// </summary>
    [JsonPropertyName("server_state_duration_us")]
    public string ServerStateDurationUs { get; set; } = default!;

    /// <summary>
    /// A map of various server states with information about the time the server spends in each.
    /// This can be useful for tracking the long-term health of your server's connectivity to the network.
    /// </summary>
    [JsonPropertyName("state_accounting")]
    public Dictionary<string, StateAccountingDetails> StateAccounting { get; set; } = default!;

    /// <summary>
    /// The current time in UTC, according to the server's clock. 
    /// </summary>
    [JsonPropertyName("time")]
    public string Time { get; set; } = default!;

    /// <summary>
    /// Number of consecutive seconds that the server has been operational.
    /// </summary>
    [JsonPropertyName("uptime")]
    public int Uptime { get; set; }

    /// <summary>
    /// (May be omitted) Information about the most recent fully-validated ledger.
    /// If the most recent validated ledger is not available, the response omits this field and includes closed_ledger instead.
    /// </summary>
    [JsonPropertyName("validated_ledger")]
    public ValidatedLedger? ValidatedLedger { get; set; }

    /// <summary>
    /// Minimum number of trusted validations required to validate a ledger version. Some circumstances may cause the server to require more validations.
    /// </summary>
    [JsonPropertyName("validation_quorum")]
    public int ValidationQuorum { get; set; }
}
