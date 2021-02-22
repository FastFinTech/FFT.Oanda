// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Response containing instrument, granularity, and list of candles.
  /// </summary>
  public sealed class CandlestickResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CandlestickResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public CandlestickResponse(
      string instrument,
      CandlestickGranularity granularity,
      ImmutableList<CandleStick> candles)
    {
      Instrument = instrument;
      Granularity = granularity;
      Candles = candles;
    }

    /// <summary>
    /// The instrument whose Prices are represented by the candlesticks.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The granularity of the candlesticks provided.
    /// </summary>
    public CandlestickGranularity Granularity { get; }

    /// <summary>
    /// The list of candlesticks that satisfy the request.
    /// </summary>
    public ImmutableList<CandleStick> Candles { get; }
  }
}
