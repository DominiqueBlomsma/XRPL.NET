using System.Collections.Concurrent;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using XRPL.NET.BinaryCodec.Converters;
using XRPL.NET.Configs;
using XRPL.NET.Enums;
using XRPL.NET.EventArgs;
using XRPL.NET.Exceptions;
using XRPL.NET.Helpers;
using XRPL.NET.Models.Methods.Accounts;
using XRPL.NET.Models.Methods.Ledger;
using XRPL.NET.Models.Methods.ServerInfo;
using XRPL.NET.Models.Methods.Subscription;
using XRPL.NET.Models.Methods.Transaction;
using XRPL.NET.Protocols;
using XRPL.NET.Protocols.JsonRpc;
using XRPL.NET.Protocols.WebSocket;

namespace XRPL.NET;

public class XrplClient : IXrplClient
{
    private readonly XrplClientConfig _config;
    private readonly ILogger<XrplClient> _logger;

    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly ConcurrentDictionary<XrplProtocol, IXrplProtocolClient> _clients = new();

    public XrplClient(
        IOptions<XrplClientConfig> options,
        ILogger<XrplClient> logger)
    {
        _logger = logger;
        _config = options.Value;
    }

    #region Account Methods

    /// <inheritdoc />
    public async Task<AccountInfoResponse> GetAccountInfo(XrplProtocol protocol, AccountInfoRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<AccountInfoResponse>(protocol, "account_info", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve account info with request {@Request}.", request);

            switch (ex.Error)
            {
                case "invalidParams":
                    throw new InvalidParametersException(ex);
                case "actNotFound":
                    throw new AccountNotFoundException(request.Account, ex);
                case "lgrNotFound":
                    throw new LedgerNotFoundException(request.Ledger!, ex);
                default:
                    throw;
            }
        }
    }

    /// <inheritdoc />
    public async Task<AccountLinesResponse> GetAccountLines(XrplProtocol protocol, AccountLinesRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<AccountLinesResponse>(protocol, "account_lines", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve account lines with request {@Request}.", request);

            switch (ex.Error)
            {
                case "invalidParams":
                    throw new InvalidParametersException(ex);
                case "actNotFound":
                    throw new AccountNotFoundException(request.Account, ex);
                case "lgrNotFound":
                    throw new LedgerNotFoundException(request.Ledger!, ex);
                case "actMalformed":
                    throw new AccountMarkerMalformedException(request.Account, ex);
                default:
                    throw;
            }
        }
    }

    /// <inheritdoc />
    public async Task<AccountObjectsResponse> GetAccountObjects(XrplProtocol protocol, AccountObjectsRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<AccountObjectsResponse>(protocol, "account_objects", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve account objects with request {@Request}.", request);

            switch (ex.Error)
            {
                case "invalidParams":
                    throw new InvalidParametersException(ex);
                case "actNotFound":
                    throw new AccountNotFoundException(request.Account, ex);
                case "lgrNotFound":
                    throw new LedgerNotFoundException(request.Ledger!, ex);
                default:
                    throw;
            }
        }
    }

    /// <inheritdoc />
    public async Task<AccountTxResponse> GetAccountTransactions(XrplProtocol protocol, AccountTxRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<AccountTxResponse>(protocol, "account_tx", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve account transactions with request {@Request}.", request);

            switch (ex.Error)
            {
                case "invalidParams":
                    throw new InvalidParametersException(ex);
                case "actNotFound":
                    throw new AccountNotFoundException(request.Account, ex);
                case "actMalformed":
                    throw new AccountMarkerMalformedException(request.Account, ex);
                default:
                    throw;
            }
        }
    }

    #endregion

    #region Ledger Methods

    /// <inheritdoc />
    public async Task<LedgerResponse> GetLedgerAsync(XrplProtocol protocol, LedgerRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<LedgerResponse>(protocol, "ledger", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve ledger with request {@Request}.", request);

            // TODO: Add all possible errors
            throw;
        }
    }

    /// <inheritdoc />
    public async Task<LedgerEntryResponse> GetLedgerEntryAsync(XrplProtocol protocol, LedgerEntryRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<LedgerEntryResponse>(protocol, "ledger_entry", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve ledger entry with request {@Request}.", request);

            // TODO: Add all possible errors
            switch (ex.Error)
            {
                case "invalidParams":
                    throw new InvalidParametersException(ex);
                case "entryNotFound":
                    throw new EntryNotFoundException(ex);
                case "lgrNotFound":
                    throw new LedgerNotFoundException(request.Ledger!, ex);
                default:
                    throw;
            }
        }
    }

    #endregion

    #region Transaction Methods

    public async Task<SubmitResponse> SubmitAsync(XrplProtocol protocol, SubmitRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<SubmitResponse>(protocol, "submit", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to submit transaction request {@Request}.", request);

            // TODO: Add all Universal errors
            throw;
        }
    }

    public async Task<TransactionResponse> TransactionAsync(XrplProtocol protocol, TransactionRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<TransactionResponse>(protocol, "tx", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve transaction of request {@Request}.", request);

            // TODO: Add all Universal errors
            throw;
        }
    }

    #endregion

    #region Server Info Methods

    public async Task<FeeResponse> GetFeeAsync(XrplProtocol protocol, FeeRequest request, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<FeeResponse>(protocol, "fee", request, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to retrieve fee with request {@Request}.", request);

            // TODO: Add all Universal errors
            throw;
        }
    }

    public async Task<ServerDefinitionsResponse> GetServerDefinitionsAsync(XrplProtocol protocol, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<ServerDefinitionsResponse>(protocol, "server_definitions", default, token, new JsonSerializerOptions
            {
                Converters = { new FieldElementConverter() }
            });
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to get server definitions.");

            // TODO: Add all Universal errors
            throw;
        }
    }

    public async Task<ServerStateResponse> GetServerStateAsync(XrplProtocol protocol, CancellationToken token)
    {
        try
        {
            return await GetResponseAsync<ServerStateResponse>(protocol, "server_state", default, token);
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to get server state.");

            // TODO: Add all Universal errors
            throw;
        }
    }

    #endregion

    #region Subscription Methods

    public async Task SubscribeAsync(SubscribeRequest request, EventHandler<SubscriptionEventArgs> eventHandler, CancellationToken token)
    {
        try
        {
            var linked = GetLinkedCancellationToken(token);
            using var client = new WebSocketListenerClient(_config.WebSocketUri, _cancellationTokenSource, _logger);
            await foreach (var message in client.GetResponses("subscribe", request, linked).WithCancellation(linked))
            {
                eventHandler(this,
                    new SubscriptionEventArgs
                    {
                        Response = message
                    });
            }

            await client.CloseAsync();
        }
        catch (XrplException ex)
        {
            _logger.LogTrace(ex, "Failed to subscribe with request {@Request}.", request);

            // TODO: Add all Universal errors
            throw;
        }
    }

    #endregion

    private CancellationToken GetLinkedCancellationToken(CancellationToken? token)
    {
        var source = token.HasValue ? CancellationTokenSource.CreateLinkedTokenSource(_cancellationTokenSource.Token, token.Value) : _cancellationTokenSource;
        return source.Token;
    }

    private async Task<T> GetResponseAsync<T>(XrplProtocol protocol, string command, object? request, CancellationToken? token, JsonSerializerOptions? options = null) where T : class
    {
        var client = GetClient(protocol);
        var linked = GetLinkedCancellationToken(token);
        options ??= XrplJsonHelper.SerializerOptions;

        return await client.GetResponse<T>(command, request, options, linked);
    }

    private IXrplProtocolClient GetClient(XrplProtocol protocol)
    {
        if (!_clients.TryGetValue(protocol, out var client))
        {
            // TODO: Config URL validations
            client = protocol switch
            {
                XrplProtocol.JsonRpc => new JsonRpcClient(_config.JsonRpcUri, _logger),
                XrplProtocol.WebSocket => new WebSocketClient(_config.WebSocketUri, _cancellationTokenSource, _logger),
                _ => throw new ArgumentOutOfRangeException(nameof(protocol), protocol, $"Unknown XRPL protocol: {protocol}")
            };

            _clients.TryAdd(protocol, client);
        }

        return client;
    }

    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
        foreach (var protocol in _clients.Keys)
        {
            if (_clients.TryRemove(protocol, out var client))
            {
                client.Dispose();
            }
        }

        GC.SuppressFinalize(this);
    }
}
