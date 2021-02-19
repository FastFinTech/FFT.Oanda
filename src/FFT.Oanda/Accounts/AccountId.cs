// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  /// <summary>
  /// The string representation of an Account Identifier.
  /// </summary>
  public sealed class AccountId
  {
    private AccountId(string siteId, string divisionId, string userId, string accountNumber)
    {
      SiteId = siteId;
      DivisionId = divisionId;
      UserId = userId;
      AccountNumber = accountNumber;
    }

    /// <summary>
    /// The SiteId component of the account id.
    /// </summary>
    public string SiteId { get; }

    /// <summary>
    /// The DivisionId component of the account id.
    /// </summary>
    public string DivisionId { get; }

    /// <summary>
    /// The UserId component of the account id.
    /// </summary>
    public string UserId { get; }

    /// <summary>
    /// The AccountNumber component of the account id.
    /// </summary>
    public string AccountNumber { get; }

    /// <summary>
    /// Parses an account id of the form
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”.
    /// </summary>
    public static AccountId Parse(string accountId)
    {
      var parts = accountId.Split('-');
      return new AccountId(parts[0], parts[1], parts[2], parts[3]);
    }

    /// <inheritdoc/>
    public override string ToString()
      => $"{SiteId}-{DivisionId}-{UserId}-{AccountNumber}";
  }
}
