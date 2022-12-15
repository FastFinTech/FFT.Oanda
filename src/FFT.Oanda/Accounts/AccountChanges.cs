// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.Orders;
using FFT.Oanda.Positions;
using FFT.Oanda.Trades;
using FFT.Oanda.Transactions;

/// <summary>
/// An AccountChanges Object is used to represent the changes to an Account’s
/// Orders, Trades and Positions since a specified Account TransactionID in
/// the past.
/// </summary>
public sealed record AccountChanges
{
  /// <summary>
  /// The Orders created. These Orders may have been filled, cancelled or
  /// triggered in the same period.
  /// </summary>
  public ImmutableList<Order> OrdersCreated { get; init; }

  /// <summary>
  /// The Orders cancelled.
  /// </summary>
  public ImmutableList<Order> OrdersCancelled { get; init; }

  /// <summary>
  /// The Orders filled.
  /// </summary>
  public ImmutableList<Order> OrdersFilled { get; init; }

  /// <summary>
  /// The Orders triggered.
  /// </summary>
  public ImmutableList<Order> OrdersTriggered { get; init; }

  /// <summary>
  /// The Trades opened.
  /// </summary>
  public ImmutableList<TradeSummary> TradesOpened { get; init; }

  /// <summary>
  /// The Trades reduced.
  /// </summary>
  public ImmutableList<TradeSummary> TradesReduced { get; init; }

  /// <summary>
  /// The Trades closed.
  /// </summary>
  public ImmutableList<TradeSummary> TradesClosed { get; init; }

  /// <summary>
  /// The Positions changed.
  /// </summary>
  public ImmutableList<Position> Positions { get; init; }

  /// <summary>
  /// The Transactions that have been generated.
  /// </summary>
  public ImmutableList<Transaction> Transactions { get; init; }
}
