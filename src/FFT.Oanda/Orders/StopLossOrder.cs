// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A StopLossOrder is an order that is linked to an open Trade and created
  /// with a price threshold. The Order will be filled (closing the Trade) by
  /// the first price that is equal to or worse than the threshold. A
  /// StopLossOrder cannot be used to open a new Position.
  /// </summary>
  public sealed class StopLossOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StopLossOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public StopLossOrder(
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
      TradeID = tradeID;
      ClientTradeID = clientTradeID;
      Price = price;
      Distance = distance;
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
    /// The price threshold specified for the Stop Loss Order. The associated
    /// Trade will be closed by a market price that is equal to or worse than
    /// this threshold.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// Specifies the distance (in price units) from the Account’s current price
    /// to use as the Stop Loss Order price. If the Trade is short the
    /// Instrument’s bid price is used, and for long Trades the ask is used.
    /// </summary>
    public decimal? Distance { get; }
  }
}
