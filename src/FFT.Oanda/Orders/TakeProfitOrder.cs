// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
/// <summary>
/// A TakeProfitOrder is an order that is linked to an open Trade and created
/// with a price threshold. The Order will be filled (closing the Trade) by
/// the first price that is equal to or better than the threshold. A
/// TakeProfitOrder cannot be used to open a new Position.
/// </summary>
public sealed record TakeProfitOrder : Order
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
  /// The price threshold specified for the TakeProfit Order. The associated
  /// Trade will be closed by a market price that is equal to or better than
  /// this threshold.
  /// </summary>
  public decimal Price { get; init; }
}
