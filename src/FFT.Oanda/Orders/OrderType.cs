// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The type of the Order.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum OrderType
  {
    /// <summary>
    /// A Market Order.
    /// </summary>
    MARKET,

    /// <summary>
    /// A Limit Order.
    /// </summary>
    LIMIT,

    /// <summary>
    /// A Stop Order.
    /// </summary>
    STOP,

    /// <summary>
    /// A Market-if-touched Order.
    /// </summary>
    MARKET_IF_TOUCHED,

    /// <summary>
    /// A Take Profit Order.
    /// </summary>
    TAKE_PROFIT,

    /// <summary>
    /// A Stop Loss Order.
    /// </summary>
    STOP_LOSS,

    /// <summary>
    /// A Guaranteed Stop Loss Order.
    /// </summary>
    GUARANTEED_STOP_LOSS,

    /// <summary>
    /// A Trailing Stop Loss Order.
    /// </summary>
    TRAILING_STOP_LOSS,

    /// <summary>
    /// A Fixed Price Order.
    /// </summary>
    FIXED_PRICE,
  }
}
