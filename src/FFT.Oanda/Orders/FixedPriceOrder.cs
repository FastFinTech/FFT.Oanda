// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Trades;

  /// <summary>
  /// A FixedPriceOrder is an order that is filled immediately upon creation
  /// using a fixed price.
  /// </summary>
  public sealed class FixedPriceOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FixedPriceOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public FixedPriceOrder(
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
      TradeState tradeState)
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
      TradeState = tradeState;
    }

    /// <summary>
    /// The quantity requested to be filled by the Fixed Price Order. A positive
    /// number of units results in a long Order, and a negative number of units
    /// results in a short Order.
    /// </summary>
    public decimal Units { get; }

    /// <summary>
    /// The price specified for the Fixed Price Order. This price is the exact
    /// price that the Fixed Price Order will be filled at.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The state that the trade resulting from the Fixed Price Order should be
    /// set to.
    /// </summary>
    public TradeState TradeState { get; }
  }
}
