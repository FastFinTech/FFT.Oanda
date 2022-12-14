// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;
/// <summary>
/// A TakeProfitOrderRequest specifies the parameters that may be set when
/// creating a Take Profit Order.
/// </summary>
public sealed record TakeProfitOrderRequest : CloseTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.GTC,
    TimeInForce.GFD,
    TimeInForce.GTD,
  };

  /// <inheritdoc />
  public override OrderType Type => OrderType.TAKE_PROFIT;

  /// <inheritdoc />
  protected override void CustomValidate()
  {
    ValidateTimeInForce(TimeInForce, _allowed);
  }

  /// <summary>
  /// The price threshold specified for the TakeProfit Order. The associated
  /// Trade will be closed by a market price that is equal to or better than
  /// this threshold.
  /// </summary>
  public decimal Price { get; init; }
}
