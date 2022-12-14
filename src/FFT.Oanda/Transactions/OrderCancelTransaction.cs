// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// An OrderCancelTransaction represents the cancellation of an Order in the
/// client’s Account.
/// </summary>
public sealed class OrderCancelTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="OrderCancelTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public OrderCancelTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    string orderID,
    string? clientOrderID,
    OrderCancelReason reason,
    string? replacedByOrderID)
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
    Reason = reason;
    ReplacedByOrderID = replacedByOrderID;
  }

  /// <summary>
  /// The ID of the Order cancelled.
  /// </summary>
  public string OrderID { get; }

  /// <summary>
  /// The client ID of the Order cancelled (only provided if the Order has a
  /// client Order ID).
  /// </summary>
  public string? ClientOrderID { get; }

  /// <summary>
  /// The reason that the Order was cancelled.
  /// </summary>
  public OrderCancelReason Reason { get; }

  /// <summary>
  /// The ID of the Order that replaced this Order (only provided if this
  /// Order was cancelled for replacement).
  /// </summary>
  public string? ReplacedByOrderID { get; }
}
