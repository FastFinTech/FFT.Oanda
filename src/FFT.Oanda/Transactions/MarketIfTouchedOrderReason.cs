// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System.Text.Json.Serialization;

/// <summary>
/// The reason that the Market-if-touched Order was initiated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MarketIfTouchedOrderReason
{
  /// <summary>
  /// The Market-if-touched Order was initiated at the request of a client
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Market-if-touched Order was initiated as a replacement for an
  /// existing Order
  /// </summary>
  REPLACEMENT,
}
