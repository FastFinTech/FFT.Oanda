// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTransaction(string, string, CancellationToken)"/>
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
      int lastTransactionId)
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
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionId { get; }
  }
}
