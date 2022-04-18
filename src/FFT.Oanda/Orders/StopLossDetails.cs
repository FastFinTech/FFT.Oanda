// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// StopLossDetails specifies the details of a Stop Loss Order to be created
  /// on behalf of a client. This may happen when an Order is filled that opens
  /// a Trade requiring a Stop Loss, or when a Trade’s dependent Stop Loss Order
  /// is modified directly through the Trade.
  /// </summary>
  public sealed class StopLossDetails
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="StopLossDetails"/> class.
    /// </summary>
    [JsonConstructor]
    public StopLossDetails(string? price, decimal? distance, TimeInForce timeInForce, DateTime? gtdTime, ClientExtensions? clientExtensions)
    {
      Price = price;
      Distance = distance;
      TimeInForce = timeInForce;
      GtdTime = gtdTime;
      ClientExtensions = clientExtensions;
    }

    /// <summary>
    /// The price that the Stop Loss Order will be triggered at. Only one of the
    /// price and distance fields may be specified.
    /// </summary>
    public string? Price { get; }

    /// <summary>
    /// Specifies the distance (in price units) from the Trade’s open price to
    /// use as the Stop Loss Order price. Only one of the distance and price
    /// fields may be specified.
    /// </summary>
    public decimal? Distance { get; }

    /// <summary>
    /// The time in force for the created Stop Loss Order. This may only be GTC,
    /// GTD or GFD.
    /// </summary>
    public TimeInForce TimeInForce { get; }

    /// <summary>
    /// The date when the Stop Loss Order will be cancelled on if timeInForce is
    /// GTD.
    /// </summary>
    public DateTime? GtdTime { get; }

    /// <summary>
    /// The Client Extensions to add to the Stop Loss Order when created.
    /// </summary>
    public ClientExtensions? ClientExtensions { get; }
  }
}
