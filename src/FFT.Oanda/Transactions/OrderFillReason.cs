// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The reason that an order was filled.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum OrderFillReason
  {
    /// <summary>
    /// The Order filled was a Limit Order.
    /// </summary>
    LIMIT_ORDER,

    /// <summary>
    /// The Order filled was a Stop Order.
    /// </summary>
    STOP_ORDER,

    /// <summary>
    /// The Order filled was a Market-if-touched Order.
    /// </summary>
    MARKET_IF_TOUCHED_ORDER,

    /// <summary>
    /// The Order filled was a Take Profit Order.
    /// </summary>
    TAKE_PROFIT_ORDER,

    /// <summary>
    /// The Order filled was a Stop Loss Order.
    /// </summary>
    STOP_LOSS_ORDER,

    /// <summary>
    /// The Order filled was a Guaranteed Stop Loss Order.
    /// </summary>
    GUARANTEED_STOP_LOSS_ORDER,

    /// <summary>
    /// The Order filled was a Trailing Stop Loss Order.
    /// </summary>
    TRAILING_STOP_LOSS_ORDER,

    /// <summary>
    /// The Order filled was a Market Order.
    /// </summary>
    MARKET_ORDER,

    /// <summary>
    /// The Order filled was a Market Order used to explicitly close a Trade.
    /// </summary>
    MARKET_ORDER_TRADE_CLOSE,

    /// <summary>
    /// The Order filled was a Market Order used to explicitly close a Position.
    /// </summary>
    MARKET_ORDER_POSITION_CLOSEOUT,

    /// <summary>
    /// The Order filled was a Market Order used for a Margin Closeout.
    /// </summary>
    MARKET_ORDER_MARGIN_CLOSEOUT,

    /// <summary>
    /// The Order filled was a Market Order used for a delayed Trade close.
    /// </summary>
    MARKET_ORDER_DELAYED_TRADE_CLOSE,

    /// <summary>
    /// The Order filled was a Fixed Price Order.
    /// </summary>
    FIXED_PRICE_ORDER,

    /// <summary>
    /// The Order filled was a Fixed Price Order created as part of a platform
    /// account migration.
    /// </summary>
    FIXED_PRICE_ORDER_PLATFORM_ACCOUNT_MIGRATION,

    /// <summary>
    /// The Order filled was a Fixed Price Order created to close a Trade as
    /// part of division account migration.
    /// </summary>
    FIXED_PRICE_ORDER_DIVISION_ACCOUNT_MIGRATION,

    /// <summary>
    /// The Order filled was a Fixed Price Order created to close a Trade
    /// administratively.
    /// </summary>
    FIXED_PRICE_ORDER_ADMINISTRATIVE_ACTION,
  }
}
