// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders.OrderRequests;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.ReplaceOrder(string, string, OrderRequest, string)"/> method when the order replacement request is
  /// successful.
  /// </summary>
  public sealed class ReplaceOrderResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ReplaceOrderResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public ReplaceOrderResponse(
      OrderCancelTransaction orderCancelTransaction,
      Transaction orderCreateTransaction,
      OrderFillTransaction? orderFillTransaction,
      Transaction? orderReissueTransaction,
      Transaction? orderReissueRejectTransaction,
      OrderCancelTransaction? replacingOrderCancelTransaction,
      ImmutableList<string> relatedTransactionIDs,
      string lastTransactionID)
    {
      OrderCancelTransaction = orderCancelTransaction;
      OrderCreateTransaction = orderCreateTransaction;
      OrderFillTransaction = orderFillTransaction;
      OrderReissueTransaction = orderReissueTransaction;
      OrderReissueRejectTransaction = orderReissueRejectTransaction;
      ReplacingOrderCancelTransaction = replacingOrderCancelTransaction;
      RelatedTransactionIDs = relatedTransactionIDs;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The Transaction that cancelled the Order to be replaced.
    /// </summary>
    public OrderCancelTransaction OrderCancelTransaction { get; }

    /// <summary>
    /// The Transaction that created the replacing Order as requested. The
    /// actual instance type will vary depending on the type of the replacement
    /// order.
    /// </summary>
    public Transaction OrderCreateTransaction { get; }

    /// <summary>
    /// The Transaction that filled the replacing Order. This is only provided
    /// when the replacing Order was immediately filled.
    /// </summary>
    public OrderFillTransaction? OrderFillTransaction { get; }

    /// <summary>
    /// The Transaction that reissues the replacing Order. Only provided when
    /// the replacing Order was partially filled immediately and is configured
    /// to be reissued for its remaining units. Actual instance type varies
    /// depending on the type of the replacement order.
    /// </summary>
    public Transaction? OrderReissueTransaction { get; }

    /// <summary>
    /// The Transaction that rejects the reissue of the Order. Only provided
    /// when the replacing Order was partially filled immediately and was
    /// configured to be reissued, however the reissue was rejected. Actual
    /// instance type varies depending on the type of the replacement order.
    /// </summary>
    public Transaction? OrderReissueRejectTransaction { get; }

    /// <summary>
    /// The Transaction that cancelled the replacing Order. Only provided when
    /// the replacing Order was immediately cancelled.
    /// </summary>
    public OrderCancelTransaction? ReplacingOrderCancelTransaction { get; }

    /// <summary>
    /// The IDs of all Transactions that were created while satisfying the
    /// request.
    /// </summary>
    public ImmutableList<string> RelatedTransactionIDs { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionID { get; }
  }
}
