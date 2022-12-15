// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// Contains the attributes of a user.
/// </summary>
public sealed record UserAttributes
{
  /// <summary>
  /// The user’s OANDA-assigned user ID.
  /// </summary>
  public int UserID { get; init; }

  /// <summary>
  /// The user-provided username.
  /// </summary>
  public string Username { get; init; }

  /// <summary>
  /// The user’s title.
  /// </summary>
  public string Title { get; init; }

  /// <summary>
  /// The user’s name.
  /// </summary>
  public string Name { get; init; }

  /// <summary>
  /// The user’s email address.
  /// </summary>
  public string Email { get; init; }

  /// <summary>
  /// The OANDA division the user belongs to.
  /// </summary>
  public string DivisionAbbreviation { get; init; }

  /// <summary>
  /// The user’s preferred language.
  /// </summary>
  public string LanguageAbbreviation { get; init; }

  /// <summary>
  /// The home currency of the Account.
  /// </summary>
  public string HomeCurrency { get; init; }
}
