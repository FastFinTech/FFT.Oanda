// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// The reason that the Limit Order was initiated.
/// </summary>
public enum LimitOrderReason
{
  /// <summary>
  /// The Limit Order was initiated at the request of a client.
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Limit Order was initiated as a replacement for an existing Order,
  /// </summary>
  REPLACEMENT,
}
