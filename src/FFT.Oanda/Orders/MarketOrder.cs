// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A MarketOrder is an order that is filled immediately upon creation using
/// the current market price.
/// </summary>
public sealed record MarketOrder : Order
{
  /// <summary>
  /// The quantity requested to be filled by the Market Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  public decimal Units { get; }

  /// <summary>
  /// The worst price that the client is willing to have the Market Order
  /// filled at.
  /// </summary>
  public decimal PriceBound { get; }

  /// <summary>
  /// Details of the Trade requested to be closed, only provided when the
  /// Market Order is being used to explicitly close a Trade.
  /// </summary>
  public MarketOrderTradeClose? TradeClose { get; }

  /// <summary>
  /// Details of the long Position requested to be closed out, only provided
  /// when a Market Order is being used to explicitly closeout a long
  /// Position.
  /// </summary>
  public MarketOrderPositionCloseout? LongPositionCloseout { get; }

  /// <summary>
  /// Details of the short Position requested to be closed out, only provided
  /// when a Market Order is being used to explicitly closeout a short
  /// Position.
  /// </summary>
  public MarketOrderPositionCloseout? ShortPositionCloseout { get; }

  /// <summary>
  /// Details of the Margin Closeout that this Market Order was created for.
  /// </summary>
  public MarketOrderMarginCloseout? MarginCloseout { get; }

  /// <summary>
  /// Details of the delayed Trade close that this Market Order was created
  /// for.
  /// </summary>
  public MarketOrderDelayedTradeClose? DelayedTradeClose { get; }
}
