// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A MarginCallExitTransaction is created when an Account leaves the margin
  /// call state.
  /// </summary>
  public sealed class MarginCallExitTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MarginCallExitTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public MarginCallExitTransaction(
      string id,
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
