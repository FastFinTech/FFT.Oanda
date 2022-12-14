// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
/// <summary>
/// Used to set account configuration parameters.
/// </summary>
public sealed record AccountConfiguration
{
  /// <summary>
  /// Client-defined alias (name) for the Account.
  /// </summary>
  public string Alias { get; init; }

  /// <summary>
  /// Desired margin rate for the account.
  /// </summary>
  public decimal MarginRate { get; init; }
}
