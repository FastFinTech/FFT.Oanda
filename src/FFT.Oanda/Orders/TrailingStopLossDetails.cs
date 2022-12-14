// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System;
using System.Text.Json.Serialization;
using FFT.Oanda;

/// <summary>
/// TrailingStopLossDetails specifies the details of a Trailing Stop Loss
/// Order to be created on behalf of a client. This may happen when an Order
/// is filled that opens a Trade requiring a Trailing Stop Loss, or when a
/// Trade’s dependent Trailing Stop Loss Order is modified directly through
/// the Trade.
/// </summary>
public sealed class TrailingStopLossDetails
{
  /// <summary>
  /// Initializes a new instance of the <see cref="TrailingStopLossDetails"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public TrailingStopLossDetails(decimal distance, TimeInForce timeInForce, DateTime? gtdTime, ClientExtensions? clientExtensions)
  {
    Distance = distance;
    TimeInForce = timeInForce;
    GtdTime = gtdTime;
    ClientExtensions = clientExtensions;
  }

  /// <summary>
  /// The distance (in price units) from the Trade’s fill price that the
  /// Trailing Stop Loss Order will be triggered at.
  /// </summary>
  public decimal Distance { get; }

  /// <summary>
  /// The time in force for the created Trailing Stop Loss Order. This may
  /// only be GTC, GTD or GFD.
  /// </summary>
  public TimeInForce TimeInForce { get; }

  /// <summary>
  /// The date when the Trailing Stop Loss Order will be cancelled on if
  /// timeInForce is GTD.
  /// </summary>
  public DateTime? GtdTime { get; }

  /// <summary>
  /// The Client Extensions to add to the Trailing Stop Loss Order when
  /// created.
  /// </summary>
  public ClientExtensions? ClientExtensions { get; }
}
