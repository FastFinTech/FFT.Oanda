// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System.Text.Json.Serialization;

/// <summary>
/// The reason that the Guaranteed Stop Loss Order was initiated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum GuaranteedStopLossOrderReason
{
  /// <summary>
  /// The Guaranteed Stop Loss Order was initiated at the request of a client
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Guaranteed Stop Loss Order was initiated as a replacement for an
  /// existing Order
  /// </summary>
  REPLACEMENT,

  /// <summary>
  /// The Guaranteed Stop Loss Order was initiated automatically when an Order
  /// was filled that opened a new Trade requiring a Guaranteed Stop Loss
  /// Order.
  /// </summary>
  ON_FILL,
}
