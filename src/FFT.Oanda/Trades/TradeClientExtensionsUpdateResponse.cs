// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.SetTradeClientExtensions(string, string, ClientExtensions, CancellationToken)"/> method.
  /// </summary>
  public sealed class TradeClientExtensionsUpdateResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="TradeClientExtensionsUpdateResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public TradeClientExtensionsUpdateResponse(
      TradeClientExtensionsModifyTransaction tradeClientExtensionsModifyTransaction,
      ImmutableList<string> relatedTransactionIDs,
      int lastTransactionID)
    {
      TradeClientExtensionsModifyTransaction = tradeClientExtensionsModifyTransaction;
      RelatedTransactionIDs = relatedTransactionIDs;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The Transaction that updates the Trade’s Client Extensions.
    /// </summary>
    public TradeClientExtensionsModifyTransaction TradeClientExtensionsModifyTransaction { get; }

    /// <summary>
    /// The IDs of all Transactions that were created while satisfying the
    /// request.
    /// </summary>
    public ImmutableList<string> RelatedTransactionIDs { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionID { get; }
  }
}
