// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  /// <summary>
  /// The reason that the Market Order was created to perform a margin closeout.
  /// </summary>
  public enum MarketOrderMarginCloseoutReason
  {
    /// <summary>
    /// Trade closures resulted from violating OANDA’s margin policy.
    /// </summary>
    MARGIN_CHECK_VIOLATION,

    /// <summary>
    /// Trade closures came from a margin closeout event resulting from
    /// regulatory conditions placed on the Account’s margin call.
    /// </summary>
    REGULATORY_MARGIN_CALL_VIOLATION,

    /// <summary>
    /// Trade closures resulted from violating the margin policy imposed by
    /// regulatory requirements.
    /// </summary>
    REGULATORY_MARGIN_CHECK_VIOLATION,
  }
}
