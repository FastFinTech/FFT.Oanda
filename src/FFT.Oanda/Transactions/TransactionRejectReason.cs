// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

/// <summary>
/// The reason that a Transaction was rejected.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionRejectReason
{
  /// <summary>
  /// An unexpected internal server error has occurred
  /// </summary>
  INTERNAL_SERVER_ERROR,

  /// <summary>
  /// The system was unable to determine the current price for the Order’s
  /// instrument
  /// </summary>
  INSTRUMENT_PRICE_UNKNOWN,

  /// <summary>
  /// The Account is not active
  /// </summary>
  ACCOUNT_NOT_ACTIVE,

  /// <summary>
  /// The Account is locked
  /// </summary>
  ACCOUNT_LOCKED,

  /// <summary>
  /// The Account is locked for Order creation
  /// </summary>
  ACCOUNT_ORDER_CREATION_LOCKED,

  /// <summary>
  /// The Account is locked for configuration
  /// </summary>
  ACCOUNT_CONFIGURATION_LOCKED,

  /// <summary>
  /// The Account is locked for deposits
  /// </summary>
  ACCOUNT_DEPOSIT_LOCKED,

  /// <summary>
  /// The Account is locked for withdrawals
  /// </summary>
  ACCOUNT_WITHDRAWAL_LOCKED,

  /// <summary>
  /// The Account is locked for Order cancellation
  /// </summary>
  ACCOUNT_ORDER_CANCEL_LOCKED,

  /// <summary>
  /// The instrument specified is not tradeable by the Account
  /// </summary>
  INSTRUMENT_NOT_TRADEABLE,

  /// <summary>
  /// Creating the Order would result in the maximum number of allowed pending
  /// Orders being exceeded
  /// </summary>
  PENDING_ORDERS_ALLOWED_EXCEEDED,

  /// <summary>
  /// Neither the Order ID nor client Order ID are specified
  /// </summary>
  ORDER_ID_UNSPECIFIED,

  /// <summary>
  /// The Order specified does not exist
  /// </summary>
  ORDER_DOESNT_EXIST,

  /// <summary>
  /// The Order ID and client Order ID specified do not identify the same
  /// Order
  /// </summary>
  ORDER_IDENTIFIER_INCONSISTENCY,

  /// <summary>
  /// Neither the Trade ID nor client Trade ID are specified
  /// </summary>
  TRADE_ID_UNSPECIFIED,

  /// <summary>
  /// The Trade specified does not exist
  /// </summary>
  TRADE_DOESNT_EXIST,

  /// <summary>
  /// The Trade ID and client Trade ID specified do not identify the same
  /// Trade
  /// </summary>
  TRADE_IDENTIFIER_INCONSISTENCY,

  /// <summary>
  /// The Account had insufficient margin to perform the action specified. One
  /// possible reason for this is due to the creation or modification of a
  /// guaranteed StopLoss Order.
  /// </summary>
  INSUFFICIENT_MARGIN,

  /// <summary>
  /// Order instrument has not been specified
  /// </summary>
  INSTRUMENT_MISSING,

  /// <summary>
  /// The instrument specified is unknown
  /// </summary>
  INSTRUMENT_UNKNOWN,

  /// <summary>
  /// Order units have not been not specified
  /// </summary>
  UNITS_MISSING,

  /// <summary>
  /// Order units specified are invalid
  /// </summary>
  UNITS_INVALID,

  /// <summary>
  /// The units specified contain more precision than is allowed for the
  /// Order’s instrument
  /// </summary>
  UNITS_PRECISION_EXCEEDED,

  /// <summary>
  /// The units specified exceeds the maximum number of units allowed
  /// </summary>
  UNITS_LIMIT_EXCEEDED,

  /// <summary>
  /// The units specified is less than the minimum number of units required
  /// </summary>
  UNITS_MINIMUM_NOT_MET,

  /// <summary>
  /// The price has not been specified
  /// </summary>
  PRICE_MISSING,

  /// <summary>
  /// The price specified is invalid
  /// </summary>
  PRICE_INVALID,

  /// <summary>
  /// The price specified contains more precision than is allowed for the
  /// instrument
  /// </summary>
  PRICE_PRECISION_EXCEEDED,

  /// <summary>
  /// The price distance has not been specified
  /// </summary>
  PRICE_DISTANCE_MISSING,

  /// <summary>
  /// The price distance specified is invalid
  /// </summary>
  PRICE_DISTANCE_INVALID,

  /// <summary>
  /// The price distance specified contains more precision than is allowed for
  /// the instrument
  /// </summary>
  PRICE_DISTANCE_PRECISION_EXCEEDED,

  /// <summary>
  /// The price distance exceeds that maximum allowed amount
  /// </summary>
  PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// The price distance does not meet the minimum allowed amount
  /// </summary>
  PRICE_DISTANCE_MINIMUM_NOT_MET,

  /// <summary>
  /// The TimeInForce field has not been specified
  /// </summary>
  TIME_IN_FORCE_MISSING,

  /// <summary>
  /// The TimeInForce specified is invalid
  /// </summary>
  TIME_IN_FORCE_INVALID,

  /// <summary>
  /// The TimeInForce is GTD but no GTD timestamp is provided
  /// </summary>
  TIME_IN_FORCE_GTD_TIMESTAMP_MISSING,

  /// <summary>
  /// The TimeInForce is GTD but the GTD timestamp is in the past
  /// </summary>
  TIME_IN_FORCE_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// The price bound specified is invalid
  /// </summary>
  PRICE_BOUND_INVALID,

  /// <summary>
  /// The price bound specified contains more precision than is allowed for
  /// the Order’s instrument
  /// </summary>
  PRICE_BOUND_PRECISION_EXCEEDED,

  /// <summary>
  /// Multiple Orders on fill share the same client Order ID
  /// </summary>
  ORDERS_ON_FILL_DUPLICATE_CLIENT_ORDER_IDS,

  /// <summary>
  /// The Order does not support Trade on fill client extensions because it
  /// cannot create a new Trade
  /// </summary>
  TRADE_ON_FILL_CLIENT_EXTENSIONS_NOT_SUPPORTED,

  /// <summary>
  /// The client Order ID specified is invalid
  /// </summary>
  CLIENT_ORDER_ID_INVALID,

  /// <summary>
  /// The client Order ID specified is already assigned to another pending
  /// Order
  /// </summary>
  CLIENT_ORDER_ID_ALREADY_EXISTS,

  /// <summary>
  /// The client Order tag specified is invalid
  /// </summary>
  CLIENT_ORDER_TAG_INVALID,

  /// <summary>
  /// The client Order comment specified is invalid
  /// </summary>
  CLIENT_ORDER_COMMENT_INVALID,

  /// <summary>
  /// The client Trade ID specified is invalid
  /// </summary>
  CLIENT_TRADE_ID_INVALID,

  /// <summary>
  /// The client Trade ID specified is already assigned to another open Trade
  /// </summary>
  CLIENT_TRADE_ID_ALREADY_EXISTS,

  /// <summary>
  /// The client Trade tag specified is invalid
  /// </summary>
  CLIENT_TRADE_TAG_INVALID,

  /// <summary>
  /// The client Trade comment is invalid
  /// </summary>
  CLIENT_TRADE_COMMENT_INVALID,

  /// <summary>
  /// The OrderFillPositionAction field has not been specified
  /// </summary>
  ORDER_FILL_POSITION_ACTION_MISSING,

  /// <summary>
  /// The OrderFillPositionAction specified is invalid
  /// </summary>
  ORDER_FILL_POSITION_ACTION_INVALID,

  /// <summary>
  /// The TriggerCondition field has not been specified
  /// </summary>
  TRIGGER_CONDITION_MISSING,

  /// <summary>
  /// The TriggerCondition specified is invalid
  /// </summary>
  TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// The OrderFillPositionAction field has not been specified
  /// </summary>
  ORDER_PARTIAL_FILL_OPTION_MISSING,

  /// <summary>
  /// The OrderFillPositionAction specified is invalid.
  /// </summary>
  ORDER_PARTIAL_FILL_OPTION_INVALID,

  /// <summary>
  /// When attempting to reissue an order (currently only a MarketIfTouched)
  /// that was immediately partially filled, it is not possible to create a
  /// correct pending Order.
  /// </summary>
  INVALID_REISSUE_IMMEDIATE_PARTIAL_FILL,

  /// <summary>
  /// The Orders on fill would be in violation of the risk management Order
  /// mutual exclusivity configuration specifying that only one risk
  /// management Order can be attached to a Trade.
  /// </summary>
  ORDERS_ON_FILL_RMO_MUTUAL_EXCLUSIVITY_MUTUALLY_EXCLUSIVE_VIOLATION,

  /// <summary>
  /// The Orders on fill would be in violation of the risk management Order
  /// mutual exclusivity configuration specifying that if a GSLO is already
  /// attached to a Trade, no other risk management Order can be attached to a
  /// Trade.
  /// </summary>
  ORDERS_ON_FILL_RMO_MUTUAL_EXCLUSIVITY_GSLO_EXCLUDES_OTHERS_VIOLATION,

  /// <summary>
  /// A Take Profit Order for the specified Trade already exists
  /// </summary>
  TAKE_PROFIT_ORDER_ALREADY_EXISTS,

  /// <summary>
  /// The Take Profit Order would cause the associated Trade to be in
  /// violation of the FIFO violation safeguard constraints.
  /// </summary>
  TAKE_PROFIT_ORDER_WOULD_VIOLATE_FIFO_VIOLATION_SAFEGUARD,

  /// <summary>
  /// The Take Profit on fill specified does not provide a price
  /// </summary>
  TAKE_PROFIT_ON_FILL_PRICE_MISSING,

  /// <summary>
  /// The Take Profit on fill specified contains an invalid price
  /// </summary>
  TAKE_PROFIT_ON_FILL_PRICE_INVALID,

  /// <summary>
  /// The Take Profit on fill specified contains a price with more precision
  /// than is allowed by the Order’s instrument
  /// </summary>
  TAKE_PROFIT_ON_FILL_PRICE_PRECISION_EXCEEDED,

  /// <summary>
  /// The Take Profit on fill specified does not provide a TimeInForce
  /// </summary>
  TAKE_PROFIT_ON_FILL_TIME_IN_FORCE_MISSING,

  /// <summary>
  /// The Take Profit on fill specifies an invalid TimeInForce
  /// </summary>
  TAKE_PROFIT_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// The Take Profit on fill specifies a GTD TimeInForce but does not provide
  /// a GTD timestamp
  /// </summary>
  TAKE_PROFIT_ON_FILL_GTD_TIMESTAMP_MISSING,

  /// <summary>
  /// The Take Profit on fill specifies a GTD timestamp that is in the past
  /// </summary>
  TAKE_PROFIT_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// The Take Profit on fill client Order ID specified is invalid
  /// </summary>
  TAKE_PROFIT_ON_FILL_CLIENT_ORDER_ID_INVALID,

  /// <summary>
  /// The Take Profit on fill client Order tag specified is invalid
  /// </summary>
  TAKE_PROFIT_ON_FILL_CLIENT_ORDER_TAG_INVALID,

  /// <summary>
  /// The Take Profit on fill client Order comment specified is invalid
  /// </summary>
  TAKE_PROFIT_ON_FILL_CLIENT_ORDER_COMMENT_INVALID,

  /// <summary>
  /// The Take Profit on fill specified does not provide a TriggerCondition
  /// </summary>
  TAKE_PROFIT_ON_FILL_TRIGGER_CONDITION_MISSING,

  /// <summary>
  /// The Take Profit on fill specifies an invalid TriggerCondition
  /// </summary>
  TAKE_PROFIT_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// A Stop Loss Order for the specified Trade already exists
  /// </summary>
  STOP_LOSS_ORDER_ALREADY_EXISTS,

  /// <summary>
  /// An attempt was made to to create a non-guaranteed stop loss order in an
  /// account that requires all stop loss orders to be guaranteed.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_REQUIRED,

  /// <summary>
  /// An attempt to create a guaranteed stop loss order with a price that is
  /// within the current tradeable spread.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_PRICE_WITHIN_SPREAD,

  /// <summary>
  /// An attempt was made to create a guaranteed Stop Loss Order, however the
  /// Account’s configuration does not allow guaranteed Stop Loss Orders.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_NOT_ALLOWED,

  /// <summary>
  /// An attempt was made to create a guaranteed Stop Loss Order when the
  /// market was halted.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_HALTED_CREATE_VIOLATION,

  /// <summary>
  /// An attempt was made to re-create a guaranteed Stop Loss Order with a
  /// tighter fill price when the market was halted.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_HALTED_TIGHTEN_VIOLATION,

  /// <summary>
  /// An attempt was made to create a guaranteed Stop Loss Order on a hedged
  /// Trade (ie there is an existing open Trade in the opposing direction),
  /// however the Account’s configuration does not allow guaranteed Stop Loss
  /// Orders for hedged Trades/Positions.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_HEDGING_NOT_ALLOWED,

  /// <summary>
  /// An attempt was made to create a guaranteed Stop Loss Order, however the
  /// distance between the current price and the trigger price does not meet
  /// the Account’s configured minimum Guaranteed Stop Loss distance.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_MINIMUM_DISTANCE_NOT_MET,

  /// <summary>
  /// An attempt was made to cancel a Stop Loss Order, however the Account’s
  /// configuration requires every Trade have an associated Stop Loss Order.
  /// </summary>
  STOP_LOSS_ORDER_NOT_CANCELABLE,

  /// <summary>
  /// An attempt was made to cancel and replace a Stop Loss Order, however the
  /// Account’s configuration prevents the modification of Stop Loss Orders.
  /// </summary>
  STOP_LOSS_ORDER_NOT_REPLACEABLE,

  /// <summary>
  /// An attempt was made to create a guaranteed Stop Loss Order, however
  /// doing so would exceed the Account’s configured guaranteed StopLoss Order
  /// level restriction volume.
  /// </summary>
  STOP_LOSS_ORDER_GUARANTEED_LEVEL_RESTRICTION_EXCEEDED,

  /// <summary>
  /// The Stop Loss Order request contains both the price and distance fields.
  /// </summary>
  STOP_LOSS_ORDER_PRICE_AND_DISTANCE_BOTH_SPECIFIED,

  /// <summary>
  /// The Stop Loss Order request contains neither the price nor distance
  /// fields.
  /// </summary>
  STOP_LOSS_ORDER_PRICE_AND_DISTANCE_BOTH_MISSING,

  /// <summary>
  /// The Stop Loss Order would cause the associated Trade to be in violation
  /// of the FIFO violation safeguard constraints
  /// </summary>
  STOP_LOSS_ORDER_WOULD_VIOLATE_FIFO_VIOLATION_SAFEGUARD,

  /// <summary>
  /// The Stop Loss Order would be in violation of the risk management Order
  /// mutual exclusivity configuration specifying that only one risk
  /// management order can be attached to a Trade.
  /// </summary>
  STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_MUTUALLY_EXCLUSIVE_VIOLATION,

  /// <summary>
  /// The Stop Loss Order would be in violation of the risk management Order
  /// mutual exclusivity configuration specifying that if a GSLO is already
  /// attached to a Trade, no other risk management Order can be attached to
  /// the same Trade.
  /// </summary>
  STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_GSLO_EXCLUDES_OTHERS_VIOLATION,

  /// <summary>
  /// An attempt to create a pending Order was made with no Stop Loss Order on
  /// fill specified and the Account’s configuration requires that every Trade
  /// have an associated Stop Loss Order.
  /// </summary>
  STOP_LOSS_ON_FILL_REQUIRED_FOR_PENDING_ORDER,

  /// <summary>
  /// An attempt to create a pending Order was made with a Stop Loss Order on
  /// fill that was explicitly configured to be guaranteed, however the
  /// Account’s configuration does not allow guaranteed Stop Loss Orders.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_NOT_ALLOWED,

  /// <summary>
  /// An attempt to create a pending Order was made with a Stop Loss Order on
  /// fill that was explicitly configured to be not guaranteed, however the
  /// Account’s configuration requires guaranteed Stop Loss Orders.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_REQUIRED,

  /// <summary>
  /// The Stop Loss on fill specified does not provide a price
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_MISSING,

  /// <summary>
  /// The Stop Loss on fill specifies an invalid price
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_INVALID,

  /// <summary>
  /// The Stop Loss on fill specifies a price with more precision than is
  /// allowed by the Order’s instrument
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_PRECISION_EXCEEDED,

  /// <summary>
  /// An attempt to create a pending Order was made with the distance between
  /// the guaranteed Stop Loss Order on fill’s price and the pending Order’s
  /// price is less than the Account’s configured minimum guaranteed stop loss
  /// distance.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_MINIMUM_DISTANCE_NOT_MET,

  /// <summary>
  /// An attempt to create a pending Order was made with a guaranteed Stop
  /// Loss Order on fill configured, and the Order’s units exceed the
  /// Account’s configured guaranteed StopLoss Order level restriction volume.
  /// </summary>
  STOP_LOSS_ON_FILL_GUARANTEED_LEVEL_RESTRICTION_EXCEEDED,

  /// <summary>
  /// The Stop Loss on fill distance is invalid
  /// </summary>
  STOP_LOSS_ON_FILL_DISTANCE_INVALID,

  /// <summary>
  /// The Stop Loss on fill price distance exceeds the maximum allowed amount
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// The Stop Loss on fill distance contains more precision than is allowed
  /// by the instrument
  /// </summary>
  STOP_LOSS_ON_FILL_DISTANCE_PRECISION_EXCEEDED,

  /// <summary>
  /// The Stop Loss on fill contains both the price and distance fields.
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_AND_DISTANCE_BOTH_SPECIFIED,

  /// <summary>
  /// The Stop Loss on fill contains neither the price nor distance fields.
  /// </summary>
  STOP_LOSS_ON_FILL_PRICE_AND_DISTANCE_BOTH_MISSING,

  /// <summary>
  /// The Stop Loss on fill specified does not provide a TimeInForce
  /// </summary>
  STOP_LOSS_ON_FILL_TIME_IN_FORCE_MISSING,

  /// <summary>
  /// The Stop Loss on fill specifies an invalid TimeInForce
  /// </summary>
  STOP_LOSS_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// The Stop Loss on fill specifies a GTD TimeInForce but does not provide a
  /// GTD timestamp
  /// </summary>
  STOP_LOSS_ON_FILL_GTD_TIMESTAMP_MISSING,

  /// <summary>
  /// The Stop Loss on fill specifies a GTD timestamp that is in the past
  /// </summary>
  STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// The Stop Loss on fill client Order ID specified is invalid
  /// </summary>
  STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_INVALID,

  /// <summary>
  /// The Stop Loss on fill client Order tag specified is invalid
  /// </summary>
  STOP_LOSS_ON_FILL_CLIENT_ORDER_TAG_INVALID,

  /// <summary>
  /// The Stop Loss on fill client Order comment specified is invalid
  /// </summary>
  STOP_LOSS_ON_FILL_CLIENT_ORDER_COMMENT_INVALID,

  /// <summary>
  /// The Stop Loss on fill specified does not provide a TriggerCondition
  /// </summary>
  STOP_LOSS_ON_FILL_TRIGGER_CONDITION_MISSING,

  /// <summary>
  /// The Stop Loss on fill specifies an invalid TriggerCondition
  /// </summary>
  STOP_LOSS_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// A Guaranteed Stop Loss Order for the specified Trade already exists
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_ALREADY_EXISTS,

  /// <summary>
  /// An attempt was made to to create a non-guaranteed stop loss order in an
  /// account that requires all stop loss orders to be guaranteed.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_REQUIRED,

  /// <summary>
  /// An attempt to create a guaranteed stop loss order with a price that is
  /// within the current tradeable spread.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_PRICE_WITHIN_SPREAD,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order, however the
  /// Account’s configuration does not allow Guaranteed Stop Loss Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_NOT_ALLOWED,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order when the
  /// market was halted.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_HALTED_CREATE_VIOLATION,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order when the
  /// market was open.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_CREATE_VIOLATION,

  /// <summary>
  /// An attempt was made to re-create a Guaranteed Stop Loss Order with a
  /// tighter fill price when the market was halted.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_HALTED_TIGHTEN_VIOLATION,

  /// <summary>
  /// An attempt was made to re-create a Guaranteed Stop Loss Order with a
  /// tighter fill price when the market was open.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_TIGHTEN_VIOLATION,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order on a hedged
  /// Trade (ie there is an existing open Trade in the opposing direction),
  /// however the Account’s configuration does not allow Guaranteed Stop Loss
  /// Orders for hedged Trades/Positions.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_HEDGING_NOT_ALLOWED,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order, however the
  /// distance between the current price and the trigger price does not meet
  /// the Account’s configured minimum Guaranteed Stop Loss distance.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_MINIMUM_DISTANCE_NOT_MET,

  /// <summary>
  /// An attempt was made to cancel a Guaranteed Stop Loss Order when the
  /// market is open, however the Account’s configuration requires every Trade
  /// have an associated Guaranteed Stop Loss Order.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_NOT_CANCELABLE,

  /// <summary>
  /// An attempt was made to cancel a Guaranteed Stop Loss Order when the
  /// market is halted, however the Account’s configuration requires every
  /// Trade have an associated Guaranteed Stop Loss Order.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_HALTED_NOT_CANCELABLE,

  /// <summary>
  /// An attempt was made to cancel and replace a Guaranteed Stop Loss Order
  /// when the market is open, however the Account’s configuration prevents
  /// the modification of Guaranteed Stop Loss Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_NOT_REPLACEABLE,

  /// <summary>
  /// An attempt was made to cancel and replace a Guaranteed Stop Loss Order
  /// when the market is halted, however the Account’s configuration prevents
  /// the modification of Guaranteed Stop Loss Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_HALTED_NOT_REPLACEABLE,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order, however
  /// doing so would exceed the Account’s configured guaranteed StopLoss Order
  /// level restriction volume.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_LEVEL_RESTRICTION_VOLUME_EXCEEDED,

  /// <summary>
  /// An attempt was made to create a Guaranteed Stop Loss Order, however
  /// doing so would exceed the Account’s configured guaranteed StopLoss Order
  /// level restriction price range.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_LEVEL_RESTRICTION_PRICE_RANGE_EXCEEDED,

  /// <summary>
  /// The Guaranteed Stop Loss Order request contains both the price and
  /// distance fields.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_PRICE_AND_DISTANCE_BOTH_SPECIFIED,

  /// <summary>
  /// The Guaranteed Stop Loss Order request contains neither the price nor
  /// distance fields.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_PRICE_AND_DISTANCE_BOTH_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss Order would cause the associated Trade to be in
  /// violation of the FIFO violation safeguard constraints
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_WOULD_VIOLATE_FIFO_VIOLATION_SAFEGUARD,

  /// <summary>
  /// The Guaranteed Stop Loss Order would be in violation of the risk
  /// management Order mutual exclusivity configuration specifying that only
  /// one risk management order can be attached to a Trade.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_MUTUALLY_EXCLUSIVE_VIOLATION,

  /// <summary>
  /// The Guaranteed Stop Loss Order would be in violation of the risk
  /// management Order mutual exclusivity configuration specifying that if a
  /// GSLO is already attached to a Trade, no other risk management Order can
  /// be attached to the same Trade.
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_GSLO_EXCLUDES_OTHERS_VIOLATION,

  /// <summary>
  /// An attempt to create a pending Order was made with no Guaranteed Stop
  /// Loss Order on fill specified and the Account’s configuration requires
  /// that every Trade have an associated Guaranteed Stop Loss Order.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_REQUIRED_FOR_PENDING_ORDER,

  /// <summary>
  /// An attempt to create a pending Order was made with a Guaranteed Stop
  /// Loss Order on fill that was explicitly configured to be guaranteed,
  /// however the Account’s configuration does not allow guaranteed Stop Loss
  /// Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_NOT_ALLOWED,

  /// <summary>
  /// An attempt to create a pending Order was made with a Guaranteed Stop
  /// Loss Order on fill that was explicitly configured to be not guaranteed,
  /// however the Account’s configuration requires Guaranteed Stop Loss
  /// Orders.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_REQUIRED,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specified does not provide a price
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies an invalid price
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies a price with more precision
  /// than is allowed by the Order’s instrument
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_PRECISION_EXCEEDED,

  /// <summary>
  /// An attempt to create a pending Order was made with the distance between
  /// the Guaranteed Stop Loss Order on fill’s price and the pending Order’s
  /// price is less than the Account’s configured minimum guaranteed stop loss
  /// distance.
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
  /// The Guaranteed Stop Loss on fill distance is invalid
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_DISTANCE_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill price distance exceeds the maximum
  /// allowed amount.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// The Guaranteed Stop Loss on fill distance contains more precision than
  /// is allowed by the instrument
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_DISTANCE_PRECISION_EXCEEDED,

  /// <summary>
  /// The Guaranteed Stop Loss on fill contains both the price and distance
  /// fields.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_AND_DISTANCE_BOTH_SPECIFIED,

  /// <summary>
  /// The Guaranteed Stop Loss on fill contains neither the price nor distance
  /// fields.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_PRICE_AND_DISTANCE_BOTH_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specified does not provide a
  /// TimeInForce
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TIME_IN_FORCE_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies an invalid TimeInForce
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies a GTD TimeInForce but does
  /// not provide a GTD timestamp
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies a GTD timestamp that is in
  /// the past.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// The Guaranteed Stop Loss on fill client Order ID specified is invalid
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill client Order tag specified is invalid
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_CLIENT_ORDER_TAG_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill client Order comment specified is
  /// invalid.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_CLIENT_ORDER_COMMENT_INVALID,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specified does not provide a
  /// TriggerCondition.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TRIGGER_CONDITION_MISSING,

  /// <summary>
  /// The Guaranteed Stop Loss on fill specifies an invalid TriggerCondition.
  /// </summary>
  GUARANTEED_STOP_LOSS_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// A Trailing Stop Loss Order for the specified Trade already exists
  /// </summary>
  TRAILING_STOP_LOSS_ORDER_ALREADY_EXISTS,

  /// <summary>
  /// The Trailing Stop Loss Order would cause the associated Trade to be in
  /// violation of the FIFO violation safeguard constraints
  /// </summary>
  TRAILING_STOP_LOSS_ORDER_WOULD_VIOLATE_FIFO_VIOLATION_SAFEGUARD,

  /// <summary>
  /// The Trailing Stop Loss Order would be in violation of the risk
  /// management Order mutual exclusivity configuration specifying that only
  /// one risk management order can be attached to a Trade.
  /// </summary>
  TRAILING_STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_MUTUALLY_EXCLUSIVE_VIOLATION,

  /// <summary>
  /// The Trailing Stop Loss Order would be in violation of the risk
  /// management Order mutual exclusivity configuration specifying that if a
  /// GSLO is already attached to a Trade, no other risk management Order can
  /// be attached to the same Trade.
  /// </summary>
  TRAILING_STOP_LOSS_ORDER_RMO_MUTUAL_EXCLUSIVITY_GSLO_EXCLUDES_OTHERS_VIOLATION,

  /// <summary>
  /// The Trailing Stop Loss on fill specified does not provide a distance
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_PRICE_DISTANCE_MISSING,

  /// <summary>
  /// The Trailing Stop Loss on fill distance is invalid
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_PRICE_DISTANCE_INVALID,

  /// <summary>
  /// The Trailing Stop Loss on fill distance contains more precision than is
  /// allowed by the instrument
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_PRICE_DISTANCE_PRECISION_EXCEEDED,

  /// <summary>
  /// The Trailing Stop Loss on fill price distance exceeds the maximum
  /// allowed amount
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_PRICE_DISTANCE_MAXIMUM_EXCEEDED,

  /// <summary>
  /// The Trailing Stop Loss on fill price distance does not meet the minimum
  /// allowed amount
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_PRICE_DISTANCE_MINIMUM_NOT_MET,

  /// <summary>
  /// The Trailing Stop Loss on fill specified does not provide a TimeInForce
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_TIME_IN_FORCE_MISSING,

  /// <summary>
  /// The Trailing Stop Loss on fill specifies an invalid TimeInForce
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_TIME_IN_FORCE_INVALID,

  /// <summary>
  /// The Trailing Stop Loss on fill TimeInForce is specified as GTD but no
  /// GTD timestamp is provided
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_MISSING,

  /// <summary>
  /// The Trailing Stop Loss on fill GTD timestamp is in the past
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_GTD_TIMESTAMP_IN_PAST,

  /// <summary>
  /// The Trailing Stop Loss on fill client Order ID specified is invalid
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_CLIENT_ORDER_ID_INVALID,

  /// <summary>
  /// The Trailing Stop Loss on fill client Order tag specified is invalid
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_CLIENT_ORDER_TAG_INVALID,

  /// <summary>
  /// The Trailing Stop Loss on fill client Order comment specified is invalid
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_CLIENT_ORDER_COMMENT_INVALID,

  /// <summary>
  /// A client attempted to create either a Trailing Stop Loss order or an
  /// order with a Trailing Stop Loss On Fill specified, which may not yet be
  /// supported.
  /// </summary>
  TRAILING_STOP_LOSS_ORDERS_NOT_SUPPORTED,

  /// <summary>
  /// The Trailing Stop Loss on fill specified does not provide a
  /// TriggerCondition
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_TRIGGER_CONDITION_MISSING,

  /// <summary>
  /// The Tailing Stop Loss on fill specifies an invalid TriggerCondition
  /// </summary>
  TRAILING_STOP_LOSS_ON_FILL_TRIGGER_CONDITION_INVALID,

  /// <summary>
  /// The request to close a Trade does not specify a full or partial close
  /// </summary>
  CLOSE_TRADE_TYPE_MISSING,

  /// <summary>
  /// The request to close a Trade partially did not specify the number of
  /// units to close
  /// </summary>
  CLOSE_TRADE_PARTIAL_UNITS_MISSING,

  /// <summary>
  /// The request to partially close a Trade specifies a number of units that
  /// exceeds the current size of the given Trade
  /// </summary>
  CLOSE_TRADE_UNITS_EXCEED_TRADE_SIZE,

  /// <summary>
  /// The Position requested to be closed out does not exist
  /// </summary>
  CLOSEOUT_POSITION_DOESNT_EXIST,

  /// <summary>
  /// The request to closeout a Position was specified incompletely
  /// </summary>
  CLOSEOUT_POSITION_INCOMPLETE_SPECIFICATION,

  /// <summary>
  /// A partial Position closeout request specifies a number of units that
  /// exceeds the current Position
  /// </summary>
  CLOSEOUT_POSITION_UNITS_EXCEED_POSITION_SIZE,

  /// <summary>
  /// The request to closeout a Position could not be fully satisfied
  /// </summary>
  CLOSEOUT_POSITION_REJECT,

  /// <summary>
  /// The request to partially closeout a Position did not specify the number
  /// of units to close.
  /// </summary>
  CLOSEOUT_POSITION_PARTIAL_UNITS_MISSING,

  /// <summary>
  /// The markup group ID provided is invalid
  /// </summary>
  MARKUP_GROUP_ID_INVALID,

  /// <summary>
  /// The PositionAggregationMode provided is not supported/valid.
  /// </summary>
  POSITION_AGGREGATION_MODE_INVALID,

  /// <summary>
  /// No configuration parameters provided
  /// </summary>
  ADMIN_CONFIGURE_DATA_MISSING,

  /// <summary>
  /// The margin rate provided is invalid
  /// </summary>
  MARGIN_RATE_INVALID,

  /// <summary>
  /// The margin rate provided would cause an immediate margin closeout
  /// </summary>
  MARGIN_RATE_WOULD_TRIGGER_CLOSEOUT,

  /// <summary>
  /// The account alias string provided is invalid
  /// </summary>
  ALIAS_INVALID,

  /// <summary>
  /// No configuration parameters provided
  /// </summary>
  CLIENT_CONFIGURE_DATA_MISSING,

  /// <summary>
  /// The margin rate provided would cause the Account to enter a margin call
  /// state.
  /// </summary>
  MARGIN_RATE_WOULD_TRIGGER_MARGIN_CALL,

  /// <summary>
  /// Funding is not possible because the requested transfer amount is invalid
  /// </summary>
  AMOUNT_INVALID,

  /// <summary>
  /// The Account does not have sufficient balance to complete the funding
  /// request
  /// </summary>
  INSUFFICIENT_FUNDS,

  /// <summary>
  /// Funding amount has not been specified
  /// </summary>
  AMOUNT_MISSING,

  /// <summary>
  /// Funding reason has not been specified
  /// </summary>
  FUNDING_REASON_MISSING,

  /// <summary>
  /// The list of Order Identifiers provided for a One Cancels All Order
  /// contains an Order Identifier that refers to a Stop Loss Order. OCA
  /// groups cannot contain Stop Loss Orders.
  /// </summary>
  OCA_ORDER_IDS_STOP_LOSS_NOT_ALLOWED,

  /// <summary>
  /// Neither Order nor Trade on Fill client extensions were provided for
  /// modification
  /// </summary>
  CLIENT_EXTENSIONS_DATA_MISSING,

  /// <summary>
  /// The Order to be replaced has a different type than the replacing Order.
  /// </summary>
  REPLACING_ORDER_INVALID,

  /// <summary>
  /// The replacing Order refers to a different Trade than the Order that is
  /// being replaced.
  /// </summary>
  REPLACING_TRADE_ID_INVALID,

  /// <summary>
  /// Canceling the order would cause an immediate margin closeout.
  /// </summary>
  ORDER_CANCEL_WOULD_TRIGGER_CLOSEOUT,
}
