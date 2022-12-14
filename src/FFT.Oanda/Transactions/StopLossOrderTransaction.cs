// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A StopLossOrderTransaction represents the creation of a StopLoss Order in
/// the user’s Account.
/// </summary>
public sealed record StopLossOrderTransaction : TradeRelatedOrderTransaction
{
  /// <summary>
  /// The price threshold specified for the Stop Loss Order. The associated
  /// Trade will be closed by a market price that is equal to or worse than
  /// this threshold.
  /// </summary>
  public decimal? Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Account’s current price
  /// to use as the Stop Loss Order price. If the Trade is short the
  /// Instrument’s bid price is used, and for long Trades the ask is used.
  /// </summary>
  public decimal? Distance { get; init; }
}
