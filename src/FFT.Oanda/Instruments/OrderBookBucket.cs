// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  /// <summary>
  /// The order book data for a partition of the instrument’s prices.
  /// </summary>
  public sealed class OrderBookBucket
  {
    /// <summary>
    /// The lowest price (inclusive) covered by the bucket. The bucket covers
    /// the price range from the price to price + the order book’s bucketWidth.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The percentage of the total number of orders represented by the long
    /// orders found in this bucket.
    /// </summary>
    public decimal LongCountPercent { get; }

    /// <summary>
    /// The percentage of the total number of orders represented by the short
    /// orders found in this bucket.
    /// </summary>
    public decimal ShortCountPercent { get; }
  }
}
