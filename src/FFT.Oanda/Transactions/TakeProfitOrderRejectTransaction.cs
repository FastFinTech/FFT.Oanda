// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A TakeProfitOrderRejectTransaction represents the rejection of the
  /// creation of a TakeProfit Order.
  /// </summary>
  public sealed class TakeProfitOrderRejectTransaction : TakeProfitOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="TakeProfitOrderRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public TakeProfitOrderRejectTransaction(
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
      decimal price,
      OrderTriggerCondition triggerCondition,
      TakeProfitOrderReason reason,
      string? orderFillTransactionID,
      string? intendedReplacesOrderID,
      TransactionRejectReason rejectReason)
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
            clientTradeID,
            price,
            triggerCondition,
            reason,
            orderFillTransactionID)
    {
      IntendedReplacesOrderID = intendedReplacesOrderID;
      RejectReason = rejectReason;
    }

    /// <summary>
    /// The ID of the Order that this Order was intended to replace (only
    /// provided if this Order was intended to replace an existing Order).
    /// </summary>
    public string? IntendedReplacesOrderID { get; }

    /// <summary>
    /// The reason that the Reject Transaction was created.
    /// </summary>
    public TransactionRejectReason RejectReason { get; }
  }
}
