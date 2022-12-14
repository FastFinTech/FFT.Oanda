// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System.Text.Json.Serialization;

/// <summary>
/// The reason that an Order was cancelled.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderCancelReason
{
  /// <summary>
  /// The Order was cancelled because at the time of filling, an unexpected
  /// internal server error occurred.
  /// </summary>
  INTERNAL_SERVER_ERROR,

  /// <summary>
  /// The Order was cancelled because at the time of filling the account was
  /// locked.
  /// </summary>
  ACCOUNT_LOCKED,

  /// <summary>
  /// The order was to be filled, however the account is configured to not
  /// allow new positions to be created.
  /// </summary>
  ACCOUNT_NEW_POSITIONS_LOCKED,

  /// <summary>
  /// Filling the Order wasn’t possible because it required the creation of a
  /// dependent Order and the Account is locked for Order creation.
  /// </summary>
  ACCOUNT_ORDER_CREATION_LOCKED,

  /// <summary>
  /// Filling the Order was not possible because the Account is locked for
  /// filling Orders.
  /// </summary>
  ACCOUNT_ORDER_FILL_LOCKED,

  /// <summary>
  /// The Order was cancelled explicitly at the request of the client.
  /// </summary>
  CLIENT_REQUEST,

  /// <summary>
  /// The Order cancelled because it is being migrated to another account.
  /// </summary>
  MIGRATION,

  /// <summary>
  /// Filling the Order wasn’t possible because the Order’s instrument was
  /// halted.
  /// </summary>
  MARKET_HALTED,

  /// <summary>
  /// The Order is linked to an open Trade that was closed.
  /// </summary>
  LINKED_TRADE_CLOSED,

  /// <summary>
  /// The time in force specified for this order has passed.
  /// </summary>
  TIME_IN_FORCE_EXPIRED,

  /// <summary>
  /// Filling the Order wasn’t possible because the Account had insufficient
  /// margin.
  /// </summary>
  INSUFFICIENT_MARGIN,

  /// <summary>
  /// Filling the Order would have resulted in a a FIFO violation.
  /// </summary>
  FIFO_VIOLATION,

  /// <summary>
  /// Filling the Order would have violated the Order’s price bound.
  /// </summary>
  BOUNDS_VIOLATION,

  /// <summary>
  /// The Order was cancelled for replacement at the request of the client.
  /// </summary>
  CLIENT_REQUEST_REPLACED,

  /// <summary>
  /// The Order was cancelled for replacement with an adjusted fillPrice to
  /// accommodate for the price movement caused by a dividendAdjustment.
  /// </summary>
  DIVIDEND_ADJUSTMENT_REPLACED,

  /// <summary>
  /// Filling the Order wasn’t possible because enough liquidity available.
  /// </summary>
  INSUFFICIENT_LIQUIDITY,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Take Profit
  /// Order with a GTD time in the past.
  /// </summary>
  TAKE_PROFIT_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// Filling the Order would result in the creation of a Take Profit Order
  /// that would have been filled immediately, closing the new Trade at a
  /// loss.
  /// </summary>
  TAKE_PROFIT_ON_FILL_LOSS,

  /// <summary>
  /// Filling the Order would result in the creation of a Take Profit Loss
  /// Order that would close the new Trade at a loss when filled.
  /// </summary>
  LOSING_TAKE_PROFIT,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Stop Loss
  /// Order with a GTD time in the past.
  /// </summary>
  STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// Filling the Order would result in the creation of a Stop Loss Order that
  /// would have been filled immediately, closing the new Trade at a loss.
  /// </summary>
  STOP_LOSS_ON_FILL_LOSS,

  /// <summary>
  /// Filling the Order would result in the creation of a Stop Loss Order
  /// whose price would be zero or negative due to the specified distance.
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// Filling the Order would not result in the creation of Stop Loss Order,
  /// however the Account’s configuration requires that all Trades have a Stop
  /// Loss Order attached to them.
  /// </summary>
  STOP_LOSS_ON_FILL_REQUIRED,

  /// <summary>
  /// Filling the Order would not result in the creation of a guaranteed Stop
  /// Loss Order, however the Account’s configuration requires that all Trades
  /// have a guaranteed Stop Loss Order attached to them.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_REQUIRED,

  /// <summary>
  /// Filling the Order would result in the creation of a guaranteed Stop Loss
  /// Order, however the Account’s configuration does not allow guaranteed
  /// Stop Loss Orders.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_NOT_ALLOWED,

  /// <summary>
  /// Filling the Order would result in the creation of a guaranteed Stop Loss
  /// Order with a distance smaller than the configured minimum distance.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_MINIMUM_DISTANCE_NOT_MET,

  /// <summary>
  /// Filling the Order would result in the creation of a guaranteed Stop Loss
  /// Order with trigger price and number of units that that violates the
  /// account’s guaranteed Stop Loss Order level restriction.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_LEVEL_RESTRICTION_EXCEEDED,

  /// <summary>
  /// Filling the Order would result in the creation of a guaranteed Stop Loss
  /// Order for a hedged Trade, however the Account’s configuration does not
  /// allow guaranteed Stop Loss Orders for hedged Trades/Positions.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_HEDGING_NOT_ALLOWED,

  /// <summary>
  /// Filling the Order would result in the creation of a Stop Loss Order
  /// whose TimeInForce value is invalid. A likely cause would be if the
  /// Account requires guaranteed stop loss orders and the TimeInForce value
  /// were not GTC.
  /// </summary>
  STOP_LOSS_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// Filling the Order would result in the creation of a Stop Loss Order
  /// whose TriggerCondition value is invalid. A likely cause would be if the
  /// stop loss order is guaranteed and the TimeInForce is not TRIGGER_DEFAULT
  /// or TRIGGER_BID for a long trade, or not TRIGGER_DEFAULT or TRIGGER_ASK
  /// for a short trade.
  /// </summary>
  STOP_LOSS_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Guaranteed
  /// Stop Loss Order with a GTD time in the past.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order that would have been filled immediately, closing the new Trade at
  /// a loss.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_LOSS,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order whose price would be zero or negative due to the specified
  /// distance.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// Filling the Order would not result in the creation of a Guaranteed Stop
  /// Loss Order, however the Account’s configuration requires that all Trades
  /// have a Guaranteed Stop Loss Order attached to them.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_REQUIRED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order, however the Account’s configuration does not allow Guaranteed
  /// Stop Loss Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_NOT_ALLOWED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order with a distance smaller than the configured minimum distance.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_MINIMUM_DISTANCE_NOT_MET,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order with trigger number of units that violates the account’s
  /// Guaranteed Stop Loss Order level restriction volume.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_LEVEL_RESTRICTION_VOLUME_EXCEEDED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order with trigger price that violates the account’s Guaranteed Stop
  /// Loss Order level restriction price range.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_LEVEL_RESTRICTION_PRICE_RANGE_EXCEEDED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order for a hedged Trade, however the Account’s configuration does not
  /// allow Guaranteed Stop Loss Orders for hedged Trades/Positions.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_HEDGING_NOT_ALLOWED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order whose TimeInForce value is invalid. A likely cause would be if the
  /// Account requires guaranteed stop loss orders and the TimeInForce value
  /// were not GTC.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order whose TriggerCondition value is invalid. A likely cause would be
  /// the TimeInForce is not TRIGGER_DEFAULT or TRIGGER_BID for a long trade,
  /// or not TRIGGER_DEFAULT or TRIGGER_ASK for a short trade.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// Filling the Order would result in the creation of a Take Profit Order
  /// whose price would be zero or negative due to the specified distance.
  /// </summary>
  TAKE_PROFIT_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Trailing Stop
  /// Loss Order with a GTD time in the past.
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// Filling the Order would result in the creation of a new Open Trade with
  /// a client Trade ID already in use.
  /// </summary>
  CLIENT_TRADE_ID_ALREADY_EXISTS,

  /// <summary>
  /// Closing out a position wasn’t fully possible.
  /// </summary>
  POSITION_CLOSEOUT_FAILED,

  /// <summary>
  /// Filling the Order would cause the maximum open trades allowed for the
  /// Account to be exceeded.
  /// </summary>
  OPEN_TRADES_ALLOWED_EXCEEDED,

  /// <summary>
  /// Filling the Order would have resulted in exceeding the number of pending
  /// Orders allowed for the Account.
  /// </summary>
  PENDING_ORDERS_ALLOWED_EXCEEDED,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Take Profit
  /// Order with a client Order ID that is already in use.
  /// </summary>
  TAKE_PROFIT_ON_FILL_CLIENT_ORDER_ID_ALREADY_EXISTS,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Stop Loss
  /// Order with a client Order ID that is already in use.
  /// </summary>
  STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_ALREADY_EXISTS,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Guaranteed
  /// Stop Loss Order with a client Order ID that is already in use.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_ALREADY_EXISTS,

  /// <summary>
  /// Filling the Order would have resulted in the creation of a Trailing Stop
  /// Loss Order with a client Order ID that is already in use.
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_ALREADY_EXISTS,

  /// <summary>
  /// Filling the Order would have resulted in the Account’s maximum position
  /// size limit being exceeded for the Order’s instrument.
  /// </summary>
  POSITION_SIZE_EXCEEDED,

  /// <summary>
  /// Filling the Order would result in the creation of a Trade, however there
  /// already exists an opposing (hedged) Trade that has a guaranteed Stop
  /// Loss Order attached to it. Guaranteed Stop Loss Orders cannot be
  /// combined with hedged positions.
  /// </summary>
  HEDGING_GSLO_VIOLATION,

  /// <summary>
  /// Filling the order would cause the maximum position value allowed for the
  /// account to be exceeded. The Order has been cancelled as a result.
  /// </summary>
  ACCOUNT_POSITION_VALUE_LIMIT_EXCEEDED,

  /// <summary>
  /// Filling the order would require the creation of a short trade, however
  /// the instrument is configured such that orders being filled using bid
  /// prices can only reduce existing positions. New short positions cannot be
  /// created, but existing long positions may be reduced or closed.
  /// </summary>
  INSTRUMENT_BID_REDUCE_ONLY,

  /// <summary>
  /// Filling the order would require the creation of a long trade, however
  /// the instrument is configured such that orders being filled using ask
  /// prices can only reduce existing positions. New long positions cannot be
  /// created, but existing short positions may be reduced or closed.
  /// </summary>
  INSTRUMENT_ASK_REDUCE_ONLY,

  /// <summary>
  /// Filling the order would require using the bid, however the instrument is
  /// configured such that the bids are halted, and so no short orders may be
  /// filled.
  /// </summary>
  INSTRUMENT_BID_HALTED,

  /// <summary>
  /// Filling the order would require using the ask, however the instrument is
  /// configured such that the asks are halted, and so no long orders may be
  /// filled.
  /// </summary>
  INSTRUMENT_ASK_HALTED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order (GSLO). Since the trade is long the GSLO would be short, however
  /// the bid side is currently halted. GSLOs cannot be created in this
  /// situation.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_BID_HALTED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order (GSLO). Since the trade is short the GSLO would be long, however
  /// the ask side is currently halted. GSLOs cannot be created in this
  /// situation.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_ASK_HALTED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order (GSLO). Since the trade is long the GSLO would be short, however
  /// the bid side is currently halted. GSLOs cannot be created in this
  /// situation.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_BID_HALTED,

  /// <summary>
  /// Filling the Order would result in the creation of a Guaranteed Stop Loss
  /// Order (GSLO). Since the trade is short the GSLO would be long, however
  /// the ask side is currently halted. GSLOs cannot be created in this
  /// situation.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_ASK_HALTED,

  /// <summary>
  /// Filling the Order would have resulted in a new Trade that violates the
  /// FIFO violation safeguard constraints.
  /// </summary>
  FIFO_VIOLATION_SAFEGUARD_VIOLATION,

  /// <summary>
  /// Filling the Order would have reduced an existing Trade such that the
  /// reduced Trade violates the FIFO violation safeguard constraints.
  /// </summary>
  FIFO_VIOLATION_SAFEGUARD_PARTIAL_CLOSE_VIOLATION,

  /// <summary>
  /// The Orders on fill would be in violation of the risk management Order
  /// mutual exclusivity configuration specifying that only one risk
  /// management Order can be attached to a Trade.
  /// </summary>
  ORDERS_ON_FILL_RMO_MUTUAL_EXCLUSIVITY_MUTUALLY_EXCLUSIVE_VIOLATION,
}
