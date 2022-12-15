// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// Details required by clients creating a Guaranteed Stop Loss Order.
/// </summary>
public sealed record GuaranteedStopLossOrderEntryData
{
  /// <summary>
  /// The minimum distance allowed between the Trade’s fill price and the
  /// configured price for guaranteed Stop Loss Orders created for this
  /// instrument. Specified in price units.
  /// </summary>
  public decimal MinimumDistance { get; init; }

  /// <summary>
  /// The amount that is charged to the account if a guaranteed Stop Loss
  /// Order is triggered and filled. The value is in price units and is
  /// charged for each unit of the Trade.
  /// </summary>
  public decimal Premium { get; init; }

  /// <summary>
  /// The guaranteed Stop Loss Order level restriction for this instrument.
  /// </summary>
  public decimal LevelRestriction { get; init; }
}
