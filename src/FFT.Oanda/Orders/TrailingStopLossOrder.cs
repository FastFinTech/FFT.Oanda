// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
/// <summary>
/// A TrailingStopLossOrder is an order that is linked to an open Trade and
/// created with a price distance. The price distance is used to calculate a
/// trailing stop value for the order that is in the losing direction from the
/// market price at the time of the order’s creation. The trailing stop value
/// will follow the market price as it moves in the winning direction, and the
/// order will filled (closing the Trade) by the first price that is equal to
/// or worse than the trailing stop value. A TrailingStopLossOrder cannot be
/// used to open a new Position.
/// </summary>
public sealed record TrailingStopLossOrder : Order
{
  /// <summary>
  /// The ID of the Trade to close when the price threshold is breached.
  /// </summary>
  public string TradeID { get; init; }

  /// <summary>
  /// The client ID of the Trade to be closed when the price threshold is
  /// breached.
  /// </summary>
  public string? ClientTradeID { get; init; }

  /// <summary>
  /// The price distance (in price units) specified for the TrailingStopLoss
  /// Order.
  /// </summary>
  public decimal Distance { get; init; }

  /// <summary>
  /// The trigger price for the Trailing Stop Loss Order. The trailing stop
  /// value will trail (follow) the market price by the TSL order’s configured
  /// “distance” as the market price moves in the winning direction. If the
  /// market price moves to a level that is equal to or worse than the
  /// trailing stop value, the order will be filled and the Trade will be
  /// closed.
  /// </summary>
  public decimal? TrailingStopValue { get; init; }
}
