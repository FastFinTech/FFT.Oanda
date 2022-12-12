// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// A StopLossOrderTransaction represents the creation of a StopLoss Order in
  /// the user’s Account.
  /// </summary>
  public class StopLossOrderTransaction : TradeRelatedOrderTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StopLossOrderTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public StopLossOrderTransaction(
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
      string tradeID,
      string? clientTradeID,
      decimal? price,
      decimal? distance)
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
      Price = price;
      Distance = distance;
    }

    /// <summary>
    /// The price threshold specified for the Stop Loss Order. The associated
    /// Trade will be closed by a market price that is equal to or worse than
    /// this threshold.
    /// </summary>
    public decimal? Price { get; }

    /// <summary>
    /// Specifies the distance (in price units) from the Account’s current price
    /// to use as the Stop Loss Order price. If the Trade is short the
    /// Instrument’s bid price is used, and for long Trades the ask is used.
    /// </summary>
    public decimal? Distance { get; }
  }
}
