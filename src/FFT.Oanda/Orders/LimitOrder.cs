// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A LimitOrder is an order that is created with a price threshold, and will
/// only be filled by a price that is equal to or better than the threshold.
/// </summary>
public sealed record LimitOrder : Order
{
  /// <summary>
  /// The quantity requested to be filled by the Limit Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The price threshold specified for the Limit Order. The Limit Order will
  /// only be filled by a market price that is equal to or better than this
  /// price.
  /// </summary>
  public decimal Price { get; init; }
}
