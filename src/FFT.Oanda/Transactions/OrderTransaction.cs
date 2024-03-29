﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.Orders;

/// <summary>
/// Base class for transactions related to orders.
/// </summary>
public abstract record OrderTransaction : Transaction
{
  /// <summary>
  /// Client Extensions to add to the Order (only provided if the Order is
  /// being created with client extensions).
  /// </summary>
  public ClientExtensions? ClientExtensions { get; init; }

  /// <summary>
  /// The ID of the Order that this Order replaces (only provided if this
  /// Order replaces an existing Order).
  /// </summary>
  public int? ReplacesOrderID { get; init; }

  /// <summary>
  /// The ID of the Transaction that cancels the replaced Order (only provided
  /// if this Order replaces an existing Order).
  /// </summary>
  public int? CancellingTransactionID { get; init; }

  // TODO: Fixed price orders do not have a time in force property. Check if
  // this makes a difference, and check for runtime errors related to this.
  // Also check for other order transaction types that should not have this
  // property.

  /// <summary>
  /// The time-in-force requested for the Order.
  /// </summary>
  public TimeInForce TimeInForce { get; init; }

  /// <summary>
  /// The date/time when the Order will be cancelled if its timeInForce is
  /// “GTD”.
  /// </summary>
  public DateTime? GtdTime { get; init; }
}
