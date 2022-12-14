// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System.Text.Json.Serialization;

/// <summary>
/// A MarketOrderPositionCloseout specifies the extensions to a Market Order
/// when it has been created to closeout a specific Position.
/// </summary>
public sealed class MarketOrderPositionCloseout
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="MarketOrderPositionCloseout"/> class.
  /// </summary>
  [JsonConstructor]
  public MarketOrderPositionCloseout(
    string instrument,
    string units)
  {
    Instrument = instrument;
    Units = units;
  }

  /// <summary>
  /// The instrument of the Position being closed out.
  /// </summary>
  public string Instrument { get; }

  /// <summary>
  /// Indication of how much of the Position to close. Either “ALL”, or a
  /// DecimalNumber reflection a partial close of the Trade. The DecimalNumber
  /// must always be positive, and represent a number that doesn’t exceed the
  /// absolute size of the Position.
  /// </summary>
  public string Units { get; }
}
