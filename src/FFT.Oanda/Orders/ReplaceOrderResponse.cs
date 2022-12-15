// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.ReplaceOrder(string, string, OrderRequests.OrderRequest, string?, CancellationToken)"/>"/>
/// method.
/// </summary>
public sealed record ReplaceOrderResponse
{
  /// <summary>
  /// The Transaction that cancelled the Order to be replaced.
  /// </summary>
  public OrderCancelTransaction OrderCancelTransaction { get; init; }

  /// <summary>
  /// The Transaction that created the replacing Order as requested. The
  /// actual instance type will vary depending on the type of the replacement
  /// order.
  /// </summary>
  public Transaction OrderCreateTransaction { get; init; }

  /// <summary>
  /// The Transaction that filled the replacing Order. This is only provided
  /// when the replacing Order was immediately filled.
  /// </summary>
  public OrderFillTransaction? OrderFillTransaction { get; init; }

  /// <summary>
  /// The Transaction that reissues the replacing Order. Only provided when
  /// the replacing Order was partially filled immediately and is configured
  /// to be reissued for its remaining units. Actual instance type varies
  /// depending on the type of the replacement order.
  /// </summary>
  public Transaction? OrderReissueTransaction { get; init; }

  /// <summary>
  /// The Transaction that rejects the reissue of the Order. Only provided
  /// when the replacing Order was partially filled immediately and was
  /// configured to be reissued, however the reissue was rejected. Actual
  /// instance type varies depending on the type of the replacement order.
  /// </summary>
  public Transaction? OrderReissueRejectTransaction { get; init; }

  /// <summary>
  /// The Transaction that cancelled the replacing Order. Only provided when
  /// the replacing Order was immediately cancelled.
  /// </summary>
  public OrderCancelTransaction? ReplacingOrderCancelTransaction { get; init; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<string> RelatedTransactionIDs { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; init; }
}
