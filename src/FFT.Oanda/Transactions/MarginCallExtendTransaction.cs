// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A MarginCallExtendTransaction is created when the margin call state for an
/// Account has been extended.
/// </summary>
public sealed class MarginCallExtendTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="MarginCallExtendTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public MarginCallExtendTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    int extensionNumber)
      : base(
        id,
        time,
        userID,
        accountID,
        batchID,
        requestID,
        type)
  {
    ExtensionNumber = extensionNumber;
  }

  /// <summary>
  /// The number of the extensions to the Account’s current margin call that
  /// have been applied. This value will be set to 1 for the first
  /// MarginCallExtend Transaction.
  /// </summary>
  public int ExtensionNumber { get; }
}
