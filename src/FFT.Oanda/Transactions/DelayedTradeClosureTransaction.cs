// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A DelayedTradeClosure Transaction is created administratively to indicate
  /// open trades that should have been closed but weren’t because the open
  /// trades’ instruments were untradeable at the time. Open trades listed in
  /// this transaction will be closed once their respective instruments become
  /// tradeable.
  /// </summary>
  public sealed class DelayedTradeClosureTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DelayedTradeClosureTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public DelayedTradeClosureTransaction(
      int id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      MarketOrderReason reason,
      ImmutableList<string> tradeIDs)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      Reason = reason;
      TradeIDs = tradeIDs;
    }

    /// <summary>
    /// The reason for the delayed trade closure.
    /// </summary>
    public MarketOrderReason Reason { get; }

    /// <summary>
    /// List of Trade ID’s identifying the open trades that will be closed when
    /// their respective instruments become tradeable.
    /// </summary>
    public ImmutableList<string> TradeIDs { get; }
  }
}
