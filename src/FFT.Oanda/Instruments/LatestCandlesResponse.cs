// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System.Collections.Immutable;
using System.Text.Json.Serialization;

/// <summary>
/// TODO.
/// </summary>
public sealed class LatestCandlesResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="LatestCandlesResponse"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public LatestCandlesResponse(
    ImmutableList<CandlestickResponse> latestCandles)
  {
    LatestCandles = latestCandles;
  }

  /// <summary>
  /// The latest candle sticks.
  /// </summary>
  public ImmutableList<CandlestickResponse> LatestCandles { get; }
}
