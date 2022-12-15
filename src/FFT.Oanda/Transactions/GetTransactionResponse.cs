// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetTransaction(string, string, CancellationToken)"/>
/// method.
/// </summary>
public sealed record GetTransactionResponse
{
  /// <summary>
  /// The details of the Transaction requested.
  /// </summary>
  public Transaction Transaction { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
