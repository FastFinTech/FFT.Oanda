// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetTransactions(string, int, int, TransactionFilter[], CancellationToken)"/>  method.
/// </summary>
public sealed record GetTransactionsResponse
{
  /// <summary>
  /// The details of the Transactions requested.
  /// </summary>
  public ImmutableList<Transaction> Transactions { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
