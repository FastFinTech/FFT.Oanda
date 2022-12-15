// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System.Diagnostics;

/// <summary>
/// Full specification of an instrument.
/// </summary>
[DebuggerDisplay("{Name}/{DisplayName}")]
public sealed record Instrument
{
  /// <summary>
  /// The name of the Instrument.
  /// </summary>
  public string Name { get; init; }

  /// <summary>
  /// The type of the Instrument.
  /// </summary>
  public InstrumentType Type { get; init; }

  /// <summary>
  /// The display name of the Instrument.
  /// </summary>
  public string DisplayName { get; init; }

  /// <summary>
  /// The location of the “pip” for this instrument. The decimal position of
  /// the pip in this Instrument’s price can be found at 10 ^ pipLocation
  /// (e.g. -4 pipLocation results in a decimal pip position of 10 ^ -4 =
  /// 0.0001).
  /// </summary>
  public int PipLocation { get; init; }

  /// <summary>
  /// The number of decimal places that should be used to display prices for
  /// this instrument. (e.g. a displayPrecision of 5 would result in a price
  /// of“1” being displayed as “1.00000”).
  /// </summary>
  public int DisplayPrecision { get; init; }

  /// <summary>
  /// The amount of decimal places that may be provided when specifying the
  /// number of units traded for this instrument.
  /// </summary>
  public int TradeUnitsPrecision { get; init; }

  /// <summary>
  /// The smallest number of units allowed to be traded for this instrument.
  /// </summary>
  public decimal MinimumTradeSize { get; init; }

  /// <summary>
  /// The maximum trailing stop distance allowed for a trailing stop loss
  /// created for this instrument. Specified in price units.
  /// </summary>
  public decimal MaximumTrailingStopDistance { get; init; }

  /// <summary>
  /// The minimum distance allowed between the Trade’s fill price and the
  /// configured price for guaranteed Stop Loss Orders created for this
  /// instrument. Specified in price units.
  /// </summary>
  public decimal MinimumGuaranteedStopLossDistance { get; init; }

  /// <summary>
  /// The minimum trailing stop distance allowed for a trailing stop loss
  /// created for this instrument. Specified in price units.
  /// </summary>
  public decimal MinimumTrailingStopDistance { get; init; }

  /// <summary>
  /// The maximum position size allowed for this instrument. Specified in
  /// units.
  /// </summary>
  public decimal MaximumPositionSize { get; init; }

  /// <summary>
  /// The maximum units allowed for an Order placed for this instrument.
  /// Specified in units.
  /// </summary>
  public decimal MaximumOrderUnits { get; init; }

  /// <summary>
  /// The margin rate for this instrument.
  /// </summary>
  public decimal MarginRate { get; init; }

  /// <summary>
  /// The commission structure for this instrument.
  /// </summary>
  public InstrumentCommission Commission { get; init; }

  /// <summary>
  /// The current Guaranteed Stop Loss Order mode of the Account for this
  /// Instrument.
  /// </summary>
  public GuaranteedStopLossOrderModeForInstrument GuaranteedStopLossOrderMode { get; init; }

  /// <summary>
  /// The amount that is charged to the account if a guaranteed Stop Loss
  /// Order is triggered and filled. The value is in price units and is
  /// charged for each unit of the Trade. This field will only be present if
  /// the Account’s guaranteedStopLossOrderMode for this Instrument is not
  /// ‘DISABLED’.
  /// </summary>
  public decimal? GuaranteedStopLossOrderExecutionPremium { get; init; }

  /// <summary>
  /// The guaranteed Stop Loss Order level restriction for this instrument.
  /// This field will only be present if the Account’s
  /// guaranteedStopLossOrderMode for this Instrument is not ‘DISABLED’.
  /// </summary>
  public GuaranteedStopLossOrderLevelRestriction GuaranteedStopLossOrderLevelRestriction { get; init; }

  /// <summary>
  /// Financing data for this instrument.
  /// </summary>
  public InstrumentFinancing Financing { get; init; }

  /// <summary>
  /// The tags associated with this instrument.
  /// </summary>
  public ImmutableList<Tag> Tags { get; init; }
}
