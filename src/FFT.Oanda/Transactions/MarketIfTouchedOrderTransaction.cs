// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using FFT.Oanda.Orders;

/// <summary>
/// A MarketIfTouchedOrderTransaction represents the creation of a
/// MarketIfTouched Order in the user’s Account.
/// </summary>
public record MarketIfTouchedOrderTransaction : OpeningOrderTransaction
{
  /// <summary>
  /// The price threshold specified for the MarketIfTouched Order. The
  /// MarketIfTouched Order will only be filled by a market price that crosses
  /// this price from the direction of the market price at the time when the
  /// Order was created (the initialMarketPrice). Depending on the value of
  /// the Order’s price and initialMarketPrice, the MarketIfTouchedOrder will
  /// behave like a Limit or a Stop Order.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The worst market price that may be used to fill this MarketIfTouched
  /// Order.
  /// </summary>
  public decimal? PriceBound { get; init; }

  /// <summary>
  /// Specification of which price component should be used when determining
  /// if an Order should be triggered and filled. This allows Orders to be
  /// triggered based on the bid, ask, mid, default (ask for buy, bid for
  /// sell) or inverse (ask for sell, bid for buy) price depending on the
  /// desired behaviour. Orders are always filled using their default price
  /// component. This feature is only provided through the REST API. Clients
  /// who choose to specify a non-default trigger condition will not see it
  /// reflected in any of OANDA’s proprietary or partner trading platforms,
  /// their transaction history or their account statements. OANDA platforms
  /// always assume that an Order’s trigger condition is set to the default
  /// value when indicating the distance from an Order’s trigger price, and
  /// will always provide the default trigger condition when creating or
  /// modifying an Order. A special restriction applies when creating a
  /// Guaranteed Stop Loss Order. In this case the TriggerCondition value must
  /// either be “DEFAULT”, or the“natural” trigger side “DEFAULT” results in.
  /// So for a Guaranteed Stop Loss Order for a long trade valid values are
  /// “DEFAULT” and “BID”, and for short trades “DEFAULT” and “ASK” are valid.
  /// </summary>
  public OrderTriggerCondition TriggerCondition { get; init; }

  /// <summary>
  /// The reason that the Market-if-touched Order was initiated.
  /// </summary>
  public MarketIfTouchedOrderReason Reason { get; init; }
}
