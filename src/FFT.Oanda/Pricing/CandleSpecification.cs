// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using FFT.Oanda.Instruments;

  /// <summary>
  /// An instrument name, a granularity, and a price component to get
  /// candlestick data for.
  /// </summary>
  public sealed class CandleSpecification
  {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    /// <summary>
    /// The name of the instrument to get candle data for.
    /// </summary>
    public string InstrumentName { get; init; }

    /// <summary>
    /// The candlestick granularity to get data for.
    /// </summary>
    public CandleStickGranularity CandleStickGranularity { get; init; }

    /// <summary>
    /// The Price component(s) to get candlestick data for. Can be used as flags
    /// to include more than one pricing component.
    /// </summary>
    public PricingComponent PricingComponent { get; init; }

    /// <inheritdoc/>
    public override string ToString()
    {
      var result = $"{InstrumentName}:{CandleStickGranularity}:";
      if (PricingComponent.HasFlag(PricingComponent.B))
        result += "B";
      if (PricingComponent.HasFlag(PricingComponent.A))
        result += "A";
      if (PricingComponent.HasFlag(PricingComponent.M))
        result += "M";
      return result;
    }
  }
}
