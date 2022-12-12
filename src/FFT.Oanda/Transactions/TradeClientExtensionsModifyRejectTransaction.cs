// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TradeClientExtensionsModifyRejectTransaction represents the rejection of
  /// the modification of a Trade’s Client Extensions.
  /// </summary>
  public sealed class TradeClientExtensionsModifyRejectTransaction : TradeClientExtensionsModifyTransaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TradeClientExtensionsModifyRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public TradeClientExtensionsModifyRejectTransaction(
      int id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string tradeID,
      string? clientTradeID,
      ClientExtensions tradeClientExtensionsModify,
      TransactionRejectReason rejectReason)
        : base(
            id,
            time,
            userID,
            accountID,
            batchID,
            requestID,
            type,
            tradeID,
            clientTradeID,
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
