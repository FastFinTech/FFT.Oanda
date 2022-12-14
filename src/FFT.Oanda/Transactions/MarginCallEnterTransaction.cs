// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A MarginCallEnterTransaction is created when an Account enters the margin
/// call state.
/// </summary>
public sealed class MarginCallEnterTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="MarginCallEnterTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public MarginCallEnterTransaction(
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
