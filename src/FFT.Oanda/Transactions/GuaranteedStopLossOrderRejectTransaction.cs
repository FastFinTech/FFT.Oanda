// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda.Orders;

/// <summary>
/// A GuaranteedStopLossOrderRejectTransaction represents the rejection of the
/// creation of a GuaranteedStopLoss Order.
/// </summary>
public sealed record GuaranteedStopLossOrderRejectTransaction : TradeRelatedOrderTransaction
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

  // ------ Here's the rejected transaction fields

  // TODO: I'm pretty sure this fits into the category of "price and distance
  // cannot both be set". However, the spec says "price" is required. I'm apt
  // to believe this is untrue, and we need to test what happens when a
  // guaranteed stop loss order is created with distance instead of price.

  /// <summary>
  /// The price threshold specified for the Guaranteed Stop Loss Order. The
  /// associated Trade will be closed at this price.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// Specifies the distance (in price units) from the Account’s current price
  /// to use as the Guaranteed Stop Loss Order price. If the Trade is short the
  /// Instrument’s bid price is used, and for long Trades the ask is used.
  /// </summary>
  public decimal? Distance { get; init; }

  /// <summary>
  /// Specification of which price component should be used when determining if
  /// an Order should be triggered and filled. This allows Orders to be
  /// triggered based on the bid, ask, mid, default (ask for buy, bid for sell)
  /// or inverse (ask for sell, bid for buy) price depending on the desired
  /// behaviour. Orders are always filled using their default price component.
  /// This feature is only provided through the REST API. Clients who choose to
  /// specify a non-default trigger condition will not see it reflected in any
  /// of OANDA’s proprietary or partner trading platforms, their transaction
  /// history or their account statements. OANDA platforms always assume that
  /// an Order’s trigger condition is set to the default value when indicating
  /// the distance from an Order’s trigger price, and will always provide the
  /// default trigger condition when creating or modifying an Order. A special
  /// restriction applies when creating a Guaranteed Stop Loss Order. In this
  /// case the TriggerCondition value must either be “DEFAULT”, or the
  /// “natural” trigger side “DEFAULT” results in. So for a Guaranteed Stop
  /// Loss Order for a long trade valid values are “DEFAULT” and “BID”, and for
  /// short trades “DEFAULT” and “ASK” are valid.
  /// </summary>
  public OrderTriggerCondition TriggerCondition { get; init; }

  /// <summary>
  /// The fee that will be charged if the Guaranteed Stop Loss Order is filled
  /// at the guaranteed price. The value is determined at Order creation time.
  /// It is in price units and is charged for each unit of the Trade.
  /// </summary>
  public decimal? GuaranteedExecutionPremium { get; init; }

  /// <summary>
  /// The reason that the Guaranteed Stop Loss Order was initiated.
  /// </summary>
  public GuaranteedStopLossOrderReason Reason { get; init; }

  /// <summary>
  /// The ID of the OrderFill Transaction that caused this Order to be created
  /// (only provided if this Order was created automatically when another Order
  /// was filled).
  /// </summary>
  public int? OrderFillTransactionID { get; init; }

}
