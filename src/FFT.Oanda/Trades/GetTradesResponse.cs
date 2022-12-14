// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;

using FFT.Oanda.JsonConverters;

/// <summary>
/// Returned by the <see cref="OandaApiClient.GetTrades(string, TradeStateFilter, string, int, int?, int[], CancellationToken)"/> method.
/// </summary>
public sealed class GetTradesResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="GetTradesResponse"/> class.
  /// </summary>
  [JsonConstructor]
  public GetTradesResponse(
    ImmutableList<Trade> trades,
    int lastTransactionID)
  {
    Trades = trades;
    LastTransactionID = lastTransactionID;
  }

  /// <summary>
  /// The list of Trade detail objects.
  /// </summary>
  public ImmutableList<Trade> Trades { get; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }
}
