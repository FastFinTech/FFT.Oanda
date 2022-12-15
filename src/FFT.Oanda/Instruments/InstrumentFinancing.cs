// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// Financing data for the instrument.
/// </summary>
public sealed record InstrumentFinancing
{
  /// <summary>
  /// The financing rate to be used for a long position for the instrument.
  /// The value is in decimal rather than percentage points, i.e. 5% is
  /// represented as 0.05.
  /// </summary>
  public decimal LongRate { get; init; }

  /// <summary>
  /// The financing rate to be used for a short position for the instrument.
  /// The value is in decimal rather than percentage points, i.e. 5% is
  /// represented as 0.05.
  /// </summary>
  public decimal ShortRate { get; init; }

  /// <summary>
  /// The days of the week to debit or credit financing charges; the exact
  /// time of day at which to charge the financing is set in the
  /// DivisionTradingGroup for the client’s account.
  /// </summary>
  public ImmutableList<FinancingDayOfWeek> FinancingDaysOfWeek { get; init; }
}
