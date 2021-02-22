// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using FFT.Oanda.Instruments;

  /// <summary>
  /// An instrument name, a granularity, and a price component to get
  /// candlestick data for.
  /// </summary>
  public sealed record CandleSpecification
  {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// The name of the instrument to get candle data for.
    /// </summary>
    public string InstrumentName { get; init; }

    /// <summary>
    /// The candlestick granularity to get data for.
    /// </summary>
    public CandlestickGranularity CandleStickGranularity { get; init; }

    /// <summary>
    /// The Price component(s) to get candlestick data for. Can be used as flags
    /// to include more than one pricing component.
    /// </summary>
    public PricingComponent PricingComponent { get; init; }

    /// <inheritdoc/>
    public override string ToString()
      => $"{InstrumentName}:{CandleStickGranularity}:{PricingComponent}";
  }
}
