// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// TODO.
/// </summary>
public sealed record LatestCandlesResponse
{
  /// <summary>
  /// The latest candle sticks.
  /// </summary>
  public ImmutableList<CandlestickResponse> LatestCandles { get; init; }
}
