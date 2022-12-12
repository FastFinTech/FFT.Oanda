// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A CloseTransaction represents the closing of an Account.
  /// </summary>
  public sealed class CloseTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CloseTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public CloseTransaction(
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
