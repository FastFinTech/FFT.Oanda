// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Contains a list of accounts that the current api key is authorized to
  /// access.
  /// </summary>
  public sealed class AccountListResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountListResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountListResponse(
      ImmutableList<AccountProperties> accounts)
    {
      Accounts = accounts;
    }

    /// <summary>
    /// The list of Accounts the client is authorized to access and their
    /// associated properties.
    /// </summary>
    public ImmutableList<AccountProperties> Accounts { get; }
  }
}
