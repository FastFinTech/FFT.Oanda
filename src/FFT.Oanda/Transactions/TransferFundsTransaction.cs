// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// A TransferFundsTransaction represents the transfer of funds in/out of an
/// Account.
/// </summary>
public sealed class TransferFundsTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="TransferFundsTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public TransferFundsTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    decimal amount,
    FundingReason fundingReason,
    string? comment,
    decimal accountBalance)
      : base(
        id,
        time,
        userID,
        accountID,
        batchID,
        requestID,
        type)
  {
    Amount = amount;
    FundingReason = fundingReason;
    Comment = comment;
    AccountBalance = accountBalance;
  }

  /// <summary>
  /// The amount to deposit/withdraw from the Account in the Account’s home
  /// currency. A positive value indicates a deposit, a negative value
  /// indicates a withdrawal. Expressed in the account's home currency.
  /// </summary>
  public decimal Amount { get; }

  /// <summary>
  /// The reason that an Account is being funded.
  /// </summary>
  public FundingReason FundingReason { get; }

  /// <summary>
  /// An optional comment that may be attached to a fund transfer for audit
  /// purposes.
  /// </summary>
  public string? Comment { get; }

  /// <summary>
  /// The Account’s balance after funds are transferred. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal AccountBalance { get; }
}
