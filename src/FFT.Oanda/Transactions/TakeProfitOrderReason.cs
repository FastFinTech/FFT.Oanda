// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// The reason that the Take Profit Order was initiated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TakeProfitOrderReason
{
  /// <summary>
  /// The Take Profit Order was initiated at the request of a client
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Take Profit Order was initiated as a replacement for an existing
  /// Order
  /// </summary>
  REPLACEMENT,

  /// <summary>
  /// The Take Profit Order was initiated automatically when an Order was
  /// filled that opened a new Trade requiring a Take Profit Order.
  /// </summary>
  ON_FILL,
}
