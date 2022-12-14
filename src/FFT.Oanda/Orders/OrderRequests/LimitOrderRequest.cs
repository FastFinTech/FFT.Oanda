// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;
/// <summary>
/// A LimitOrderRequest specifies the parameters that may be set when creating
/// a Limit Order.
/// </summary>
public sealed record LimitOrderRequest : OpenTradeOrderRequest
{
  public override OrderType Type => OrderType.LIMIT;

  /// <inheritdoc />
  protected override void CustomValidate2() { }

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
