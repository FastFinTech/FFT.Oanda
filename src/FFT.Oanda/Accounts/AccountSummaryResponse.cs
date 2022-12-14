// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The summary of a single account. Does not provide full specification of
/// pending Orders, open Trades and Positions.
/// </summary>
public sealed record AccountSummaryResponse
{
  /// <summary>
  /// The summary of the requested account.
  /// </summary>
  public AccountSummary Account { get; init; }

  /// <summary>
  /// The ID of the most recent transaction created for the account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
