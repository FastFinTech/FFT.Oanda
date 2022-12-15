// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// TrailingStopLossDetails specifies the details of a Trailing Stop Loss
/// Order to be created on behalf of a client. This may happen when an Order
/// is filled that opens a Trade requiring a Trailing Stop Loss, or when a
/// Trade’s dependent Trailing Stop Loss Order is modified directly through
/// the Trade.
/// </summary>
public sealed record TrailingStopLossDetails
{
  /// <summary>
  /// The distance (in price units) from the Trade’s fill price that the
  /// Trailing Stop Loss Order will be triggered at.
  /// </summary>
  public decimal Distance { get; init; }

  /// <summary>
  /// The time in force for the created Trailing Stop Loss Order. This may
  /// only be GTC, GTD or GFD.
  /// </summary>
  public TimeInForce TimeInForce { get; init; }

  /// <summary>
  /// The date when the Trailing Stop Loss Order will be cancelled on if
  /// timeInForce is GTD.
  /// </summary>
  public DateTime? GtdTime { get; init; }

  /// <summary>
  /// The Client Extensions to add to the Trailing Stop Loss Order when
  /// created.
  /// </summary>
  public ClientExtensions? ClientExtensions { get; init; }
}
