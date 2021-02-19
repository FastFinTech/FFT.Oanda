// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A TrailingStopLossOrderTransaction represents the creation of a
  /// TrailingStopLoss Order in the user’s Account.
  /// </summary>
  public class TrailingStopLossOrderTransaction : TradeRelatedOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="TrailingStopLossOrderTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public TrailingStopLossOrderTransaction(
      string id,
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
      string tradeID,
      string? clientTradeID,
      decimal distance,
      OrderTriggerCondition triggerCondition,
      TrailingStopLossOrderReason reason,
      string? orderFillTransactionID)
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
            tradeID,
            clientTradeID)
    {
      Distance = distance;
      TriggerCondition = triggerCondition;
      Reason = reason;
      OrderFillTransactionID = orderFillTransactionID;
    }

    /// <summary>
    /// The price distance (in price units) specified for the TrailingStopLoss
    /// Order.
    /// </summary>
    public decimal Distance { get; }

    /// <summary>
    /// Specification of which price component should be used when determining
    /// if an Order should be triggered and filled. This allows Orders to be
    /// triggered based on the bid, ask, mid, default (ask for buy, bid for
    /// sell) or inverse (ask for sell, bid for buy) price depending on the
    /// desired behaviour. Orders are always filled using their default price
    /// component. This feature is only provided through the REST API. Clients
    /// who choose to specify a non-default trigger condition will not see it
    /// reflected in any of OANDA’s proprietary or partner trading platforms,
    /// their transaction history or their account statements. OANDA platforms
    /// always assume that an Order’s trigger condition is set to the default
    /// value when indicating the distance from an Order’s trigger price, and
    /// will always provide the default trigger condition when creating or
    /// modifying an Order. A special restriction applies when creating a
    /// Guaranteed Stop Loss Order. In this case the TriggerCondition value must
    /// either be “DEFAULT”, or the“natural” trigger side “DEFAULT” results in.
    /// So for a Guaranteed Stop Loss Order for a long trade valid values are
    /// “DEFAULT” and “BID”, and for short trades “DEFAULT” and “ASK” are valid.
    /// </summary>
    public OrderTriggerCondition TriggerCondition { get; }

    /// <summary>
    /// The reason that the Trailing Stop Loss Order was initiated.
    /// </summary>
    public TrailingStopLossOrderReason Reason { get; }

    /// <summary>
    /// The ID of the OrderFill Transaction that caused this Order to be created
    /// (only provided if this Order was created automatically when another
    /// Order was filled).
    /// </summary>
    public string? OrderFillTransactionID { get; }
  }
}
