// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTransaction(string)"/>
  /// method.
  /// </summary>
  public sealed class GetTransactionResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTransactionResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public GetTransactionResponse(
      Transaction transaction,
      string lastTransactionId)
    {
      Transaction = transaction;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The details of the Transaction requested.
    /// </summary>
    public Transaction Transaction { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionId { get; }
  }
}
