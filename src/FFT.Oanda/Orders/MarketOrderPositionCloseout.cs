// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A MarketOrderPositionCloseout specifies the extensions to a Market Order
/// when it has been created to closeout a specific Position.
/// </summary>
public sealed record MarketOrderPositionCloseout
{
  /// <summary>
  /// The instrument of the Position being closed out.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// Indication of how much of the Position to close. Either “ALL”, or a
  /// DecimalNumber reflection a partial close of the Trade. The DecimalNumber
  /// must always be positive, and represent a number that doesn’t exceed the
  /// absolute size of the Position.
  /// </summary>
  public NumUnits Units { get; init; }
}
