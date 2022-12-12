// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A ResetResettablePLTransaction represents the resetting of the Account’s
  /// resettable PL counters.
  /// </summary>
  public sealed class ResetResettablePLTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ResetResettablePLTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public ResetResettablePLTransaction(
      int id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
    }
  }
}
