// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTrade(string, string, CancellationToken)"/>
  /// method.
  /// </summary>
  public sealed class GetTradeResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTradeResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public GetTradeResponse(
      Trade trade,
      int lastTransactionId)
    {
      Trade = trade;
      LastTransactionId = lastTransactionId;
    }

    /// <summary>
    /// The details of the requested trade.
    /// </summary>
    public Trade Trade { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionId { get; }
  }
}
