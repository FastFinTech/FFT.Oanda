// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.CreateOrder(string, OrderRequest)"/> method and contains information about an order request
  /// that has been accepted.
  /// </summary>
  public sealed class CreateOrderResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateOrderResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public CreateOrderResponse(
      Transaction orderCreateTransaction,
      OrderFillTransaction? orderFillTransaction,
      OrderCancelTransaction? orderCancelTransaction,
      Transaction? orderReissueTransaction,
      Transaction? orderReissueRejectTransaction,
      ImmutableList<string> relatedTransactionIDs,
      string lastTransactionID)
    {
      OrderCreateTransaction = orderCreateTransaction;
      OrderFillTransaction = orderFillTransaction;
      OrderCancelTransaction = orderCancelTransaction;
      OrderReissueTransaction = orderReissueTransaction;
      OrderReissueRejectTransaction = orderReissueRejectTransaction;
      RelatedTransactionIDs = relatedTransactionIDs;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The Transaction that created the Order specified by the request.
    /// </summary>
    public Transaction OrderCreateTransaction { get; }

    /// <summary>
    /// The Transaction that filled the newly created Order. Only provided when
    /// the Order was immediately filled.
    ///
    public OrderFillTransaction? OrderFillTransaction { get; }

    /// <summary>
    /// The Transaction that cancelled the newly created Order. Only provided
    /// when the Order was immediately cancelled.
    /// </summary>
    public OrderCancelTransaction? OrderCancelTransaction { get; }

    ///<summary>
    /// The Transaction that reissues the Order. Only provided when the Order is
    /// configured to be reissued for its remaining units after a partial fill
    /// and the reissue was successful.
    /// </summary>
    public Transaction? OrderReissueTransaction { get; }

    /// <summary>
    /// The Transaction that rejects the reissue of the Order. Only provided
    /// when the Order is configured to be reissued for its remaining units
    /// after a partial fill and the reissue was rejected.
    /// </summary>
    public Transaction? OrderReissueRejectTransaction { get; }

    ///<summary>
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
