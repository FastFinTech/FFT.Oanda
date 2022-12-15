// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A GuaranteedStopLossOrderLevelRestriction represents the total position
/// size that can exist within a given price window for Trades with guaranteed
/// Stop Loss Orders attached for a specific Instrument.
/// </summary>
public sealed record GuaranteedStopLossOrderLevelRestriction
{
  /// <summary>
  /// Applies to Trades with a guaranteed Stop Loss Order attached for the
  /// specified Instrument. This is the total allowed Trade volume that can
  /// exist within the priceRange based on the trigger prices of the
  /// guaranteed Stop Loss Orders.
  /// </summary>
  public decimal Volume { get; init; }

  /// <summary>
  /// The price range the volume applies to. This value is in price units.
  /// </summary>
  public decimal PriceRange { get; init; }
}
