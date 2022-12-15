// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// GuaranteedStopLossDetails specifies the details of a Guaranteed Stop Loss
/// Order to be created on behalf of a client. This may happen when an Order
/// is filled that opens a Trade requiring a Guaranteed Stop Loss, or when a
/// Trade’s dependent Guaranteed Stop Loss Order is modified directly through
/// the Trade.
/// </summary>
public sealed record GuaranteedStopLossDetails
{
  /// <summary>
  /// The price that the Guaranteed Stop Loss Order will be triggered at. Only
  /// one of the price and distance fields may be specified.
  /// </summary>
  public decimal? Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Trade’s open price to
  /// use as the Guaranteed Stop Loss Order price. Only one of the distance
  /// and price fields may be specified.
  /// </summary>
  public decimal? Distance { get; init; }

  /// <summary>
  /// The time in force for the created Guaranteed Stop Loss Order. This may
  /// only be GTC, GTD or GFD.
  /// </summary>
  public TimeInForce TimeInForce { get; init; }

  /// <summary>
  /// The date when the Guaranteed Stop Loss Order will be cancelled on if
  /// timeInForce is GTD.
  /// </summary>
  public DateTime? GtdTime { get; init; }

  /// <summary>
  /// The Client Extensions to add to the Guaranteed Stop Loss Order when
  /// created.
  /// </summary>
  public ClientExtensions? ClientExtensions { get; init; }
}
