// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A OrderClientExtensionsModifyRejectTransaction represents the rejection of
  /// the modification of an Order’s Client Extensions.
  /// </summary>
  public sealed class OrderClientExtensionsModifyRejectTransaction : OrderClientExtensionsModifyTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderClientExtensionsModifyRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public OrderClientExtensionsModifyRejectTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string orderID,
      string? clientOrderID,
      ClientExtensions? clientExtensionsModify,
      ClientExtensions? tradeClientExtensionsModify,
      TransactionRejectReason rejectReason)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type,
          orderID,
          clientOrderID,
          clientExtensionsModify,
          tradeClientExtensionsModify)
    {
      RejectReason = rejectReason;
    }

    /// <summary>
    /// The reason that the Reject Transaction was created.
    /// </summary>
    public TransactionRejectReason RejectReason { get; }
  }
}
