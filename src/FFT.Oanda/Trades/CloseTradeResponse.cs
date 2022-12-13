// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.CloseTrade(string, string,
  /// NumUnits, CancellationToken)"/> method when the request has been accepted.
  /// </summary>
  public sealed class CloseTradeResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CloseTradeResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public CloseTradeResponse(
      MarketOrderTransaction orderCreateTransaction,
      OrderFillTransaction? orderFillTransaction,
      OrderCancelTransaction? orderCancelTransaction,
      ImmutableList<string> relatedTransactionIDs,
      int lastTransactionID)
    {
      OrderCreateTransaction = orderCreateTransaction;
      OrderFillTransaction = orderFillTransaction;
      OrderCancelTransaction = orderCancelTransaction;
      RelatedTransactionIDs = relatedTransactionIDs;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The MarketOrder Transaction created to close the Trade.
    /// </summary>
    public MarketOrderTransaction OrderCreateTransaction { get; }

    // TODO: I'm not sure if this property should be nullable or not.

    /// <summary>
    /// The OrderFill Transaction that fills the Trade-closing MarketOrder and
    /// closes the Trade.
    /// </summary>
    public OrderFillTransaction? OrderFillTransaction { get; }

    // TODO: I'm not sure if this property should be nullable or not.

    /// <summary>
    /// The OrderCancel Transaction that immediately cancelled the Trade-closing
    /// MarketOrder.
    /// </summary>
    public OrderCancelTransaction? OrderCancelTransaction { get; }

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
