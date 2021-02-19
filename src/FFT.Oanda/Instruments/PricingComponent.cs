// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  using System;

  /// <summary>
  /// The Price component(s) to get candlestick data for.
  /// </summary>
  [Flags]
  public enum PricingComponent
  {
    /// <summary>
    /// Bid
    /// </summary>
    B = 1,

    /// <summary>
    /// Ask
    /// </summary>
    A = 2,

    /// <summary>
    /// Mid point
    /// </summary>
    M = 4,
  }
}
