// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A OrderClientExtensionsModifyRejectTransaction represents the rejection of
/// the modification of an Order’s Client Extensions.
/// </summary>
public sealed record OrderClientExtensionsModifyRejectTransaction : OrderClientExtensionsModifyTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
