// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System.Collections.Immutable;
using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.CancelOrder(string, string, string, CancellationToken)"/>
/// method when the order is successfully canceled.
/// </summary>
public sealed class CancelOrderResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CancelOrderResponse"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public CancelOrderResponse(
    OrderCancelTransaction orderCancelTransaction,
    ImmutableList<string> relatedTransactionIDs,
    int lastTransactionID)
  {
    OrderCancelTransaction = orderCancelTransaction;
    RelatedTransactionIDs = relatedTransactionIDs;
    LastTransactionID = lastTransactionID;
  }

  /// <summary>
  /// The Transaction that cancelled the Order.
  /// </summary>
  public OrderCancelTransaction OrderCancelTransaction { get; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<string> RelatedTransactionIDs { get; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }
}
