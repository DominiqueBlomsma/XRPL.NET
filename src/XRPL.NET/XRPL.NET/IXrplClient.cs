using XRPL.NET.Enums;
using XRPL.NET.EventArgs;
using XRPL.NET.Exceptions;
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
    Task<AccountInfoResponse> GetAccountInfo(XrplProtocol protocol, AccountInfoRequest request, CancellationToken token);

    /// <summary>
    /// The account_lines method returns information about an account's trust lines, including balances in all non-XRP currencies and assets. All information retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <returns></returns>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    /// <exception cref="AccountMarkerMalformedException">If the marker field provided is not acceptable.</exception>
    Task<AccountLinesResponse> GetAccountLines(XrplProtocol protocol, AccountLinesRequest request, CancellationToken token);

    /// <summary>
    /// The account_objects command retrieves objectsrmation about an account, its activity, and its XRP balance.
    /// All objectsrmation retrieved is relative to a particular version of the ledger.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<AccountObjectsResponse> GetAccountObjects(XrplProtocol protocol, AccountObjectsRequest request, CancellationToken token);

    /// <summary>
    /// The account_tx method retrieves a list of transactions that involved the specified account.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="AccountNotFoundException">The address specified in the account field of the request does not correspond to an account in the ledger.</exception>
    /// <exception cref="AccountMarkerMalformedException">If the marker field provided is not acceptable.</exception>
    Task<AccountTxResponse> GetAccountTransactions(XrplProtocol protocol, AccountTxRequest request, CancellationToken token);


    Task<LedgerResponse> GetLedgerAsync(XrplProtocol protocol, LedgerRequest request, CancellationToken token);

    /// <summary>
    /// The ledger_entry method returns a single ledger object from the XRP Ledger in its raw format.
    /// See <see href="https://xrpl.org/ledger-object-types.html">ledger format</see> for information on the different types of objects you can retrieve.
    /// </summary>
    /// <param name="token">The <see cref="CancellationToken">CancellationToken</see> to observe.</param>
    /// <returns></returns>
    /// <exception cref="InvalidParametersException">One or more fields are specified incorrectly, or one or more required fields are missing.</exception>
    /// <exception cref="EntryNotFoundException">The requested ledger object does not exist in the ledger.</exception>
    /// <exception cref="LedgerNotFoundException">The ledger specified by the ledger_hash or ledger_index does not exist, or it does exist but the server does not have it.</exception>
    Task<LedgerEntryResponse> GetLedgerEntryAsync(XrplProtocol protocol, LedgerEntryRequest request, CancellationToken token);
    Task<FeeResponse> GetFeeAsync(XrplProtocol protocol, FeeRequest request, CancellationToken token);
    Task<ServerDefinitionsResponse> GetServerDefinitionsAsync(XrplProtocol protocol, CancellationToken token);
    Task<ServerStateResponse> GetServerStateAsync(XrplProtocol protocol, CancellationToken token);
    Task<SubmitResponse> SubmitAsync(XrplProtocol protocol, SubmitRequest request, CancellationToken token);
    Task<TransactionResponse> TransactionAsync(XrplProtocol protocol, TransactionRequest request, CancellationToken token);

    Task SubscribeAsync(SubscribeRequest request, EventHandler<SubscriptionEventArgs> eventHandler, CancellationToken token);
}
