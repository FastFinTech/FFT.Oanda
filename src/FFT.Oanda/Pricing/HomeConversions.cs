// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

/// <summary>
/// HomeConversions represents the factors to use to convert quantities of a
/// given currency into the Account’s home currency. The conversion factor
/// depends on the scenario the conversion is required for.
/// </summary>
public sealed record HomeConversions
{
  /// <summary>
  /// The currency to be converted into the home currency.
  /// </summary>
  public string Currency { get; init; }

  /// <summary>
  /// The factor used to convert any gains for an Account in the specified
  /// currency into the Account’s home currency. This would include positive
  /// realized P/L and positive financing amounts. Conversion is performed by
  /// multiplying the positive P/L by the conversion factor.
  /// </summary>
  public decimal AccountGain { get; init; }

  // TODO: I think the commenting below should say "negative P/L"

  /// <summary>
  /// The factor used to convert any losses for an Account in the specified
  /// currency into the Account’s home currency. This would include negative
  /// realized P/L and negative financing amounts. Conversion is performed by
  /// multiplying the positive P/L by the conversion factor.
  /// </summary>
  public decimal AccountLoss { get; init; }

  /// <summary>
  /// The factor used to convert a Position or Trade Value in the specified
  /// currency into the Account’s home currency. Conversion is performed by
  /// multiplying the Position or Trade Value by the conversion factor.
  /// </summary>
  public decimal PositionValue { get; init; }
}
