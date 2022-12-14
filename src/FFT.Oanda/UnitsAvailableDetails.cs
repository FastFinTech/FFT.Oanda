// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Text.Json.Serialization;

/// <summary>
/// Representation of many units of an Instrument are available to be traded
/// for both long and short Orders.
/// </summary>
public sealed class UnitsAvailableDetails
{
  /// <summary>
  /// Initializes a new instance of the <see cref="UnitsAvailableDetails"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public UnitsAvailableDetails(decimal @long, decimal @short)
  {
    Long = @long;
    Short = @short;
  }

  /// <summary>
  /// The units available for long Orders.
  /// </summary>
  public decimal Long { get; }

  /// <summary>
  /// The units available for short Orders.
  /// </summary>
  public decimal Short { get; }
}
