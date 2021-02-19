// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TakeProfitOrder is an order that is linked to an open Trade and created
  /// with a price threshold. The Order will be filled (closing the Trade) by
  /// the first price that is equal to or better than the threshold. A
  /// TakeProfitOrder cannot be used to open a new Position.
  /// </summary>
  public sealed class TakeProfitOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TakeProfitOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public TakeProfitOrder(
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
      string tradeID,
      string? clientTradeID,
      decimal price)
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
      TradeID = tradeID;
      ClientTradeID = clientTradeID;
      Price = price;
    }

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
    /// The price threshold specified for the TakeProfit Order. The associated
    /// Trade will be closed by a market price that is equal to or better than
    /// this threshold.
    /// </summary>
    public decimal Price { get; }
  }
}
