// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.Orders;

/// <summary>
/// Base class for transactions that can open new trades. Note that the Market
/// orders also inherit this base class, but they can also be used for closing
/// trades.
/// </summary>
public abstract record OpeningOrderTransaction : OrderTransaction
{
  /// <summary>
  /// The Order’s Instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The quantity requested to be filled by the Order. A positive
  /// number of units results in a long Order, and a negative number of units
  /// results in a short Order.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// Specification of how Positions in the Account are modified when the
  /// Order is filled.
  /// </summary>
  public OrderPositionFill PositionFill { get; init; }

  /// <summary>
  /// The specification of the Take Profit Order that should be created for a
  /// Trade opened when the Order is filled (if such a Trade is created).
  /// </summary>
  public TakeProfitDetails? TakeProfitOnFill { get; init; }

  /// <summary>
  /// The specification of the Stop Loss Order that should be created for a
  /// Trade opened when the Order is filled (if such a Trade is created).
  /// </summary>
  public StopLossDetails? StopLossOnFill { get; init; }

  /// <summary>
  /// The specification of the Trailing Stop Loss Order that should be created
  /// for a Trade that is opened when the Order is filled (if such a Trade is
  /// created).
  /// </summary>
  public TrailingStopLossDetails? TrailingStopLossOnFill { get; init; }

  /// <summary>
  /// The specification of the Guaranteed Stop Loss Order that should be
  /// created for a Trade that is opened when the Order is filled (if such a
  /// Trade is created).
  /// </summary>
  public GuaranteedStopLossDetails? GuaranteedStopLossOnFill { get; init; }

  /// <summary>
  /// Client Extensions to add to the Trade created when the Order is filled
  /// (if such a Trade is created).  Do not set, modify, delete
  /// tradeClientExtensions if your account is associated with MT4.
  /// </summary>
  public ClientExtensions? TradeClientExtensions { get; init; }
}
