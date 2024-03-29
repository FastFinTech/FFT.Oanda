﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// A CreateTransaction represents the creation of an Account.
/// </summary>
public sealed record CreateTransaction : Transaction
{
  /// <summary>
  /// The ID of the Division that the Account is in.
  /// </summary>
  public int DivisionID { get; init; }

  /// <summary>
  /// The ID of the Site that the Account was created at.
  /// </summary>
  public int SiteID { get; init; }

  /// <summary>
  /// The ID of the user that the Account was created for.
  /// </summary>
  public int AccountUserID { get; init; }

  /// <summary>
  /// The number of the Account within the site/division/user.
  /// </summary>
  public int AccountNumber { get; init; }

  /// <summary>
  /// The home currency of the Account.
  /// </summary>
  public string HomeCurrency { get; init; }
}
