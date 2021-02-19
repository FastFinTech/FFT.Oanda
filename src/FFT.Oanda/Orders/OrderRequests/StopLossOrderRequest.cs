// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A StopLossOrderRequest specifies the parameters that may be set when
  /// creating a Stop Loss Order. Only one of the price and distance fields may
  /// be specified.
  /// </summary>
  public sealed class StopLossOrderRequest : CloseTradeOrderRequest
  {
    private static readonly TimeInForce[] _allowed = new[]
    {
      TimeInForce.GTC,
      TimeInForce.GFD,
      TimeInForce.GTD,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="StopLossOrderRequest"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public StopLossOrderRequest(
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderTriggerCondition triggerCondition,
      ClientExtensions? clientExtensions,
      string tradeID,
      string? clientTradeID,
      decimal? price,
      decimal? distance)
        : base(
            OrderType.STOP_LOSS,
            timeInForce,
            gtdTime,
            triggerCondition,
            clientExtensions,
            tradeID,
            clientTradeID)
    {
      if (price is null && distance is null)
      {
        throw new ArgumentException($"Either '{nameof(price)}' or '{nameof(distance)}' must be specified.");
      }

      if (price is not null && distance is not null)
      {
        throw new ArgumentException($"'{nameof(price)}' and '{nameof(distance)}' cannot both be specified.");
      }

      ValidateTimeInForce(timeInForce, _allowed);
      Price = price;
      Distance = distance;
    }

    /// <summary>
    /// The price threshold specified for the Stop Loss Order. The associated
    /// Trade will be closed by a market price that is equal to or worse than
    /// this threshold.
    /// </summary>
    public decimal? Price { get; }

    /// <summary>
    /// Specifies the distance (in price units) from the Account’s current price
    /// to use as the Stop Loss Order price. If the Trade is short the
    /// Instrument’s bid price is used, and for long Trades the ask is used.
    /// </summary>
    public decimal? Distance { get; }
  }
}
