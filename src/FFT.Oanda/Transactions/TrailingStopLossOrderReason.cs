// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// The reason that the Trailing Stop Loss Order was initiated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TrailingStopLossOrderReason
{
  /// <summary>
  /// The Trailing Stop Loss Order was initiated at the request of a client
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Trailing Stop Loss Order was initiated as a replacement for an
  /// existing Order
  /// </summary>
  REPLACEMENT,

  /// <summary>
  /// The Trailing Stop Loss Order was initiated automatically when an Order
  /// was filled that opened a new Trade requiring a Trailing Stop Loss Order.
  /// </summary>
  ON_FILL,
}
