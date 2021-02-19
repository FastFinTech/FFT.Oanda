// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The state to filter the trades by.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum TradeStateFilter
  {
    /// <summary>
    /// The trades that are currently open.
    /// </summary>
    OPEN,

    /// <summary>
    /// The trades that have been fully closed.
    /// </summary>
    CLOSED,

    /// <summary>
    /// The trades that will be closed as soon as the trades’ instrument becomes
    /// tradeable.
    /// </summary>
    CLOSE_WHEN_TRADEABLE,

    /// <summary>
    /// The trades that are in any of the possible states listed above.
    /// </summary>
    ALL,
  }
}
