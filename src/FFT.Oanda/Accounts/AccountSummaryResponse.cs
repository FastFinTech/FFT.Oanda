// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;

  /// <summary>
  /// The summary of a single account. Does not provide full specification of
  /// pending Orders, open Trades and Positions.
  /// </summary>
  public sealed class AccountSummaryResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountSummaryResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountSummaryResponse(AccountSummary account, int lastTransactionId)
    {
      Account = account;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The summary of the requested account.
    /// </summary>
    public AccountSummary Account { get; }

    /// <summary>
    /// The ID of the most recent transaction created for the account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionId { get; }
  }
}
