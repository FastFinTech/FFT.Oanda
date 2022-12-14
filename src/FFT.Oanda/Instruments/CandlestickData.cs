// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System.Text.Json.Serialization;

/// <summary>
/// The price data (open, high, low, close) for the Candlestick
/// representation.
/// </summary>
public sealed class CandlestickData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CandlestickData"/> class.
  /// </summary>
  [JsonConstructor]
  public CandlestickData(
    double open,
    double high,
    double low,
    double close)
  {
    Open = open;
    High = high;
    Low = low;
    Close = close;
  }

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
