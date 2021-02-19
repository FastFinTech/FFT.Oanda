// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A LimitOrderRequest specifies the parameters that may be set when creating
  /// a Limit Order.
  /// </summary>
  public sealed class LimitOrderRequest : OpenTradeOrderRequest
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LimitOrderRequest"/> class.
    /// </summary>
    [JsonConstructor]
    public LimitOrderRequest(
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderTriggerCondition triggerCondition,
      ClientExtensions? clientExtensions,
      string instrument,
      OrderPositionFill positionFill,
      TakeProfitDetails? takeProfitOnFill,
      StopLossDetails? stopLossOnFill,
      GuaranteedStopLossDetails? guaranteedStopLossOnFill,
      TrailingStopLossDetails? trailingStopLossOnFill,
      ClientExtensions? tradeClientExtensions,
      decimal units,
      decimal price)
        : base(
            OrderType.LIMIT,
            timeInForce,
            gtdTime,
            triggerCondition,
            clientExtensions,
            instrument,
            positionFill,
            takeProfitOnFill,
            stopLossOnFill,
            guaranteedStopLossOnFill,
            trailingStopLossOnFill,
            tradeClientExtensions)
    {
      Units = units;
      Price = price;
    }

    /// <summary>
    /// The quantity requested to be filled by the Limit Order. A positive
    /// number of units results in a long Order, and a negative number of units
    /// results in a short Order.
    /// </summary>
    public decimal Units { get; }

    /// <summary>
    /// The price threshold specified for the Limit Order. The Limit Order will
    /// only be filled by a market price that is equal to or better than this
    /// price.
    /// </summary>
    public decimal Price { get; }
  }
}
