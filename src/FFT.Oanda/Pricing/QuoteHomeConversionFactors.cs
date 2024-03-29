﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

/// <summary>
/// QuoteHomeConversionFactors represents the factors that can be used used to
/// convert quantities of a Price’s Instrument’s quote currency into the
/// Account’s home currency.
/// </summary>
public sealed record QuoteHomeConversionFactors
{
  /// <summary>
  /// The factor used to convert a positive amount of the Price’s Instrument’s
  /// quote currency into a positive amount of the Account’s home currency.
  /// Conversion is performed by multiplying the quote units by the conversion
  /// factor.
  /// </summary>
  public decimal PositiveUnits { get; init; }

  /// <summary>
  /// The factor used to convert a negative amount of the Price’s Instrument’s
  /// quote currency into a negative amount of the Account’s home currency.
  /// Conversion is performed by multiplying the quote units by the conversion
  /// factor.
  /// </summary>
  public decimal NegativeUnits { get; init; }
}
