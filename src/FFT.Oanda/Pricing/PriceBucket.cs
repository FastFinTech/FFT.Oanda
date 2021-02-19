// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A PriceBucket represents a price available for an amount of liquidity.
  /// </summary>
  public sealed class PriceBucket
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PriceBucket"/> class.
    /// </summary>
    [JsonConstructor]
    public PriceBucket(
      decimal price,
      int liquidity)
    {
      Price = price;
      Liquidity = liquidity;
    }

    /// <summary>
    /// The Price offered by the PriceBucket.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The amount of liquidity offered by the PriceBucket.
    /// </summary>
    public int Liquidity { get; }
  }
}
