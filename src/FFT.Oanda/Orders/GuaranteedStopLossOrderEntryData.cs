// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Details required by clients creating a Guaranteed Stop Loss Order.
  /// </summary>
  public sealed class GuaranteedStopLossOrderEntryData
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="GuaranteedStopLossOrderEntryData"/> class.
    /// </summary>
    [JsonConstructor]
    public GuaranteedStopLossOrderEntryData(decimal minimumDistance, decimal premium, decimal levelRestriction)
    {
      MinimumDistance = minimumDistance;
      Premium = premium;
      LevelRestriction = levelRestriction;
    }

    /// <summary>
    /// The minimum distance allowed between the Trade’s fill price and the
    /// configured price for guaranteed Stop Loss Orders created for this
    /// instrument. Specified in price units.
    /// </summary>
    public decimal MinimumDistance { get; }

    /// <summary>
    /// The amount that is charged to the account if a guaranteed Stop Loss
    /// Order is triggered and filled. The value is in price units and is
    /// charged for each unit of the Trade.
    /// </summary>
    public decimal Premium { get; }

    /// <summary>
    /// The guaranteed Stop Loss Order level restriction for this instrument.
    /// </summary>
    public decimal LevelRestriction { get; }
  }
}
