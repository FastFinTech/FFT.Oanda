﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// A TransferFundsTransaction represents the transfer of funds in/out of an
/// Account.
/// </summary>
public sealed record TransferFundsTransaction : Transaction
{
  /// <summary>
  /// The amount to deposit/withdraw from the Account in the Account’s home
  /// currency. A positive value indicates a deposit, a negative value
  /// indicates a withdrawal. Expressed in the account's home currency.
  /// </summary>
  public decimal Amount { get; init; }

  /// <summary>
  /// The reason that an Account is being funded.
  /// </summary>
  public FundingReason FundingReason { get; init; }

  /// <summary>
  /// An optional comment that may be attached to a fund transfer for audit
  /// purposes.
  /// </summary>
  public string? Comment { get; init; }

  /// <summary>
  /// The Account’s balance after funds are transferred. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal AccountBalance { get; init; }
}
