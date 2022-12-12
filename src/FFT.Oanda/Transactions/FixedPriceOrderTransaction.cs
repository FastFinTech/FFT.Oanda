// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;
  using FFT.Oanda.Trades;

  /// <summary>
  /// A FixedPriceOrderTransaction represents the creation of a Fixed Price
  /// Order in the user’s account. A Fixed Price Order is an Order that is
  /// filled immediately at a specified price.
  /// </summary>
  public sealed class FixedPriceOrderTransaction : OpeningOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FixedPriceOrderTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public FixedPriceOrderTransaction(
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
      decimal price,
      TradeState tradeState,
      FixedPriceOrderReason reason)
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
      Price = price;
      TradeState = tradeState;
      Reason = reason;
    }

    /// <summary>
    /// The price specified for the Fixed Price Order. This price is the exact
    /// price that the Fixed Price Order will be filled at.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The state that the trade resulting from the Fixed Price Order should be
    /// set to.
    /// </summary>
    public TradeState TradeState { get; }

    /// <summary>
    /// The reason that the Fixed Price Order was created.
    /// </summary>
    public FixedPriceOrderReason Reason { get; }
  }
}
