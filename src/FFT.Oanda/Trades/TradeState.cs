// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;

/// <summary>
/// The current state of the trade.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TradeState
{
  /// <summary>
  /// The trade is currently open.
  /// </summary>
  OPEN,

  /// <summary>
  /// The trade has been fully closed.
  /// </summary>
  CLOSED,

  /// <summary>
  /// The trade will be closed as soon as the trade’s instrument becomes
  /// tradeable.
  /// </summary>
  CLOSE_WHEN_TRADEABLE,
}
