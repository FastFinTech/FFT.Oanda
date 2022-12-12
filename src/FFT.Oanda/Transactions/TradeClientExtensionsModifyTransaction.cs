// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TradeClientExtensionsModifyTransaction represents the modification of a
  /// Trade’s Client Extensions.
  /// </summary>
  public class TradeClientExtensionsModifyTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TradeClientExtensionsModifyTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public TradeClientExtensionsModifyTransaction(
      int id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string tradeID,
      string? clientTradeID,
      ClientExtensions tradeClientExtensionsModify)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      TradeID = tradeID;
      ClientTradeID = clientTradeID;
      TradeClientExtensionsModify = tradeClientExtensionsModify;
    }

    /// <summary>
    /// The ID of the Trade who’s client extensions are to be modified.
    /// </summary>
    public string TradeID { get; }

    /// <summary>
    /// The original Client ID of the Trade who’s client extensions are to be
    /// modified.
    /// </summary>
    public string? ClientTradeID { get; }

    /// <summary>
    /// The new Client Extensions for the Trade.
    /// </summary>
    public ClientExtensions TradeClientExtensionsModify { get; }
  }
}
