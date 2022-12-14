// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;
using FFT.Oanda.Orders;

/// <summary>
/// A MarketOrderTransaction represents the creation of a Market Order in the
/// user’s account. A Market Order is an Order that is filled immediately at
/// the current market price. Market Orders can be specialized when they are
/// created to accomplish a specific task: to close a Trade, to closeout a
/// Position or to participate in in a Margin closeout.
/// </summary>
public class MarketOrderTransaction : OpeningOrderTransaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="MarketOrderTransaction"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public MarketOrderTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    ClientExtensions? clientExtensions,
    string? replacesOrderID,
    string? cancellingTransactionID,
    TimeInForce timeInForce,
    DateTime? gtdTime,
    string instrument,
    decimal units,
    OrderPositionFill positionFill,
    TakeProfitDetails? takeProfitOnFill,
    StopLossDetails? stopLossOnFill,
    TrailingStopLossDetails? trailingStopLossOnFill,
    GuaranteedStopLossDetails? guaranteedStopLossOnFill,
    ClientExtensions? tradeClientExtensions,
    decimal priceBound,
    MarketOrderTradeClose? tradeClose,
    MarketOrderPositionCloseout? longPositionCloseout,
    MarketOrderPositionCloseout? shortPositionCloseout,
    MarketOrderMarginCloseout? marginCloseout,
    MarketOrderDelayedTradeClose? delayedTradeClose,
    MarketOrderReason reason)
      : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type,
          clientExtensions,
          replacesOrderID,
          cancellingTransactionID,
          timeInForce,
          gtdTime,
          instrument,
          units,
          positionFill,
          takeProfitOnFill,
          stopLossOnFill,
          trailingStopLossOnFill,
          guaranteedStopLossOnFill,
          tradeClientExtensions)
  {
    PriceBound = priceBound;
    TradeClose = tradeClose;
    LongPositionCloseout = longPositionCloseout;
    ShortPositionCloseout = shortPositionCloseout;
    MarginCloseout = marginCloseout;
    DelayedTradeClose = delayedTradeClose;
    Reason = reason;
  }

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

  /// <summary>
  /// The reason that the Market Order was created.
  /// </summary>
  public MarketOrderReason Reason { get; }
}
