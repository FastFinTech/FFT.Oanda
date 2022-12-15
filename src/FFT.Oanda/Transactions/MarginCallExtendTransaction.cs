// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// A MarginCallExtendTransaction is created when the margin call state for an
/// Account has been extended.
/// </summary>
public sealed record MarginCallExtendTransaction : Transaction
{
  /// <summary>
  /// The number of the extensions to the Account’s current margin call that
  /// have been applied. This value will be set to 1 for the first
  /// MarginCallExtend Transaction.
  /// </summary>
  public int ExtensionNumber { get; init; }
}
