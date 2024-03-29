﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Returned by the <see cref="OandaApiClient.CreateOrder{TOrderRequest}(string, TOrderRequest, CancellationToken)"/>
/// method and contains information about the result of an order request.
/// </summary>
public sealed record CreateOrderResponse
{
  /// <summary>
  /// The Transaction that created the Order specified by the request.
  /// </summary>
  public Transaction OrderCreateTransaction { get; init; }

  /// <summary>
  /// The Transaction that filled the newly created Order. Only provided when
  /// the Order was immediately filled.
  /// </summary>
  public OrderFillTransaction? OrderFillTransaction { get; init; }

  /// <summary>
  /// The Transaction that cancelled the newly created Order. Only provided
  /// when the Order was immediately cancelled.
  /// </summary>
  public OrderCancelTransaction? OrderCancelTransaction { get; init; }

  /// <summary>
  /// The Transaction that reissues the Order. Only provided when the Order is
  /// configured to be reissued for its remaining units after a partial fill
  /// and the reissue was successful.
  /// </summary>
  public Transaction? OrderReissueTransaction { get; init; }

  /// <summary>
  /// The Transaction that rejects the reissue of the Order. Only provided
  /// when the Order is configured to be reissued for its remaining units
  /// after a partial fill and the reissue was rejected.
  /// </summary>
  public Transaction? OrderReissueRejectTransaction { get; init; }

  /// <summary>
  /// The IDs of all Transactions that were created while satisfying the
  /// request.
  /// </summary>
  public ImmutableList<int> RelatedTransactionIDs { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; init; }
}
