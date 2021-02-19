// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A GuaranteedStopLossOrderRejectTransaction represents the rejection of the
  /// creation of a GuaranteedStopLoss Order.
  /// </summary>
  public sealed class GuaranteedStopLossOrderRejectTransaction : GuaranteedStopLossOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="GuaranteedStopLossOrderRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public GuaranteedStopLossOrderRejectTransaction(
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
      decimal? distance,
      OrderTriggerCondition triggerCondition,
      decimal? guaranteedExecutionPremium,
      GuaranteedStopLossOrderReason reason,
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
            distance,
            triggerCondition,
            guaranteedExecutionPremium,
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
