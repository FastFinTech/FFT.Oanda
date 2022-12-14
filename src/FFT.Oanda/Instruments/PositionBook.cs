// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

/// <summary>
/// The representation of an instrument’s position book at a point in time.
/// </summary>
public sealed class PositionBook
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PositionBook"/> class.
  /// </summary>
  [JsonConstructor]
  public PositionBook(
    string instrument,
    DateTime time,
    decimal price,
    decimal bucketWidth,
    ImmutableList<PositionBookBucket> buckets)
  {
    Instrument = instrument;
    Time = time;
    Price = price;
    BucketWidth = bucketWidth;
    Buckets = buckets;
  }

  /// <summary>
  /// The position book’s instrument.
  /// </summary>
  public string Instrument { get; }

  /// <summary>
  /// The time when the position book snapshot was created.
  /// </summary>
  public DateTime Time { get; }

  /// <summary>
  /// The price (midpoint) for the position book’s instrument at the time of
  /// the position book snapshot.
  /// </summary>
  public decimal Price { get; }

  /// <summary>
  /// The price width for each bucket. Each bucket covers the price range from
  /// the bucket’s price to the bucket’s price + bucketWidth.
  /// </summary>
  public decimal BucketWidth { get; }

  /// <summary>
  /// The partitioned position book, divided into buckets using a default
  /// bucket width. These buckets are only provided for price ranges which
  /// actually contain order or position data.
  /// </summary>
  public ImmutableList<PositionBookBucket> Buckets { get; }
}
