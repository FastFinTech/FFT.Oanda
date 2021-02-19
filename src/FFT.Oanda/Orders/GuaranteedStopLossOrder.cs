// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A GuaranteedStopLossOrder is an order that is linked to an open Trade and
  /// created with a price threshold which is guaranteed against slippage that
  /// may occur as the market crosses the price set for that order. The Order
  /// will be filled (closing the Trade) by the first price that is equal to or
  /// worse than the threshold. The price level specified for the
  /// GuaranteedStopLossOrder must be at least the configured minimum distance
  /// (in price units) away from the entry price for the traded instrument. A
  /// GuaranteedStopLossOrder cannot be used to open a new Position.
  /// </summary>
  public sealed class GuaranteedStopLossOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GuaranteedStopLossOrder"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GuaranteedStopLossOrder(
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
      decimal guaranteedExecutionPremium,
      string tradeID,
      string? clientTradeID,
      decimal price,
      decimal? distance)
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
      GuaranteedExecutionPremium = guaranteedExecutionPremium;
      TradeID = tradeID;
      ClientTradeID = clientTradeID;
      Price = price;
      Distance = distance;
    }

    /// <summary>
    /// The premium that will be charged if the Guaranteed Stop Loss Order is
    /// filled at the guaranteed price. It is in price units and is charged for
    /// each unit of the Trade.
    /// </summary>
    public decimal GuaranteedExecutionPremium { get; }

    /// <summary>
    /// The ID of the Trade to close when the price threshold is breached.
    /// </summary>
    public string TradeID { get; }

    /// <summary>
    /// The client ID of the Trade to be closed when the price threshold is
    /// breached.
    /// </summary>
    public string? ClientTradeID { get; }

    /// <summary>
    /// The price threshold specified for the Guaranteed Stop Loss Order. The
    /// associated Trade will be closed at this price.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Specifies the distance (in price units) from the Account’s current price
    /// to use as the Guaranteed Stop Loss Order price. If the Trade is short
    /// the Instrument’s bid price is used, and for long Trades the ask is used.
    /// </summary>
    public decimal? Distance { get; }
  }
}
