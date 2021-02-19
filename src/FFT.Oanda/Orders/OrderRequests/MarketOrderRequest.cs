// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A MarketOrderRequest specifies the parameters that may be set when
  /// creating a Market Order.
  /// </summary>
  public sealed class MarketOrderRequest : OpenTradeOrderRequest
  {
    private static readonly TimeInForce[] _allowed = new[]
    {
      TimeInForce.FOK,
      TimeInForce.IOC,
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="MarketOrderRequest"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public MarketOrderRequest(
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
      decimal? priceBound)
        : base(
            OrderType.MARKET,
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
      ValidateTimeInForce(timeInForce, _allowed);
      Units = units;
      PriceBound = priceBound;
    }

    /// <summary>
    /// The quantity requested to be filled by the Market Order. A positive
    /// number of units results in a long Order, and a negative number of units
    /// results in a short Order.
    /// </summary>
    public decimal Units { get; }

    /// <summary>
    /// The worst price that the client is willing to have the Market Order
    /// filled at.
    /// </summary>
    public decimal? PriceBound { get; }
  }
}
