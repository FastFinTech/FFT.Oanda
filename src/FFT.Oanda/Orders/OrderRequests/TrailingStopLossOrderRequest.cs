// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A TrailingStopLossOrderRequest specifies the parameters that may be set
/// when creating a Trailing Stop Loss Order.
/// </summary>
public sealed record TrailingStopLossOrderRequest : CloseTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.GTC,
    TimeInForce.GFD,
    TimeInForce.GTD,
  };

  /// <inheritdoc />
  public override OrderType Type => OrderType.TRAILING_STOP_LOSS;

  /// <summary>
  /// The price distance (in price units) specified for the TrailingStopLoss
  /// Order.
  /// </summary>
  public decimal Distance { get; init; }

  /// <inheritdoc />
  protected override void CustomValidate()
  {
    ValidateTimeInForce(TimeInForce, _allowed);
  }
}
