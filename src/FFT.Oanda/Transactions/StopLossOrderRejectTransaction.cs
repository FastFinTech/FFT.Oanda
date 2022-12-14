// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A StopLossOrderRejectTransaction represents the rejection of the creation
/// of a StopLoss Order.
/// </summary>
public sealed record StopLossOrderRejectTransaction : TradeRelatedOrderTransaction
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

  // ----- Fields of the rejected transaction

  /// <summary>
  /// The price threshold specified for the Stop Loss Order. The associated
  /// Trade will be closed by a market price that is equal to or worse than
  /// this threshold.
  /// </summary>
  public decimal? Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Account’s current price
  /// to use as the Stop Loss Order price. If the Trade is short the
  /// Instrument’s bid price is used, and for long Trades the ask is used.
  /// </summary>
  public decimal? Distance { get; init; }
}
