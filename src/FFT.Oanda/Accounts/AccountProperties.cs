// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Properties related to an Account.
  /// </summary>
  public sealed class AccountProperties
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountProperties"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountProperties(
      string id,
      int? mT4AccountId,
      ImmutableList<string>? tags)
    {
      Id = id;
      MT4AccountId = mT4AccountId;
      Tags = tags;
    }

    /// <summary>
    /// The Account’s identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The Account’s associated MT4 Account ID. This field will not be present
    /// if the Account is not an MT4 account.
    /// </summary>
    public int? MT4AccountId { get; }

    // TODO: Api docs say "string", but most likely this will need to be changed to
    // the "Tag" data type.

    /// <summary>
    /// The Account's tags.
    /// </summary>
    public ImmutableList<string>? Tags { get; }
  }
}
