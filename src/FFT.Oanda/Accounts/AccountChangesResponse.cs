// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.JsonConverters;

/// <summary>
/// Provides the account state and changes.
/// </summary>
public sealed record AccountChangesResponse
{
  /// <summary>
  /// The changes to the Account’s Orders, Trades and Positions since the
  /// specified Transaction ID. Only provided if the sinceTransactionID is
  /// supplied to the poll request.
  /// </summary>
  public AccountChanges? Changes { get; }

  /// <summary>
  /// The Account’s current price-dependent state.
  /// </summary>
  public AccountChangesState State { get; }

  /// <summary>
  /// The ID of the last Transaction created for the Account.  This Transaction
  /// ID should be used for future poll requests, as the client has already
  /// observed all changes up to and including it.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }
}
