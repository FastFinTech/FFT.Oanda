// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Orders;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.SetTradeOrders(string, string,
/// TakeProfitDetails, StopLossDetails, TrailingStopLossDetails,
/// GuaranteedStopLossDetails, CancellationToken)"/> method.
/// </summary>
public sealed record SetTradeOrdersResponse
{
  /// <summary>
  /// The Transaction created that cancels the Trade’s existing Take Profit
  /// Order.
  /// </summary>
  public OrderCancelTransaction? TakeProfitOrderCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that creates a new Take Profit Order for the
  /// Trade.
  /// </summary>
  public TakeProfitOrderTransaction? TakeProfitOrderTransaction { get; }

  /// <summary>
  /// The Transaction created that immediately fills the Trade’s new Take
  /// Profit Order. Only provided if the new Take Profit Order was immediately
  /// filled.
  /// </summary>
  public OrderFillTransaction? TakeProfitOrderFillTransaction { get; }

  /// <summary>
  /// The Transaction created that immediately cancels the Trade’s new Take
  /// Profit Order. Only provided if the new Take Profit Order was immediately
  /// cancelled.
  /// </summary>
  public OrderCancelTransaction? TakeProfitOrderCreatedCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that cancels the Trade’s existing Stop Loss
  /// Order.
  /// </summary>
  public OrderCancelTransaction? StopLossOrderCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that creates a new Stop Loss Order for the Trade.
  /// </summary>
  public StopLossOrderTransaction? StopLossOrderTransaction { get; }

  /// <summary>
  /// The Transaction created that immediately fills the Trade’s new Stop
  /// Order. Only provided if the new Stop Loss Order was immediately filled.
  /// </summary>
  public OrderFillTransaction? StopLossOrderFillTransaction { get; }

  /// <summary>
  /// The Transaction created that immediately cancels the Trade’s new Stop
  /// Loss Order. Only provided if the new Stop Loss Order was immediately
  /// cancelled.
  /// </summary>
  public OrderCancelTransaction? StopLossOrderCreatedCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that cancels the Trade’s existing Trailing Stop
  /// Loss Order.
  /// </summary>
  public OrderCancelTransaction? TrailingStopLossOrderCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that creates a new Trailing Stop Loss Order for
  /// the Trade.
  /// </summary>
  public TrailingStopLossOrderTransaction? TrailingStopLossOrderTransaction { get; }

  /// <summary>
  /// The Transaction created that cancels the Trade’s existing Guaranteed Stop
  /// Loss Order.
  /// </summary>
  public OrderCancelTransaction? GuaranteedStopLossOrderCancelTransaction { get; }

  /// <summary>
  /// The Transaction created that creates a new Guaranteed Stop Loss Order for
  /// the Trade.
  /// </summary>
  public GuaranteedStopLossOrderTransaction? GuaranteedStopLossOrderTransaction { get; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<int> RelatedTransactionIDs { get; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }
}
