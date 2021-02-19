// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TransactionHeartbeat object is injected into the Transaction stream to
  /// ensure that the HTTP connection remains active.
  /// </summary>
  public sealed class TransactionHeartbeat
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TransactionHeartbeat"/> class.
    /// </summary>
    [JsonConstructor]
    public TransactionHeartbeat(string type, string lastTransactionId, DateTime time)
    {
      Type = type;
      LastTransactionId = lastTransactionId;
      Time = time;
    }

    /// <summary>
    /// Always equals "HEARTBEAT".
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionId { get; }

    /// <summary>
    /// The date/time when the TransactionHeartbeat was created.
    /// </summary>
    public DateTime Time { get; }
  }
}
