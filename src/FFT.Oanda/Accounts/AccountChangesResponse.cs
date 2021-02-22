// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Provides the account state and changes.
  /// </summary>
  public sealed class AccountChangesResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountChangesResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public AccountChangesResponse(
      AccountChanges? changes,
      AccountChangesState state,
      string lastTransactionID)
    {
      Changes = changes;
      State = state;
      LastTransactionID = lastTransactionID;
    }

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
    public string LastTransactionID { get; }
  }
}
