using XRPL.NET.EventArgs;
using XRPL.NET.Exceptions;
using XRPL.NET.Models;
using XRPL.NET.Models.Methods.Accounts;
using XRPL.NET.Models.Methods.Ledger;
using XRPL.NET.Models.Methods.ServerInfo;
using XRPL.NET.Models.Methods.Subscription;
using XRPL.NET.Models.Methods.Transaction;

namespace XRPL.NET;

public interface IXrplClient : IDisposable
{
    /// <summary>
    /// The account_info command retrieves information about an account, its activity, and its XRP balance. All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<AccountInfoResponse> GetAccountInfo(XrplNetworkSettings networkSettings, AccountInfoRequest request, CancellationToken token);

    /// <summary>
    /// The account_lines method returns information about an account's trust lines, including balances in all non-XRP currencies and assets. All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <returns></returns>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    /// <exception cref="AccountMarkerMalformedException">If the marker field provided is not acceptable.</exception>
    Task<AccountLinesResponse> GetAccountLines(XrplNetworkSettings networkSettings, AccountLinesRequest request, CancellationToken token);

    /// <summary>
    /// Use the account_namespace websocket API to query the Hook State Objects on a particular account in a particular namespace.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<AccountNamespaceResponse> GetAccountNamespace(XrplNetworkSettings networkSettings, AccountNamespaceRequest request, CancellationToken token);

    /// <summary>
    /// The account_objects command retrieves objects information about an account, its activity, and its XRP balance.
    /// All objects information retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<AccountObjectsResponse> GetAccountObjects(XrplNetworkSettings networkSettings, AccountObjectsRequest request, CancellationToken token);

    /// <summary>
    /// The account_tx method retrieves a list of transactions that involved the specified account.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="AccountMarkerMalformedException">If the marker field provided is not acceptable.</exception>
    Task<AccountTxResponse> GetAccountTransactions(XrplNetworkSettings networkSettings, AccountTxRequest request, CancellationToken token);


    Task<LedgerResponse> GetLedgerAsync(XrplNetworkSettings networkSettings, LedgerRequest request, CancellationToken token);

    /// <summary>
    /// The ledger_entry method returns a single ledger object from the XRP Ledger in its raw format.
    /// See <see href="https://xrpl.org/ledger-object-types.html">ledger format</see> for information on the different types of objects you can retrieve.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <returns></returns>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="EntryNotFoundException">The requested ledger object does not exist in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<LedgerEntryResponse> GetLedgerEntryAsync(XrplNetworkSettings networkSettings, LedgerEntryRequest request, CancellationToken token);
    Task<FeeResponse> GetFeeAsync(XrplNetworkSettings networkSettings, FeeRequest request, CancellationToken token);
    Task<ServerDefinitionsResponse> GetServerDefinitionsAsync(XrplNetworkSettings networkSettings, CancellationToken token);
    Task<ServerStateResponse> GetServerStateAsync(XrplNetworkSettings networkSettings, CancellationToken token);
    Task<SubmitResponse> SubmitAsync(XrplNetworkSettings networkSettings, SubmitRequest request, CancellationToken token);
    Task<TransactionResponse> TransactionAsync(XrplNetworkSettings networkSettings, TransactionRequest request, CancellationToken token);

    Task SubscribeAsync(XrplWebSocketSettings webSocketSettings, SubscribeRequest request, EventHandler<SubscriptionEventArgs> eventHandler, CancellationToken token);
}
