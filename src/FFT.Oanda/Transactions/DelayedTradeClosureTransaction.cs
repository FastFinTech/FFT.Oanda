// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A DelayedTradeClosure Transaction is created administratively to indicate
/// open trades that should have been closed but weren’t because the open
/// trades’ instruments were untradeable at the time. Open trades listed in
/// this transaction will be closed once their respective instruments become
/// tradeable.
/// </summary>
public sealed record DelayedTradeClosureTransaction : Transaction
{
  /// <summary>
  /// The reason for the delayed trade closure.
  /// </summary>
  public MarketOrderReason Reason { get; init; }

  /// <summary>
  /// List of Trade ID’s identifying the open trades that will be closed when
  /// their respective instruments become tradeable.
  /// </summary>
  public ImmutableList<int> TradeIDs { get; init; }
}
