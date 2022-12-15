// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.Orders;

/// <summary>
/// Represents the rejection of the creation of
/// a Market Order.
/// </summary>
public sealed record MarketOrderRejectTransaction : OpeningOrderTransaction
{
  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; init; }

  // ---- Fields of the rejected transation

  /// <summary>
  /// The worst price that the client is willing to have the Market Order
  /// filled at.
  /// </summary>
  public decimal PriceBound { get; init; }

  /// <summary>
  /// Details of the Trade requested to be closed, only provided when the
  /// Market Order is being used to explicitly close a Trade.
  /// </summary>
  public MarketOrderTradeClose? TradeClose { get; init; }

  /// <summary>
  /// Details of the long Position requested to be closed out, only provided
  /// when a Market Order is being used to explicitly closeout a long
  /// Position.
  /// </summary>
  public MarketOrderPositionCloseout? LongPositionCloseout { get; init; }

  /// <summary>
  /// Details of the short Position requested to be closed out, only provided
  /// when a Market Order is being used to explicitly closeout a short
  /// Position.
  /// </summary>
  public MarketOrderPositionCloseout? ShortPositionCloseout { get; init; }

  /// <summary>
  /// Details of the Margin Closeout that this Market Order was created for.
  /// </summary>
  public MarketOrderMarginCloseout? MarginCloseout { get; init; }

  /// <summary>
  /// Details of the delayed Trade close that this Market Order was created
  /// for.
  /// </summary>
  public MarketOrderDelayedTradeClose? DelayedTradeClose { get; init; }

  /// <summary>
  /// The reason that the Market Order was created.
  /// </summary>
  public MarketOrderReason Reason { get; init; }
}
