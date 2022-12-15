// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;
using FFT.Oanda.JsonConverters;

/// <summary>
/// A TransactionHeartbeat object is injected into the Transaction stream to
/// ensure that the HTTP connection remains active.
/// </summary>
public sealed record TransactionHeartbeat
{
  /// <summary>
  /// Always equals "HEARTBEAT".
  /// </summary>
  public string Type { get; init; }

  /// <summary>
  /// The ID of the most recent Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }

  /// <summary>
  /// The date/time when the TransactionHeartbeat was created.
  /// </summary>
  public DateTime Time { get; init; }
}
