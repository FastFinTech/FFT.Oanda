// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System.Text.Json.Serialization;

/// <summary>
/// Details for the Market Order extensions specific to a Market Order placed
/// with the intent of fully closing a specific open trade that should have
/// already been closed but wasn’t due to halted market conditions.
/// </summary>
public sealed class MarketOrderDelayedTradeClose
{
  // TODO: Check if ClientTradeId should be made nullable

  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="MarketOrderDelayedTradeClose"/> class.
  /// </summary>
  [JsonConstructor]
  public MarketOrderDelayedTradeClose(string tradeId, string clientTradeId, string sourceTransactionId)
  {
    TradeId = tradeId;
    ClientTradeId = clientTradeId;
    SourceTransactionId = sourceTransactionId;
  }

  /// <summary>
  /// The ID of the Trade being closed.
  /// </summary>
  public string TradeId { get; }

  /// <summary>
  /// The Client ID of the Trade being closed.
  /// </summary>
  public string ClientTradeId { get; }

  /// <summary>
  /// The Transaction ID of the DelayedTradeClosure transaction to which this
  /// Delayed Trade Close belongs to.
  /// </summary>
  public string SourceTransactionId { get; }
}
