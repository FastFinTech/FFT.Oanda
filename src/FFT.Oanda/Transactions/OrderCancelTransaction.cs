// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// An OrderCancelTransaction represents the cancellation of an Order in the
/// client’s Account.
/// </summary>
public sealed record OrderCancelTransaction : Transaction
{
  /// <summary>
  /// The ID of the Order cancelled.
  /// </summary>
  public int OrderID { get; init; }

  /// <summary>
  /// The client ID of the Order cancelled (only provided if the Order has a
  /// client Order ID).
  /// </summary>
  public string? ClientOrderID { get; init; }

  /// <summary>
  /// The reason that the Order was cancelled.
  /// </summary>
  public OrderCancelReason Reason { get; init; }

  /// <summary>
  /// The ID of the Order that replaced this Order (only provided if this
  /// Order was cancelled for replacement).
  /// </summary>
  public int? ReplacedByOrderID { get; init; }
}
