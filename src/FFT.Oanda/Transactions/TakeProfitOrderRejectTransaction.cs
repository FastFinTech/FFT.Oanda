// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A TakeProfitOrderRejectTransaction represents the rejection of the
/// creation of a TakeProfit Order.
/// </summary>
public sealed record TakeProfitOrderRejectTransaction : TakeProfitOrderTransaction
{
  /// <summary>
  /// The ID of the Order that this Order was intended to replace (only
  /// provided if this Order was intended to replace an existing Order).
  /// </summary>
  public int? IntendedReplacesOrderID { get; init; }

  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
