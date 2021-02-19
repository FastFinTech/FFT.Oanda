// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TrailingStopLossOrder is an order that is linked to an open Trade and
  /// created with a price distance. The price distance is used to calculate a
  /// trailing stop value for the order that is in the losing direction from the
  /// market price at the time of the order’s creation. The trailing stop value
  /// will follow the market price as it moves in the winning direction, and the
  /// order will filled (closing the Trade) by the first price that is equal to
  /// or worse than the trailing stop value. A TrailingStopLossOrder cannot be
  /// used to open a new Position.
  /// </summary>
  public sealed class TrailingStopLossOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TrailingStopLossOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public TrailingStopLossOrder(
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
      decimal distance,
      decimal? trailingStopValue)
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
      Distance = distance;
      TrailingStopValue = trailingStopValue;
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
    /// The price distance (in price units) specified for the TrailingStopLoss
    /// Order.
    /// </summary>
    public decimal Distance { get; }

    /// <summary>
    /// The trigger price for the Trailing Stop Loss Order. The trailing stop
    /// value will trail (follow) the market price by the TSL order’s configured
    /// “distance” as the market price moves in the winning direction. If the
    /// market price moves to a level that is equal to or worse than the
    /// trailing stop value, the order will be filled and the Trade will be
    /// closed.
    /// </summary>
    public decimal? TrailingStopValue { get; }
  }
}
