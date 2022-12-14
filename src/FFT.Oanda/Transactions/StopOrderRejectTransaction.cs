// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A StopOrderRejectTransaction represents the rejection of the creation of a
/// Stop Order.
/// </summary>
public sealed record StopOrderRejectTransaction : StopOrderTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
