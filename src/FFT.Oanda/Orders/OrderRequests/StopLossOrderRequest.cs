// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A StopLossOrderRequest specifies the parameters that may be set when
/// creating a Stop Loss Order. Only one of the price and distance fields may
/// be specified.
/// </summary>
public sealed record StopLossOrderRequest : CloseTradeOrderRequest
{
  private static readonly TimeInForce[] _allowed = new[]
  {
    TimeInForce.GTC,
    TimeInForce.GFD,
    TimeInForce.GTD,
  };

  public override OrderType Type => OrderType.STOP_LOSS;

  /// <inheritdoc />
  protected override void CustomValidate()
  {
    if (Price is null && Distance is null)
    {
      throw new ArgumentException($"Either '{nameof(Price)}' or '{nameof(Distance)}' must be specified.");
    }

    if (Price is not null && Distance is not null)
    {
      throw new ArgumentException($"'{nameof(Price)}' and '{nameof(Distance)}' cannot both be specified.");
    }

    ValidateTimeInForce(TimeInForce, _allowed);
  }

  /// <summary>
  /// The price threshold specified for the Stop Loss Order. The associated
  /// Trade will be closed by a market price that is equal to or worse than
  /// this threshold.
  /// </summary>
  public decimal? Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Account’s current price
  /// to use as the Stop Loss Order price. If the Trade is short the
  /// Instrument’s bid price is used, and for long Trades the ask is used.
  /// </summary>
  public decimal? Distance { get; init; }
}
