// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTransactions(string, int,
  /// int, TransactionFilter)"/>
  /// method.
  /// </summary>
  public sealed class GetTransactionsResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransactionsResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GetTransactionsResponse(
      ImmutableList<Transaction> transactions,
      string lastTransactionId)
    {
      Transactions = transactions;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The details of the Transactions requested.
    /// </summary>
    public ImmutableList<Transaction> Transactions { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionId { get; }
  }
}
