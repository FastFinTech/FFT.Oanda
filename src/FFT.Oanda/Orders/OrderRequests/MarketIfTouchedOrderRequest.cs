// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

/// <summary>
/// A MarketIfTouchedOrderRequest specifies the parameters that may be set
/// when creating a Market-if-Touched Order.
/// </summary>
public sealed record MarketIfTouchedOrderRequest : OpenTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.GTC,
    TimeInForce.GFD,
    TimeInForce.GTD,
  };

  /// <inheritdoc />
  public override OrderType Type => OrderType.MARKET_IF_TOUCHED;

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
  public decimal? PriceBound { get; init; }

  private protected override void CustomValidate2()
  {
    ValidateTimeInForce(TimeInForce, _allowed);
  }
}
