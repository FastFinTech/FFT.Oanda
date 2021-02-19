// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A ClientConfigureRejectTransaction represents the reject of configuration
  /// of an Account by a client.
  /// </summary>
  public sealed class ClientConfigureRejectTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="ClientConfigureRejectTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public ClientConfigureRejectTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string? alias,
      decimal marginRate,
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
      Alias = alias;
      MarginRate = marginRate;
      RejectReason = rejectReason;
    }

    /// <summary>
    /// The client-provided alias for the Account.
    /// </summary>
    public string? Alias { get; }

    /// <summary>
    /// The margin rate override for the Account.
    /// </summary>
    public decimal MarginRate { get; }

    /// <summary>
    /// The reason that the Reject Transaction was created.
    /// </summary>
    public TransactionRejectReason RejectReason { get; }
  }
}
