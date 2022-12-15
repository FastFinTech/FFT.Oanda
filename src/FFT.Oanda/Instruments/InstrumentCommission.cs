// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// An InstrumentCommission represents an instrument-specific commission.
/// </summary>
public sealed record InstrumentCommission
{
  /// <summary>
  /// The commission amount (in the Account’s home currency) charged per
  /// unitsTraded of the instrument.
  /// </summary>
  public decimal Commission { get; init; }

  /// <summary>
  /// The number of units traded that the commission amount is based on.
  /// </summary>
  public decimal UnitsTraded { get; init; }

  /// <summary>
  /// The minimum commission amount (in the Account’s home currency) that is
  /// charged when an Order is filled for this instrument.
  /// </summary>
  public decimal MinimumCommission { get; init; }
}
