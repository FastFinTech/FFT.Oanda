// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A TradeClientExtensionsModifyRejectTransaction represents the rejection of
/// the modification of a Trade’s Client Extensions.
/// </summary>
public sealed record TradeClientExtensionsModifyRejectTransaction : TradeClientExtensionsModifyTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
