// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A ClientConfigureTransaction represents the configuration of an Account by
  /// a client.
  /// </summary>
  public sealed class ClientConfigureTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="ClientConfigureTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public ClientConfigureTransaction(
      int id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string? alias,
      decimal marginRate)
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
    }

    /// <summary>
    /// The client-provided alias for the Account.
    /// </summary>
    public string? Alias { get; }

    /// <summary>
    /// The margin rate override for the Account.
    /// </summary>
    public decimal MarginRate { get; }
  }
}
