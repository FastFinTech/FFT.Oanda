// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// The string representation of an Account Identifier.
/// </summary>
public sealed record AccountId
{
  /// <summary>
  /// The SiteId component of the account id.
  /// </summary>
  public required string SiteId { get; init; }

  /// <summary>
  /// The DivisionId component of the account id.
  /// </summary>
  public required string DivisionId { get; init; }

  /// <summary>
  /// The UserId component of the account id.
  /// </summary>
  public required string UserId { get; init; }

  /// <summary>
  /// The AccountNumber component of the account id.
  /// </summary>
  public required string AccountNumber { get; init; }

  /// <summary>
  /// Parses an account id of the form
  /// “{siteID}-{divisionID}-{userID}-{accountNumber}”.
  /// </summary>
  public static AccountId Parse(string accountId)
  {
    var parts = accountId.Split('-');
    return new AccountId
    {
      SiteId = parts[0],
      DivisionId = parts[1],
      UserId = parts[2],
      AccountNumber = parts[3],
    };
  }

  /// <inheritdoc/>
  public override string ToString()
    => $"{SiteId}-{DivisionId}-{UserId}-{AccountNumber}";
}
