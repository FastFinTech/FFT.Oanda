// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// An OrderCancelRejectTransaction represents the rejection of the
/// cancellation of an Order in the client’s Account.
/// </summary>
public sealed class OrderCancelRejectTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="OrderCancelRejectTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public OrderCancelRejectTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    string orderID,
    string? clientOrderID,
    TransactionRejectReason rejectReason)
      : base(
        id,
        time,
        userID,
        accountID,
        batchID,
        requestID,
        type)
  {
    OrderID = orderID;
    ClientOrderID = clientOrderID;
    RejectReason = rejectReason;
  }

  /// <summary>
  /// The ID of the Order intended to be cancelled.
  /// </summary>
  public string OrderID { get; }

  /// <summary>
  /// The client ID of the Order intended to be cancelled (only provided if
  /// the Order has a client Order ID).
  /// </summary>
  public string? ClientOrderID { get; }

  /// <summary>
  /// The reason that the Reject Transaction was created.
  /// </summary>
  public TransactionRejectReason RejectReason { get; }
}
