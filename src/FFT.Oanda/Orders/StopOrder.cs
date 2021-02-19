// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A StopOrder is an order that is created with a price threshold, and will
  /// only be filled by a price that is equal to or worse than the threshold.
  /// </summary>
  public sealed class StopOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StopOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public StopOrder(
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
      decimal priceBound)
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
    }

    /// <summary>
    /// The quantity requested to be filled by the Stop Order. A positive number
    /// of units results in a long Order, and a negative number of units results
    /// in a short Order.
    /// </summary>
    public decimal Units { get; }

    /// <summary>
    /// The price threshold specified for the Stop Order. The Stop Order will
    /// only be filled by a market price that is equal to or worse than this
    /// price.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The worst market price that may be used to fill this Stop Order. If the
    /// market gaps and crosses through both the price and the priceBound, the
    /// Stop Order will be cancelled instead of being filled.
    /// </summary>
    public decimal PriceBound { get; }
  }
}
