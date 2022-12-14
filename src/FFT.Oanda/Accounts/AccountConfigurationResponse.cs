// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;
using FFT.Oanda.Transactions;

/// <summary>
/// Contains the response to the <see
/// cref="OandaApiClient.SetAccountConfiguration(string,
/// AccountConfiguration, CancellationToken)"/> method.
/// </summary>
public sealed class AccountConfigurationResponse
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="AccountConfigurationResponse"/> class.
  /// </summary>
  [JsonConstructor]
  public AccountConfigurationResponse(
    ClientConfigureTransaction clientConfigureTransaction,
    int lastTransactionID)
  {
    ClientConfigureTransaction = clientConfigureTransaction;
    LastTransactionID = lastTransactionID;
  }

  /// <summary>
  /// The transaction that configures the Account.
  /// </summary>
  public ClientConfigureTransaction ClientConfigureTransaction { get; }

  /// <summary>
  /// The ID of the last Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; }
}
