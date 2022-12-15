// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;
using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetTrades(string, TradeStateFilter, string, int, int?, int[], CancellationToken)"/> method.
/// </summary>
public sealed record GetTradesResponse
{
  /// <summary>
  /// The list of Trade detail objects.
  /// </summary>
  public ImmutableList<Trade> Trades { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; init; }
}
