// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
/// <summary>
/// A StopLossOrder is an order that is linked to an open Trade and created
/// with a price threshold. The Order will be filled (closing the Trade) by
/// the first price that is equal to or worse than the threshold. A
/// StopLossOrder cannot be used to open a new Position.
/// </summary>
public sealed record StopLossOrder : Order
{
  /// <summary>
  /// The ID of the Trade to close when the price threshold is breached.
  /// </summary>
  public int TradeID { get; init; }

  /// <summary>
  /// The client ID of the Trade to be closed when the price threshold is
  /// breached.
  /// </summary>
  public string? ClientTradeID { get; init; }

  /// <summary>
  /// The price threshold specified for the Stop Loss Order. The associated
  /// Trade will be closed by a market price that is equal to or worse than
  /// this threshold.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Account’s current price
  /// to use as the Stop Loss Order price. If the Trade is short the
  /// Instrument’s bid price is used, and for long Trades the ask is used.
  /// </summary>
  public decimal? Distance { get; init; }
}
