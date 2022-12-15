// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

/// <summary>
/// A filter that can be used when fetching Transactions.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransactionFilter
{
  /// <summary>
  /// Order-related Transactions. These are the Transactions that create,
  /// cancel, fill or trigger Orders
  /// </summary>
  ORDER,

  /// <summary>
  /// Funding-related Transactions
  /// </summary>
  FUNDING,

  /// <summary>
  /// Administrative Transactions
  /// </summary>
  ADMIN,

  /// <summary>
  /// Account Create Transaction
  /// </summary>
  CREATE,

  /// <summary>
  /// Account Close Transaction
  /// </summary>
  CLOSE,

  /// <summary>
  /// Account Reopen Transaction
  /// </summary>
  REOPEN,

  /// <summary>
  /// Client Configuration Transaction
  /// </summary>
  CLIENT_CONFIGURE,

  /// <summary>
  /// Client Configuration Reject Transaction
  /// </summary>
  CLIENT_CONFIGURE_REJECT,

  /// <summary>
  /// Transfer Funds Transaction
  /// </summary>
  TRANSFER_FUNDS,

  /// <summary>
  /// Transfer Funds Reject Transaction
  /// </summary>
  TRANSFER_FUNDS_REJECT,

  /// <summary>
  /// Market Order Transaction
  /// </summary>
  MARKET_ORDER,

  /// <summary>
  /// Market Order Reject Transaction
  /// </summary>
  MARKET_ORDER_REJECT,

  /// <summary>
  /// Limit Order Transaction
  /// </summary>
  LIMIT_ORDER,

  /// <summary>
  /// Limit Order Reject Transaction
  /// </summary>
  LIMIT_ORDER_REJECT,

  /// <summary>
  /// Stop Order Transaction
  /// </summary>
  STOP_ORDER,

  /// <summary>
  /// Stop Order Reject Transaction
  /// </summary>
  STOP_ORDER_REJECT,

  /// <summary>
  /// Market if Touched Order Transaction
  /// </summary>
  MARKET_IF_TOUCHED_ORDER,

  /// <summary>
  /// Market if Touched Order Reject Transaction
  /// </summary>
  MARKET_IF_TOUCHED_ORDER_REJECT,

  /// <summary>
  /// Take Profit Order Transaction
  /// </summary>
  TAKE_PROFIT_ORDER,

  /// <summary>
  /// Take Profit Order Reject Transaction
  /// </summary>
  TAKE_PROFIT_ORDER_REJECT,

  /// <summary>
  /// Stop Loss Order Transaction
  /// </summary>
  STOP_LOSS_ORDER,

  /// <summary>
  /// Stop Loss Order Reject Transaction
  /// </summary>
  STOP_LOSS_ORDER_REJECT,

  /// <summary>
  /// Guaranteed Stop Loss Order Transaction
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER,

  /// <summary>
  /// Guaranteed Stop Loss Order Reject Transaction
  /// </summary>
  GUARANTEED_STOP_LOSS_ORDER_REJECT,

  /// <summary>
  /// Trailing Stop Loss Order Transaction
  /// </summary>
  TRAILING_STOP_LOSS_ORDER,

  /// <summary>
  /// Trailing Stop Loss Order Reject Transaction
  /// </summary>
  TRAILING_STOP_LOSS_ORDER_REJECT,

  /// <summary>
  /// One Cancels All Order Transaction
  /// </summary>
  ONE_CANCELS_ALL_ORDER,

  /// <summary>
  /// One Cancels All Order Reject Transaction
  /// </summary>
  ONE_CANCELS_ALL_ORDER_REJECT,

  /// <summary>
  /// One Cancels All Order Trigger Transaction
  /// </summary>
  ONE_CANCELS_ALL_ORDER_TRIGGERED,

  /// <summary>
  /// Order Fill Transaction
  /// </summary>
  ORDER_FILL,

  /// <summary>
  /// Order Cancel Transaction
  /// </summary>
  ORDER_CANCEL,

  /// <summary>
  /// Order Cancel Reject Transaction
  /// </summary>
  ORDER_CANCEL_REJECT,

  /// <summary>
  /// Order Client Extensions Modify Transaction
  /// </summary>
  ORDER_CLIENT_EXTENSIONS_MODIFY,

  /// <summary>
  /// Order Client Extensions Modify Reject Transaction
  /// </summary>
  ORDER_CLIENT_EXTENSIONS_MODIFY_REJECT,

  /// <summary>
  /// Trade Client Extensions Modify Transaction
  /// </summary>
  TRADE_CLIENT_EXTENSIONS_MODIFY,

  /// <summary>
  /// Trade Client Extensions Modify Reject Transaction
  /// </summary>
  TRADE_CLIENT_EXTENSIONS_MODIFY_REJECT,

  /// <summary>
  /// Margin Call Enter Transaction
  /// </summary>
  MARGIN_CALL_ENTER,

  /// <summary>
  /// Margin Call Extend Transaction
  /// </summary>
  MARGIN_CALL_EXTEND,

  /// <summary>
  /// Margin Call Exit Transaction
  /// </summary>
  MARGIN_CALL_EXIT,

  /// <summary>
  /// Delayed Trade Closure Transaction
  /// </summary>
  DELAYED_TRADE_CLOSURE,

  /// <summary>
  /// Daily Financing Transaction
  /// </summary>
  DAILY_FINANCING,

  /// <summary>
  /// Reset Resettable PL Transaction
  /// </summary>
  RESET_RESETTABLE_PL,
}
