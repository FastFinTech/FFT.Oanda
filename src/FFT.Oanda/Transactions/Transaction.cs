// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The base Transaction specification. Specifies properties that are common
/// between all Transactions.
/// </summary>
[JsonConverter(typeof(TransactionConverter))]
public abstract class Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Transaction"/> class.
  /// </summary>
  [JsonConstructor]
  protected Transaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type)
  {
    Id = id;
    Time = time;
    UserID = userID;
    AccountID = accountID;
    BatchID = batchID;
    RequestID = requestID;
    Type = type;
  }

  /// <summary>
  /// The Transaction’s Identifier.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int Id { get; }

  /// <summary>
  /// The date/time when the Transaction was created.
  /// </summary>
  public DateTime Time { get; }

  /// <summary>
  /// The ID of the user that initiated the creation of the Transaction.
  /// </summary>
  public int? UserID { get; }

  // TODO: Api spec says this is not required (nullable) -- check if there is
  // any transaction type that does not require this field and make it
  // nullable, or just keep it non-nullable.

  /// <summary>
  /// The ID of the Account the Transaction was created for.
  /// </summary>
  public string AccountID { get; }

  /// <summary>
  /// The ID of the “batch” that the Transaction belongs to. Transactions in
  /// the same batch are applied to the Account simultaneously.
  /// </summary>
  public string? BatchID { get; }

  /// <summary>
  /// The Request ID of the request which generated the transaction.
  /// </summary>
  public string? RequestID { get; }

  /// <summary>
  /// The type of the transaction.
  /// </summary>
  public TransactionType Type { get; }
}
