// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

/// <summary>
/// A MarketOrderRequest specifies the parameters that may be set when
/// creating a Market Order.
/// </summary>
public sealed record MarketOrderRequest : OpenTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.FOK,
    TimeInForce.IOC,
  };

  /// <inheritdoc/>
  public override OrderType Type => OrderType.MARKET;

  /// <summary>
  /// The quantity requested to be filled by the Market Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The worst price that the client is willing to have the Market Order
  /// filled at.
  /// </summary>
  public decimal? PriceBound { get; init; }

  private protected override void CustomValidate2()
  {
    ValidateTimeInForce(TimeInForce, _allowed);
  }
}
