// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  using System;
  using Throw;

  /// <summary>
  /// The Price component(s) to get candlestick data for.
  /// </summary>
  public sealed record PricingComponent
  {
    /// <summary>
    /// Bid.
    /// </summary>
    public bool Bid { get; init; }

    /// <summary>
    /// Ask.
    /// </summary>
    public bool Ask { get; init; }

    /// <summary>
    /// Mid point.
    /// </summary>
    public bool Mid { get; init; }

    /// <inheritdoc/>
    public override string ToString()
      => (Bid ? "B" : string.Empty) + (Ask ? "A" : string.Empty) + (Mid ? "M" : string.Empty);

    /// <summary>
    /// Throws an <see cref="ArgumentException"/> if this instance contains
    /// an invalid combination of values.
    /// </summary>
    public PricingComponent Validate()
    {
      (Bid || Ask || Mid).Throw("At least one pricing component must be required.").IfFalse();
      return this;
    }
  }
}
