// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// Used to pay or collect a dividend adjustment amount for an open Trade within the Account.
/// </summary>
public sealed record OpenTradeDividendAdjustment
{
  /// <summary>
  /// The ID of the Trade for which the dividend adjustment is to be paid or
  /// collected.
  /// </summary>
  public int TradeId { get; init; }

  /// <summary>
  /// The dividend adjustment amount to pay or collect for the Trade.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal DividentAdjustment { get; init; }

  /// <summary>
  /// The dividend adjustment amount to pay or collect for the Trade, in the
  /// Instrument’s quote currency.
  /// </summary>
  public decimal QuoteDividendAdjustment { get; init; }
}
