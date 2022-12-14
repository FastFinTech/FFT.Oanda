// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// The Candlestick representation.
/// </summary>
public sealed class CandleStick
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CandleStick"/> class.
  /// </summary>
  [JsonConstructor]
  public CandleStick(
    DateTime time,
    CandlestickData? bid,
    CandlestickData? ask,
    CandlestickData? mid,
    double volume,
    bool complete)
  {
    Time = time;
    Bid = bid;
    Ask = ask;
    Mid = mid;
    Volume = volume;
    Complete = complete;
  }

  /// <summary>
  /// The start time of the candlestick.
  /// </summary>
  public DateTime Time { get; }

  /// <summary>
  /// The candlestick data based on bids. Only provided if bid-based candles
  /// were requested.
  /// </summary>
  public CandlestickData? Bid { get; }

  /// <summary>
  /// The candlestick data based on asks. Only provided if ask-based candles
  /// were requested.
  /// </summary>
  public CandlestickData? Ask { get; }

  /// <summary>
  /// The candlestick data based on midpoints. Only provided if midpoint-based
  /// candles were requested.
  /// </summary>
  public CandlestickData? Mid { get; }

  /// <summary>
  /// The number of prices created during the time-range represented by the
  /// candlestick.
  /// </summary>
  public double Volume { get; }

  /// <summary>
  /// A flag indicating if the candlestick is complete. A complete candlestick
  /// is one whose ending time is not in the future.
  /// </summary>
  public bool Complete { get; }
}
