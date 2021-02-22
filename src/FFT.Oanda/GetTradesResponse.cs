// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Collections.Immutable;
  using FFT.Oanda.Trades;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetTrades(string,
  /// TradeStateFilter, string?, int, string?, string[]?)"/> method.
  /// </summary>
  public sealed class GetTradesResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GetTradesResponse"/> class.
    /// </summary>
    public GetTradesResponse(
      ImmutableList<Trade> trades,
      string lastTransactionID)
    {
      Trades = trades;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The list of Trade detail objects.
    /// </summary>
    public ImmutableList<Trade> Trades { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionID { get; }
  }
}
