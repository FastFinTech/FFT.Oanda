// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Text.Json.Serialization;

namespace FFT.Oanda.Orders
{
  /// <summary>
  /// The current state of the order.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum OrderState
  {
    /// <summary>
    /// The order is currently pending execution.
    /// </summary>
    PENDING,

    /// <summary>
    /// The order has been filled.
    /// </summary>
    FILLED,

    /// <summary>
    /// The order has been triggered.
    /// </summary>
    TRIGGERED,

    /// <summary>
    /// The order has been cancelled.
    /// </summary>
    CANCELLED,
  }
}
