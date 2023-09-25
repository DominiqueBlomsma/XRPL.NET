# XRPL.NET
A .NET library to interact with the XRP Ledger using WebSockets and JSON RPC.

🚧 Notice: This library is currently under active development. As of now, it provides a foundational set of features and functionalities. 

To help you navigate through the library's current capabilities, I've provided a table below. 
Features that have already been implemented are marked with a ✅ checkmark.

## Public API Methods

### Account methods
An account in the XRP Ledger represents a holder of XRP and a sender of transactions. Use these methods to work with account info.

|  | API Call           | Description                                                                                       |
|---|--------------------|---------------------------------------------------------------------------------------------------|
|   | account_channels   | Get a list of payment channels where the account is the source of the channel.                    |
|   | account_currencies | Get a list of currencies an account can send or receive.                                          |
|✅| account_info       | Get basic data about an account.                                                                  |
|✅| account_lines      | Get info about an account's trust lines.                                                          |
|✅| account_namespace    | Get the Hook State Objects on a particular account in a particular namespace.                  |
|   | account_nfts       | Get a list of all NFTs for an account.                                                            |
|✅| account_objects    | Get all ledger objects owned by an account.                                                       |
|   | account_offers     | Get info about an account's currency exchange offers.                                            |
|✅| account_tx         | Get info about an account's transactions.                                                         |
|   | gateway_balances   | Calculate total amounts issued by an account.                                                     |
|   | noripple_check     | Get recommended changes to an account's Default Ripple and No Ripple settings.                    |


### Ledger Methods
A ledger version contains a header, a transaction tree, and a state tree, which contain account settings, trustlines, balances, transactions, and other data. Use these methods to retrieve ledger info.

|  | API Call         | Description                                                          |
|---|------------------|----------------------------------------------------------------------|
|✅| ledger           | Get info about a ledger version.                                     |
|   | ledger_closed    | Get the latest closed ledger version.                                |
|   | ledger_current   | Get the current working ledger version.                              |
|   | ledger_data      | Get the raw contents of a ledger version.                            |
|✅| ledger_entry     | Get one element from a ledger version.                               |

### Transaction Methods
Transactions are the only thing that can modify the shared state of the XRP Ledger. All business on the XRP Ledger takes the form of transactions. Use these methods to work with transactions.

|   | API Call           | Description                                                                          |
|---|--------------------|--------------------------------------------------------------------------------------|
|✅| submit             | Send a transaction to the network.                                                   |
|   | submit_multisigned | Send a multi-signed transaction to the network.                                       |
|   | transaction_entry  | Retrieve info about a transaction from a particular ledger version.                   |
|✅| tx                 | Retrieve info about a transaction from all the ledgers on hand.                       |
|   | tx_history         | Retrieve info about all recent transactions.                                         |

### Path and Order Book Methods
Paths define a way for payments to flow through intermediary steps on their way from sender to receiver. Paths enable cross-currency payments by connecting sender and receiver through order books. Use these methods to work with paths and other books.

|| API Call           | Description                                                                                     |
|---|--------------------|-------------------------------------------------------------------------------------------------|
|   | amm_info           | Get info about an Automated Market Maker (AMM) instance.                                       |
|   | book_offers        | Get info about offers to exchange two currencies.                                              |
|   | deposit_authorized | Check whether an account is authorized to send money directly to another.                       |
|   | nft_buy_offers     | Get a list of all buy offers for a NFToken.                                                    |
|   | nft_sell_offers    | Get a list of all sell offers for a NFToken.                                                   |
|   | path_find          | Find a path for a payment between two accounts and receive updates.                            |
|   | ripple_path_find   | Find a path for payment between two accounts, once.                                            |

### Payment Channel Methods
Payment channels are a tool for facilitating repeated, unidirectional payments, or temporary credit between two parties. Use these methods to work with payment channels.

|   | API Call           | Description                                                                       |
|---|--------------------|-----------------------------------------------------------------------------------|
|   | channel_authorize  | Sign a claim for money from a payment channel.                                    |
|   | channel_verify     | Check a payment channel claim's signature.                                        |

### Subscription Methods
Use these methods to enable the server to push updates to your client when various events happen, so that you can know and react right away. WebSocket API only.

|   | API Call     | Description                                                           |
|---|--------------|-----------------------------------------------------------------------|
|✅| subscribe    | Listen for updates about a particular subject.                        |
|   | unsubscribe  | Stop listening for updates about a particular subject.                |

### Server Info Methods
Use these methods to retrieve information about the current state of the rippled server.

|   | API Call            | Description                                                                    |
|---|---------------------|--------------------------------------------------------------------------------|
|✅| fee                 | Get information about transaction cost.                                         |
|   | manifest            | Look up the public information about a known validator.                        |
|✅| server_definitions  | Retrieve dynamic server definitions for serializing XRP Ledger data to its binary format and deserializing it from binary.                      |
|   | server_info (rippled)| Retrieve status of the server in human-readable format.                        |
|✅| server_state        | Retrieve status of the server in machine-readable format.                      |

### Utility Methods
Use these methods to perform convenient tasks, such as ping and random number generation.

|   | API Call | Description                                         |
|---|----------|-----------------------------------------------------|
|   | json     | Pass JSON through the commandline.                  |
|   | ping     | Confirm connectivity with the server.               |
|   | random   | Generate a random number.                           |
