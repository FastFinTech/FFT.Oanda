// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Contains the attributes of a user.
  /// </summary>
  public sealed class UserAttributes
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UserAttributes"/> class.
    /// </summary>
    [JsonConstructor]
    public UserAttributes(
      int userID,
      string username,
      string title,
      string name,
      string email,
      string divisionAbbreviation,
      string languageAbbreviation,
      string homeCurrency)
    {
      UserID = userID;
      Username = username;
      Title = title;
      Name = name;
      Email = email;
      DivisionAbbreviation = divisionAbbreviation;
      LanguageAbbreviation = languageAbbreviation;
      HomeCurrency = homeCurrency;
    }

    /// <summary>
    /// The user’s OANDA-assigned user ID.
    /// </summary>
    public int UserID { get; }

    /// <summary>
    /// The user-provided username.
    /// </summary>
    public string Username { get; }

    /// <summary>
    /// The user’s title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// The user’s name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The user’s email address.
    /// </summary>
    public string Email { get; }

    /// <summary>
    /// The OANDA division the user belongs to.
    /// </summary>
    public string DivisionAbbreviation { get; }

    /// <summary>
    /// The user’s preferred language.
    /// </summary>
    public string LanguageAbbreviation { get; }

    /// <summary>
    /// The home currency of the Account.
    /// </summary>
    public string HomeCurrency { get; }
  }
}
