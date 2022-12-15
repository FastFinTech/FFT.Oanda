// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The representation of an instrument’s position book at a point in time.
/// </summary>
public sealed record PositionBook
{
  /// <summary>
  /// The position book’s instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The time when the position book snapshot was created.
  /// </summary>
  public DateTime Time { get; init; }

  /// <summary>
  /// The price (midpoint) for the position book’s instrument at the time of
  /// the position book snapshot.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The price width for each bucket. Each bucket covers the price range from
  /// the bucket’s price to the bucket’s price + bucketWidth.
  /// </summary>
  public decimal BucketWidth { get; init; }

  /// <summary>
  /// The partitioned position book, divided into buckets using a default
  /// bucket width. These buckets are only provided for price ranges which
  /// actually contain order or position data.
  /// </summary>
  public ImmutableList<PositionBookBucket> Buckets { get; init; }
}
