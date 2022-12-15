// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.CancelOrder(string, string, string, CancellationToken)"/>
/// method when the order is successfully canceled.
/// </summary>
public sealed record CancelOrderResponse
{
  /// <summary>
  /// The Transaction that cancelled the Order.
  /// </summary>
  public OrderCancelTransaction OrderCancelTransaction { get; init; }

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
