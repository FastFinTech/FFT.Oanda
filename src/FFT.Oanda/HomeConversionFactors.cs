// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

/// <summary>
/// A HomeConversionFactors message contains information used to convert
/// amounts, from an Instrument’s base or quote currency, to the home currency
/// of an Account.
/// </summary>
public sealed record HomeConversionFactors
{
  /// <summary>
  /// The ConversionFactor in effect for the Account for converting any gains
  /// realized in Instrument quote units into units of the Account’s home
  /// currency.
  /// </summary>
  public ConversionFactor GainQuoteHome { get; init; }

  /// <summary>
  /// The ConversionFactor in effect for the Account for converting any losses
  /// realized in Instrument quote units into units of the Account’s home
  /// currency.
  /// </summary>
  public ConversionFactor LossQuoteHome { get; init; }

  /// <summary>
  /// The ConversionFactor in effect for the Account for converting any gains
  /// realized in Instrument base units into units of the Account’s home
  /// currency.
  /// </summary>
  public ConversionFactor GainBaseHome { get; init; }

  /// <summary>
  /// The ConversionFactor in effect for the Account for converting any losses
  /// realized in Instrument base units into units of the Account’s home
  /// currency.
  /// </summary>
  public ConversionFactor LossBaseHome { get; init; }
}
