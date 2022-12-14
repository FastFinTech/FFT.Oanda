// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
/// <summary>
/// Properties related to an Account.
/// </summary>
public sealed record AccountProperties
{
  /// <summary>
  /// The Account’s identifier.
  /// </summary>
  public string Id { get; init; }

  /// <summary>
  /// The Account’s associated MT4 Account ID. This field will not be present
  /// if the Account is not an MT4 account.
  /// </summary>
  public int? MT4AccountId { get; init; }

  // TODO: Api docs say "string", but most likely this will need to be changed to
  // the "Tag" data type.

  /// <summary>
  /// The Account's tags.
  /// </summary>
  public ImmutableList<string>? Tags { get; init; }
}
