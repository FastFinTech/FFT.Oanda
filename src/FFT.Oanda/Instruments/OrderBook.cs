// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;

/// <summary>
/// The representation of an instrument’s order book at a point in time.
/// </summary>
public sealed class OrderBook
{
  /// <summary>
  /// Initializes a new instance of the <see cref="OrderBook"/> class.
  /// </summary>
  [JsonConstructor]
  public OrderBook(
    string instrument,
    DateTime time,
    decimal price,
    decimal bucketWidth,
    ImmutableList<OrderBookBucket> buckets)
  {
    Instrument = instrument;
    Time = time;
    Price = price;
    BucketWidth = bucketWidth;
    Buckets = buckets;
  }

  /// <summary>
  /// The order book’s instrument.
  /// </summary>
  public string Instrument { get; }

  /// <summary>
  /// The time when the order book snapshot was created.
  /// </summary>
  public DateTime Time { get; }

  /// <summary>
  /// The price (midpoint) for the order book’s instrument at the time of the
  /// order book snapshot.
  /// </summary>
  public decimal Price { get; }

  /// <summary>
  /// The price width for each bucket. Each bucket covers the price range from
  /// the bucket’s price to the bucket’s price + bucketWidth.
  /// </summary>
  public decimal BucketWidth { get; }

  /// <summary>
  /// The partitioned order book, divided into buckets using a default bucket
  /// width. These buckets are only provided for price ranges which actually
  /// contain order or position data.
  /// </summary>
  public ImmutableList<OrderBookBucket> Buckets { get; }
}
