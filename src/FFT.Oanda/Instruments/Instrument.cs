// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// Full specification of an instrument.
  /// </summary>
  public sealed class Instrument
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Instrument"/> class.
    /// </summary>
    [JsonConstructor]
    public Instrument(
      string name,
      InstrumentType type,
      string displayName,
      int pipLocation,
      int displayPrecision,
      int tradeUnitsPrecision,
      decimal minimumTradeSize,
      decimal maximumTrailingStopDistance,
      decimal minimumGuaranteedStopLossDistance,
      decimal minimumTrailingStopDistance,
      decimal maximumPositionSize,
      decimal maximumOrderUnits,
      decimal marginRate,
      InstrumentCommission commission,
      GuaranteedStopLossOrderModeForInstrument guaranteedStopLossOrderMode,
      decimal? guaranteedStopLossOrderExecutionPremium,
      GuaranteedStopLossOrderLevelRestriction guaranteedStopLossOrderLevelRestriction,
      InstrumentFinancing financing,
      ImmutableList<Tag> tags)
    {
      Name = name;
      Type = type;
      DisplayName = displayName;
      PipLocation = pipLocation;
      DisplayPrecision = displayPrecision;
      TradeUnitsPrecision = tradeUnitsPrecision;
      MinimumTradeSize = minimumTradeSize;
      MaximumTrailingStopDistance = maximumTrailingStopDistance;
      MinimumGuaranteedStopLossDistance = minimumGuaranteedStopLossDistance;
      MinimumTrailingStopDistance = minimumTrailingStopDistance;
      MaximumPositionSize = maximumPositionSize;
      MaximumOrderUnits = maximumOrderUnits;
      MarginRate = marginRate;
      Commission = commission;
      GuaranteedStopLossOrderMode = guaranteedStopLossOrderMode;
      GuaranteedStopLossOrderExecutionPremium = guaranteedStopLossOrderExecutionPremium;
      GuaranteedStopLossOrderLevelRestriction = guaranteedStopLossOrderLevelRestriction;
      Financing = financing;
      Tags = tags;
    }

    /// <summary>
    /// The name of the Instrument.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The type of the Instrument.
    /// </summary>
    public InstrumentType Type { get; }

    /// <summary>
    /// The display name of the Instrument.
    /// </summary>
    public string DisplayName { get; }

    /// <summary>
    /// The location of the “pip” for this instrument. The decimal position of
    /// the pip in this Instrument’s price can be found at 10 ^ pipLocation
    /// (e.g. -4 pipLocation results in a decimal pip position of 10 ^ -4 =
    /// 0.0001).
    /// </summary>
    public int PipLocation { get; }

    /// <summary>
    /// The number of decimal places that should be used to display prices for
    /// this instrument. (e.g. a displayPrecision of 5 would result in a price
    /// of“1” being displayed as “1.00000”).
    /// </summary>
    public int DisplayPrecision { get; }

    /// <summary>
    /// The amount of decimal places that may be provided when specifying the
    /// number of units traded for this instrument.
    /// </summary>
    public int TradeUnitsPrecision { get; }

    /// <summary>
    /// The smallest number of units allowed to be traded for this instrument.
    /// </summary>
    public decimal MinimumTradeSize { get; }

    /// <summary>
    /// The maximum trailing stop distance allowed for a trailing stop loss
    /// created for this instrument. Specified in price units.
    /// </summary>
    public decimal MaximumTrailingStopDistance { get; }

    /// <summary>
    /// The minimum distance allowed between the Trade’s fill price and the
    /// configured price for guaranteed Stop Loss Orders created for this
    /// instrument. Specified in price units.
    /// </summary>
    public decimal MinimumGuaranteedStopLossDistance { get; }

    /// <summary>
    /// The minimum trailing stop distance allowed for a trailing stop loss
    /// created for this instrument. Specified in price units.
    /// </summary>
    public decimal MinimumTrailingStopDistance { get; }

    /// <summary>
    /// The maximum position size allowed for this instrument. Specified in
    /// units.
    /// </summary>
    public decimal MaximumPositionSize { get; }

    /// <summary>
    /// The maximum units allowed for an Order placed for this instrument.
    /// Specified in units.
    /// </summary>
    public decimal MaximumOrderUnits { get; }

    /// <summary>
    /// The margin rate for this instrument.
    /// </summary>
    public decimal MarginRate { get; }

    /// <summary>
    /// The commission structure for this instrument.
    /// </summary>
    public InstrumentCommission Commission { get; }

    /// <summary>
    /// The current Guaranteed Stop Loss Order mode of the Account for this
    /// Instrument.
    /// </summary>
    public GuaranteedStopLossOrderModeForInstrument GuaranteedStopLossOrderMode { get; }

    /// <summary>
    /// The amount that is charged to the account if a guaranteed Stop Loss
    /// Order is triggered and filled. The value is in price units and is
    /// charged for each unit of the Trade. This field will only be present if
    /// the Account’s guaranteedStopLossOrderMode for this Instrument is not
    /// ‘DISABLED’.
    /// </summary>
    public decimal? GuaranteedStopLossOrderExecutionPremium { get; }

    /// <summary>
    /// The guaranteed Stop Loss Order level restriction for this instrument.
    /// This field will only be present if the Account’s
    /// guaranteedStopLossOrderMode for this Instrument is not ‘DISABLED’.
    /// </summary>
    public GuaranteedStopLossOrderLevelRestriction GuaranteedStopLossOrderLevelRestriction { get; }

    /// <summary>
    /// Financing data for this instrument.
    /// </summary>
    public InstrumentFinancing Financing { get; }

    /// <summary>
    /// The tags associated with this instrument.
    /// </summary>
    public ImmutableList<Tag> Tags { get; }
  }
}
