// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A MarketIfTouchedOrder is an order that is created with a price threshold,
/// and will only be filled by a market price that touches or crosses the
/// threshold.
/// </summary>
public sealed record MarketIfTouchedOrder : Order
{
  /// <summary>
  /// The quantity requested to be filled by the MarketIfTouched Order. A
  /// positive number of units results in a long Order, and a negative number
  /// of units results in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The price threshold specified for the MarketIfTouched Order. The
  /// MarketIfTouched Order will only be filled by a market price that crosses
  /// this price from the direction of the market price at the time when the
  /// Order was created (the initialMarketPrice). Depending on the value of
  /// the Order’s price and initialMarketPrice, the MarketIfTouchedOrder will
  /// behave like a Limit or a Stop Order.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The worst market price that may be used to fill this MarketIfTouched
  /// Order.
  /// </summary>
  public decimal PriceBound { get; init; }

  /// <summary>
  /// The Market price at the time when the MarketIfTouched Order was created.
  /// </summary>
  public decimal InitialMarketPrice { get; init; }
}
