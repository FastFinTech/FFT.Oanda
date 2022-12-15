// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

/// <summary>
/// Representation of many units of an Instrument are available to be traded
/// for both long and short Orders.
/// </summary>
public sealed record UnitsAvailableDetails
{
  /// <summary>
  /// The units available for long Orders.
  /// </summary>
  public decimal Long { get; init; }

  /// <summary>
  /// The units available for short Orders.
  /// </summary>
  public decimal Short { get; init; }
}
