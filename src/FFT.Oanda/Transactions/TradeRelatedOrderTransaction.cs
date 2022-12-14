// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;
using FFT.Oanda.Orders;

/// <summary>
/// Base class for order transactions that are related to existing trades.
/// </summary>
public abstract class TradeRelatedOrderTransaction : OrderTransaction
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="TradeRelatedOrderTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  protected TradeRelatedOrderTransaction(
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
    string? clientTradeID)
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
          gtdTime)
  {
    TradeID = tradeID;
    ClientTradeID = clientTradeID;
  }

  /// <summary>
  /// The ID of the Trade to close when the order is filled.
  /// </summary>
  public string TradeID { get; }

  /// <summary>
  /// The client ID of the Trade to be closed when the order is filled.
  /// </summary>
  public string? ClientTradeID { get; }
}
