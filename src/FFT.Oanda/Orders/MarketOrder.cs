// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda;

  /// <summary>
  /// A MarketOrder is an order that is filled immediately upon creation using
  /// the current market price.
  /// </summary>
  public sealed class MarketOrder : Order
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MarketOrder"/> class.
    /// </summary>
    [JsonConstructor]
    public MarketOrder(
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
      decimal priceBound,
      MarketOrderTradeClose? tradeClose,
      MarketOrderPositionCloseout? longPositionCloseout,
      MarketOrderPositionCloseout? shortPositionCloseout,
      MarketOrderMarginCloseout? marginCloseout,
      MarketOrderDelayedTradeClose? delayedTradeClose)
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
      PriceBound = priceBound;
      TradeClose = tradeClose;
      LongPositionCloseout = longPositionCloseout;
      ShortPositionCloseout = shortPositionCloseout;
      MarginCloseout = marginCloseout;
      DelayedTradeClose = delayedTradeClose;
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
    public decimal PriceBound { get; }

    /// <summary>
    /// Details of the Trade requested to be closed, only provided when the
    /// Market Order is being used to explicitly close a Trade.
    /// </summary>
    public MarketOrderTradeClose? TradeClose { get; }

    /// <summary>
    /// Details of the long Position requested to be closed out, only provided
    /// when a Market Order is being used to explicitly closeout a long
    /// Position.
    /// </summary>
    public MarketOrderPositionCloseout? LongPositionCloseout { get; }

    /// <summary>
    /// Details of the short Position requested to be closed out, only provided
    /// when a Market Order is being used to explicitly closeout a short
    /// Position.
    /// </summary>
    public MarketOrderPositionCloseout? ShortPositionCloseout { get; }

    /// <summary>
    /// Details of the Margin Closeout that this Market Order was created for.
    /// </summary>
    public MarketOrderMarginCloseout? MarginCloseout { get; }

    /// <summary>
    /// Details of the delayed Trade close that this Market Order was created
    /// for.
    /// </summary>
    public MarketOrderDelayedTradeClose? DelayedTradeClose { get; }
  }
}
