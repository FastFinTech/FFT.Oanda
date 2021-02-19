// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A LimitOrderRejectTransaction represents the rejection of the creation of
  /// a Limit Order.
  /// </summary>
  public sealed class LimitOrderRejectTransaction : LimitOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="LimitOrderRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public LimitOrderRejectTransaction(
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
      string instrument,
      decimal units,
      OrderPositionFill positionFill,
      TakeProfitDetails? takeProfitOnFill,
      StopLossDetails? stopLossOnFill,
      TrailingStopLossDetails? trailingStopLossOnFill,
      GuaranteedStopLossDetails? guaranteedStopLossOnFill,
      ClientExtensions? tradeClientExtensions,
      decimal price,
      OrderTriggerCondition triggerCondition,
      LimitOrderReason reason,
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
            instrument,
            units,
            positionFill,
            takeProfitOnFill,
            stopLossOnFill,
            trailingStopLossOnFill,
            guaranteedStopLossOnFill,
            tradeClientExtensions,
            price,
            triggerCondition,
            reason)
    {
      RejectReason = rejectReason;
    }

    /// <summary>
    /// The reason that the Reject Transaction was created.
    /// </summary>
    public TransactionRejectReason RejectReason { get; }
  }
}
