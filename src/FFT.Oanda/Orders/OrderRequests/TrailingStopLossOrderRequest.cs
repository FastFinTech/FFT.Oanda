// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TrailingStopLossOrderRequest specifies the parameters that may be set
  /// when creating a Trailing Stop Loss Order.
  /// </summary>
  public sealed class TrailingStopLossOrderRequest : CloseTradeOrderRequest
  {
    private static readonly TimeInForce[] _allowed = new[]
    {
      TimeInForce.GTC,
      TimeInForce.GFD,
      TimeInForce.GTD,
    };

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="TrailingStopLossOrderRequest"/> class.
    /// </summary>
    [JsonConstructor]
    public TrailingStopLossOrderRequest(
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderTriggerCondition triggerCondition,
      ClientExtensions? clientExtensions,
      string tradeID,
      string? clientTradeID,
      decimal distance)
        : base(
            OrderType.TRAILING_STOP_LOSS,
            timeInForce,
            gtdTime,
            triggerCondition,
            clientExtensions,
            tradeID,
            clientTradeID)
    {
      ValidateTimeInForce(timeInForce, _allowed);
      Distance = distance;
    }

    /// <summary>
    /// The price distance (in price units) specified for the TrailingStopLoss
    /// Order.
    /// </summary>
    public decimal Distance { get; }
  }
}
