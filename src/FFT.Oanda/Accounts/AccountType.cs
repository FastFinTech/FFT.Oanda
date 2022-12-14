// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// Used to define which account api endpoint you wish to connect to.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountType
{
  /// <summary>
  /// A real-money account.
  /// </summary>
  Real,

  /// <summary>
  /// A practice account with pretend money.
  /// </summary>
  Practice,
}
