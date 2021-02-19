// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The time-in-force of an Order. TimeInForce describes how long an Order
  /// should remain pending before being automatically cancelled by the
  /// execution system.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum TimeInForce
  {
    /// <summary>
    /// The Order is “Good until Cancelled”.
    /// </summary>
    GTC,

    /// <summary>
    /// The Order is “Good until Date” and will be cancelled at the provided
    /// time.
    /// </summary>
    GTD,

    /// <summary>
    /// The Order is “Good For Day” and will be cancelled at 5pm New York time.
    /// </summary>
    GFD,

    /// <summary>
    /// The Order must be immediately “Filled Or Killed”.
    /// </summary>
    FOK,

    /// <summary>
    /// The Order must be “Immediately partially filled Or Cancelled”.
    /// </summary>
    IOC,
  }
}
