// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A MarketIfTouchedOrder is an order that is created with a price threshold,
  /// and will only be filled by a market price that touches or crosses the
  /// threshold.
  /// </summary>
  public sealed class MarketIfTouchedOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketIfTouchedOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public MarketIfTouchedOrder(
      string id,
      DateTime createTime,
      OrderState state,
      ClientExtensions? clientExtensions,
      OrderType type,
      string instrument,
      TimeInForce timeInForce,
      DateTime? gtdTime,
      OrderPositionFill positionFill,
      OrderTriggerCondition triggerCondition,
      TakeProfitDetails? takeProfitOnFill,
      StopLossDetails? stopLossOnFill,
      GuaranteedStopLossDetails? guaranteedStopLossOnFill,
      TrailingStopLossDetails? trailingStopLossOnFill,
      ClientExtensions? tradeClientExtensions,
      string? fillingTransactionID,
      DateTime? filledTime,
      string? tradeOpenedID,
      string? tradeReducedID,
      ImmutableList<string>? tradeClosedIDs,
      string? cancellingTransactionID,
      DateTime? cancelledTime,
      string? replacesOrderID,
      string? replacedByOrderID,
      decimal units,
      decimal price,
      decimal priceBound,
      decimal initialMarketPrice)
      : base(
          id,
          createTime,
          state,
          clientExtensions,
          type,
          instrument,
          timeInForce,
          gtdTime,
          positionFill,
          triggerCondition,
          takeProfitOnFill,
          stopLossOnFill,
          guaranteedStopLossOnFill,
          trailingStopLossOnFill,
          tradeClientExtensions,
          fillingTransactionID,
          filledTime,
          tradeOpenedID,
          tradeReducedID,
          tradeClosedIDs,
          cancellingTransactionID,
          cancelledTime,
          replacesOrderID,
          replacedByOrderID)
    {
      Units = units;
      Price = price;
      PriceBound = priceBound;
      InitialMarketPrice = initialMarketPrice;
    }

    /// <summary>
    /// The quantity requested to be filled by the MarketIfTouched Order. A
    /// positive number of units results in a long Order, and a negative number
    /// of units results in a short Order.
    /// </summary>
    public decimal Units { get; }

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
    public decimal PriceBound { get; }

    /// <summary>
    /// The Market price at the time when the MarketIfTouched Order was created.
    /// </summary>
    public decimal InitialMarketPrice { get; }
  }
}
