// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The price data (open, high, low, close) for the Candlestick
/// representation.
/// </summary>
public sealed record CandlestickData
{
  /// <summary>
  /// The first (open) price in the time-range represented by the candlestick.
  /// </summary>
  [JsonPropertyName("o")]
  public double Open { get; }

  /// <summary>
  /// The highest price in the time-range represented by the candlestick.
  /// </summary>
  [JsonPropertyName("h")]
  public double High { get; }

  /// <summary>
  /// The lowest price in the time-range represented by the candlestick.
  /// </summary>
  [JsonPropertyName("l")]
  public double Low { get; }

  /// <summary>
  /// A flag indicating if the candlestick is complete. A complete candlestick
  /// is one whose ending time is not in the future.
  /// </summary>
  [JsonPropertyName("c")]
  public double Close { get; }
}
