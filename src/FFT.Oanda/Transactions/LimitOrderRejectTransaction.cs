// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A LimitOrderRejectTransaction represents the rejection of the creation of
/// a Limit Order.
/// </summary>
public sealed record LimitOrderRejectTransaction : LimitOrderTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
