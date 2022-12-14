// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.Trades;

/// <summary>
/// A FixedPriceOrderTransaction represents the creation of a Fixed Price
/// Order in the user’s account. A Fixed Price Order is an Order that is
/// filled immediately at a specified price.
/// </summary>
public sealed record FixedPriceOrderTransaction : OpeningOrderTransaction
{
  /// <summary>
  /// The price specified for the Fixed Price Order. This price is the exact
  /// price that the Fixed Price Order will be filled at.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The state that the trade resulting from the Fixed Price Order should be
  /// set to.
  /// </summary>
  public TradeState TradeState { get; init; }

  /// <summary>
  /// The reason that the Fixed Price Order was created.
  /// </summary>
  public FixedPriceOrderReason Reason { get; init; }
}
