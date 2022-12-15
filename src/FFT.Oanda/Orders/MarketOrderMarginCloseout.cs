// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// Details for the Market Order extensions specific to a Market Order placed
/// that is part of a Market Order Margin Closeout in a client’s account.
/// </summary>
public sealed record MarketOrderMarginCloseout
{
  /// <summary>
  /// The reason the Market Order was created to perform a margin closeout.
  /// </summary>
  public MarketOrderMarginCloseoutReason Reason { get; init; }
}
