// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A DailyFinancingTransaction represents the daily payment/collection of
/// financing for an Account.
/// </summary>
public sealed record DailyFinancingTransaction : Transaction
{
  /// <summary>
  /// The amount of financing paid/collected for the Account. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The Account’s balance after daily financing. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal AccountBalance { get; init; }

  /// <summary>
  /// The financing paid/collected for each Position in the Account.
  /// </summary>
  public ImmutableList<PositionFinancing> PositionFinancings { get; init; }
}
