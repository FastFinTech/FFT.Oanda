// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A StopOrder is an order that is created with a price threshold, and will
/// only be filled by a price that is equal to or worse than the threshold.
/// </summary>
public sealed record StopOrder : Order
{
  /// <summary>
  /// The quantity requested to be filled by the Stop Order. A positive number
  /// of units results in a long Order, and a negative number of units results
  /// in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The price threshold specified for the Stop Order. The Stop Order will
  /// only be filled by a market price that is equal to or worse than this
  /// price.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The worst market price that may be used to fill this Stop Order. If the
  /// market gaps and crosses through both the price and the priceBound, the
  /// Stop Order will be cancelled instead of being filled.
  /// </summary>
  public decimal PriceBound { get; init; }
}
