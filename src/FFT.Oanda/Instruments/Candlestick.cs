// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The Candlestick representation.
/// </summary>
public sealed record CandleStick
{
  /// <summary>
  /// The start time of the candlestick.
  /// </summary>
  public DateTime Time { get; init; }

  /// <summary>
  /// The candlestick data based on bids. Only provided if bid-based candles
  /// were requested.
  /// </summary>
  public CandlestickData? Bid { get; init; }

  /// <summary>
  /// The candlestick data based on asks. Only provided if ask-based candles
  /// were requested.
  /// </summary>
  public CandlestickData? Ask { get; init; }

  /// <summary>
  /// The candlestick data based on midpoints. Only provided if midpoint-based
  /// candles were requested.
  /// </summary>
  public CandlestickData? Mid { get; init; }

  /// <summary>
  /// The number of prices created during the time-range represented by the
  /// candlestick.
  /// </summary>
  public decimal Volume { get; init; } // no reason to use double

  /// <summary>
  /// A flag indicating if the candlestick is complete. A complete candlestick
  /// is one whose ending time is not in the future.
  /// </summary>
  public bool Complete { get; init; }
}
