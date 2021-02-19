// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A MarketIfTouchedOrderRequest specifies the parameters that may be set
  /// when creating a Market-if-Touched Order.
  /// </summary>
  public sealed class MarketIfTouchedOrderRequest : OpenTradeOrderRequest
  {
    private static readonly TimeInForce[] _allowed = new[]
    {
      TimeInForce.GTC,
      TimeInForce.GFD,
      TimeInForce.GTD,
    };

    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="MarketIfTouchedOrderRequest"/> class.
    /// </summary>
    [JsonConstructor]
    public MarketIfTouchedOrderRequest(
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
      decimal price,
      decimal? priceBound)
        : base(
            OrderType.MARKET_IF_TOUCHED,
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
      Price = price;
      PriceBound = priceBound;
    }

    /// <summary>
    /// The price threshold specified for the MarketIfTouched Order. The
    /// MarketIfTouched Order will only be filled by a market price that crosses
    /// this price from the direction of the market price at the time when the
    /// Order was created (the initialMarketPrice). Depending on the value of
    /// the Order’s price and initialMarketPrice, the MarketIfTouchedOrder will
    /// behave like a Limit or a Stop Order.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The worst market price that may be used to fill this MarketIfTouched
    /// Order.
    /// </summary>
    public decimal? PriceBound { get; }
  }
}
