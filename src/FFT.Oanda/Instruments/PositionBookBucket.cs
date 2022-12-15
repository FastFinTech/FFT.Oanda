// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The position book data for a partition of the instrument’s prices.
/// </summary>
public sealed record PositionBookBucket
{
  /// <summary>
  /// The lowest price (inclusive) covered by the bucket. The bucket covers
  /// the price range from the price to price + the position book’s
  /// bucketWidth.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The percentage of the total number of positions represented by the long
  /// positions found in this bucket.
  /// </summary>
  public decimal LongCountPercent { get; init; }

  /// <summary>
  /// The percentage of the total number of positions represented by the short
  /// positions found in this bucket.
  /// </summary>
  public decimal ShortCountPercent { get; init; }
}
