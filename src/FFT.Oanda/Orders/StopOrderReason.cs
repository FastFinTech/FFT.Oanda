// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System.Text.Json.Serialization;

/// <summary>
/// The reason that the Stop Order was initiated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StopOrderReason
{
  /// <summary>
  /// The Stop Order was initiated at the request of a client.
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Stop Order was initiated as a replacement for an existing Order,
  /// </summary>
  REPLACEMENT,
}
