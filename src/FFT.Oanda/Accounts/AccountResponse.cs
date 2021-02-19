// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The full details of an account. This includes full open trade, open
  /// position and pending order representation.
  /// </summary>
  public sealed class AccountResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountResponse(Account account, string lastTransactionId)
    {
      Account = account;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The full details of the requested account.
    /// </summary>
    public Account Account { get; }

    /// <summary>
    /// The ID of the most recent transaction created for the account.
    /// </summary>
    public string LastTransactionId { get; }
  }
}
