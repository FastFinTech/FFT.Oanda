// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// Response containing instrument, granularity, and list of candles.
/// </summary>
public sealed record CandlestickResponse
{
  /// <summary>
  /// The instrument whose Prices are represented by the candlesticks.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The granularity of the candlesticks provided.
  /// </summary>
  public CandlestickGranularity Granularity { get; init; }

  /// <summary>
  /// The list of candlesticks that satisfy the request.
  /// </summary>
  public ImmutableList<CandleStick> Candles { get; init; }
}
