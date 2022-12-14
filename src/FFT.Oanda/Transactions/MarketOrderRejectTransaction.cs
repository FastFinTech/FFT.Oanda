// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A MarketOrderRejectTransaction represents the rejection of the creation of
/// a Market Order.
/// </summary>
public sealed record MarketOrderRejectTransaction : MarketOrderTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }
}
