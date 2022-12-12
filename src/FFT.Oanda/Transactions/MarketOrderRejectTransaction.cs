// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A MarketOrderRejectTransaction represents the rejection of the creation of
  /// a Market Order.
  /// </summary>
  public sealed class MarketOrderRejectTransaction : MarketOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="MarketOrderRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public MarketOrderRejectTransaction(
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
      MarketOrderReason reason,
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
            priceBound,
            tradeClose,
            longPositionCloseout,
            shortPositionCloseout,
            marginCloseout,
            delayedTradeClose,
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
