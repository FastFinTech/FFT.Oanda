// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;
using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetTrade(string, string, CancellationToken)"/>
/// method.
/// </summary>
public sealed record GetTradeResponse
{
  /// <summary>
  /// The details of the requested trade.
  /// </summary>
  public Trade Trade { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
