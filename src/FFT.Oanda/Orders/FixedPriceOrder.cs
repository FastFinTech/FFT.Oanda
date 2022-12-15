// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
using FFT.Oanda.Trades;

/// <summary>
/// A FixedPriceOrder is an order that is filled immediately upon creation
/// using a fixed price.
/// </summary>
public sealed record FixedPriceOrder : Order
{
  /// <summary>
  /// The quantity requested to be filled by the Fixed Price Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The price specified for the Fixed Price Order. This price is the exact
  /// price that the Fixed Price Order will be filled at.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The state that the trade resulting from the Fixed Price Order should be
  /// set to.
  /// </summary>
  public TradeState TradeState { get; init; }
}
