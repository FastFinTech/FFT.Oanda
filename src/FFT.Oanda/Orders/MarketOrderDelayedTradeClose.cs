// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// Details for the Market Order extensions specific to a Market Order placed
/// with the intent of fully closing a specific open trade that should have
/// already been closed but wasn’t due to halted market conditions.
/// </summary>
public sealed record MarketOrderDelayedTradeClose
{
  /// <summary>
  /// The ID of the Trade being closed.
  /// </summary>
  public int TradeId { get; init; }

  /// <summary>
  /// The Client ID of the Trade being closed.
  /// </summary>
  public string? ClientTradeId { get; init; }

  /// <summary>
  /// The Transaction ID of the DelayedTradeClosure transaction to which this
  /// Delayed Trade Close belongs to.
  /// </summary>
  public int SourceTransactionId { get; init; }
}
