// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A DailyFinancingTransaction represents the daily payment/collection of
  /// financing for an Account.
  /// </summary>
  public sealed class DailyFinancingTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DailyFinancingTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public DailyFinancingTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      decimal financing,
      decimal accountBalance,
      ImmutableList<PositionFinancing> positionFinancings)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      Financing = financing;
      AccountBalance = accountBalance;
      PositionFinancings = positionFinancings;
    }

    /// <summary>
    /// The amount of financing paid/collected for the Account. Expressed in the
    /// account's home currency.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The Account’s balance after daily financing. Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal AccountBalance { get; }

    /// <summary>
    /// The financing paid/collected for each Position in the Account.
    /// </summary>
    public ImmutableList<PositionFinancing> PositionFinancings { get; }
  }
}
