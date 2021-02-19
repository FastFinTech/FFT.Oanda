// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The reason that an Account is being funded.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum FundingReason
  {
    /// <summary>
    /// The client has initiated a funds transfer
    /// </summary>
    CLIENT_FUNDING,

    /// <summary>
    /// Funds are being transferred between two Accounts.
    /// </summary>
    ACCOUNT_TRANSFER,

    /// <summary>
    /// Funds are being transferred as part of a Division migration
    /// </summary>
    DIVISION_MIGRATION,

    /// <summary>
    /// Funds are being transferred as part of a Site migration
    /// </summary>
    SITE_MIGRATION,

    /// <summary>
    /// Funds are being transferred as part of an Account adjustment
    /// </summary>
    ADJUSTMENT,
  }
}
