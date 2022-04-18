// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;
  using FFT.Oanda.Orders;
  using FFT.Oanda.Positions;
  using FFT.Oanda.Trades;

  /// <summary>
  /// An AccountChanges Object is used to represent the changes to an Account’s
  /// Orders, Trades and Positions since a specified Account TransactionID in
  /// the past.
  /// </summary>
  public sealed class AccountChanges
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountChanges"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountChanges(
      ImmutableList<Order> ordersCreated,
      ImmutableList<Order> ordersCancelled,
      ImmutableList<Order> ordersFilled,
      ImmutableList<Order> ordersTriggered,
      ImmutableList<TradeSummary> tradesOpened,
      ImmutableList<TradeSummary> tradesReduced,
      ImmutableList<TradeSummary> tradesClosed,
      ImmutableList<Position> positions,
      ImmutableList<Transaction> transactions)
    {
      OrdersCreated = ordersCreated;
      OrdersCancelled = ordersCancelled;
      OrdersFilled = ordersFilled;
      OrdersTriggered = ordersTriggered;
      TradesOpened = tradesOpened;
      TradesReduced = tradesReduced;
      TradesClosed = tradesClosed;
      Positions = positions;
      Transactions = transactions;
    }

    /// <summary>
    /// The Orders created. These Orders may have been filled, cancelled or
    /// triggered in the same period.
    /// </summary>
    public ImmutableList<Order> OrdersCreated { get; }

    /// <summary>
    /// The Orders cancelled.
    /// </summary>
    public ImmutableList<Order> OrdersCancelled { get; }

    /// <summary>
    /// The Orders filled.
    /// </summary>
    public ImmutableList<Order> OrdersFilled { get; }

    /// <summary>
    /// The Orders triggered.
    /// </summary>
    public ImmutableList<Order> OrdersTriggered { get; }

    /// <summary>
    /// The Trades opened.
    /// </summary>
    public ImmutableList<TradeSummary> TradesOpened { get; }

    /// <summary>
    /// The Trades reduced.
    /// </summary>
    public ImmutableList<TradeSummary> TradesReduced { get; }

    /// <summary>
    /// The Trades closed.
    /// </summary>
    public ImmutableList<TradeSummary> TradesClosed { get; }

    /// <summary>
    /// The Positions changed.
    /// </summary>
    public ImmutableList<Position> Positions { get; }

    /// <summary>
    /// The Transactions that have been generated.
    /// </summary>
    public ImmutableList<Transaction> Transactions { get; }
  }
}
