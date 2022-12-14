// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The full details of an account. This includes full open trade, open
/// position and pending order representation.
/// </summary>
public sealed record AccountResponse
{
  /// <summary>
  /// The full details of the requested account.
  /// </summary>
  public Account Account { get; init; }

  /// <summary>
  /// The ID of the most recent transaction created for the account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
