// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// For accounts that support guaranteed Stop Loss Orders, describes the
/// actions that can be be performed on guaranteed Stop Loss Orders for that
/// account.
/// </summary>
public enum GuaranteedStopLossOrderMutability
{
  /// <summary>
  /// Once a guaranteed Stop Loss Order has been created it cannot be replaced
  /// or cancelled.
  /// </summary>
  FIXED,

  /// <summary>
  /// An existing guaranteed Stop Loss Order can only be replaced, not
  /// cancelled.
  /// </summary>
  REPLACEABLE,

  /// <summary>
  /// Once a guaranteed Stop Loss Order has been created it can be either
  /// replaced or cancelled.
  /// </summary>
  CANCELABLE,

  /// <summary>
  /// An existing guaranteed Stop Loss Order can only be replaced to widen the
  /// gap from the current price, not cancelled.
  /// </summary>
  PRICE_WIDEN_ONLY,
}
