// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// An OrderCancelRejectTransaction represents the rejection of the
/// cancellation of an Order in the client’s Account.
/// </summary>
public sealed record OrderCancelRejectTransaction : Transaction
{
  /// <summary>
  /// The ID of the Order intended to be cancelled.
  /// </summary>
  public int OrderID { get; init; }

  /// <summary>
  /// The client ID of the Order intended to be cancelled (only provided if
  /// the Order has a client Order ID).
  /// </summary>
  public string? ClientOrderID { get; init; }

  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
