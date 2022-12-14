// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System;
using System.Text.Json.Serialization;

// non-order-related transactions

/// <summary>
/// A CreateTransaction represents the creation of an Account.
/// </summary>
public sealed class CreateTransaction : Transaction
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CreateTransaction"/> class.
  /// </summary>
  [JsonConstructor]
  public CreateTransaction(
    int id,
    DateTime time,
    int? userID,
    string accountID,
    string? batchID,
    string? requestID,
    TransactionType type,
    int divisionID,
    int siteID,
    int accountUserID,
    int accountNumber,
    string homeCurrency)
      : base(
        id,
        time,
        userID,
        accountID,
        batchID,
        requestID,
        type)
  {
    DivisionID = divisionID;
    SiteID = siteID;
    AccountUserID = accountUserID;
    AccountNumber = accountNumber;
    HomeCurrency = homeCurrency;
  }

  /// <summary>
  /// The ID of the Division that the Account is in.
  /// </summary>
  public int DivisionID { get; }

  /// <summary>
  /// The ID of the Site that the Account was created at.
  /// </summary>
  public int SiteID { get; }

  /// <summary>
  /// The ID of the user that the Account was created for.
  /// </summary>
  public int AccountUserID { get; }

  /// <summary>
  /// The number of the Account within the site/division/user.
  /// </summary>
  public int AccountNumber { get; }

  /// <summary>
  /// The home currency of the Account.
  /// </summary>
  public string HomeCurrency { get; }
}
