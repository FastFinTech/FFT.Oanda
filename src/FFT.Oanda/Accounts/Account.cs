// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.Orders;
using FFT.Oanda.Positions;
using FFT.Oanda.Trades;

/// <summary>
/// The full details of an account. This includes full open trade, open
/// position and pending order representation.
/// </summary>
public sealed record Account : AccountSummary
{
  /// <summary>
  /// The details of the trades currently open in the account.
  /// </summary>
  public ImmutableList<TradeSummary> Trades { get; init; }

  /// <summary>
  /// The details all account positions.
  /// </summary>
  public ImmutableList<Position> Positions { get; init; }

  /// <summary>
  /// The details of the orders currently pending in the account.
  /// </summary>
  public ImmutableList<Order> Orders { get; init; }
}
