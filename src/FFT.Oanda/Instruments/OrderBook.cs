// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The representation of an instrument’s order book at a point in time.
/// </summary>
public sealed record OrderBook
{
  /// <summary>
  /// The order book’s instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The time when the order book snapshot was created.
  /// </summary>
  public DateTime Time { get; init; }

  /// <summary>
  /// The price (midpoint) for the order book’s instrument at the time of the
  /// order book snapshot.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The price width for each bucket. Each bucket covers the price range from
  /// the bucket’s price to the bucket’s price + bucketWidth.
  /// </summary>
  public decimal BucketWidth { get; init; }

  /// <summary>
  /// The partitioned order book, divided into buckets using a default bucket
  /// width. These buckets are only provided for price ranges which actually
  /// contain order or position data.
  /// </summary>
  public ImmutableList<OrderBookBucket> Buckets { get; init; }
}
