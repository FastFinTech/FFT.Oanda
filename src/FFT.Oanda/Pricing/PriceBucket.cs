// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing;

/// <summary>
/// A PriceBucket represents a price available for an amount of liquidity.
/// </summary>
public sealed record PriceBucket
{
  /// <summary>
  /// The Price offered by the PriceBucket.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The amount of liquidity offered by the PriceBucket.
  /// </summary>
  public decimal Liquidity { get; init; }
}
