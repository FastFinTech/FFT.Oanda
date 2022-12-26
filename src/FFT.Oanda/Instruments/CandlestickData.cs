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
  public required double Open { get; init; }

  /// <summary>
  /// The highest price in the time-range represented by the candlestick.
  /// </summary>
  [JsonPropertyName("h")]
  public required double High { get; init; }

  /// <summary>
  /// The lowest price in the time-range represented by the candlestick.
  /// </summary>
  [JsonPropertyName("l")]
  public required double Low { get; init; }

  /// <summary>
  /// A flag indicating if the candlestick is complete. A complete candlestick
  /// is one whose ending time is not in the future.
  /// </summary>
  [JsonPropertyName("c")]
  public required double Close { get; init; }
}
