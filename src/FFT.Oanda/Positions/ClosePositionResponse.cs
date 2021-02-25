// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.ClosePosition(string, string,
  /// NumUnits, NumUnits, ClientExtensions?, ClientExtensions?)"/> method.
  /// </summary>
  public sealed class ClosePositionResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ClosePositionResponse"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public ClosePositionResponse(
      MarketOrderTransaction longOrderCreateTransaction,
      OrderFillTransaction longOrderFillTransaction,
      OrderCancelTransaction longOrderCancelTransaction,
      MarketOrderTransaction shortOrderCreateTransaction,
      OrderFillTransaction shortOrderFillTransaction,
      OrderCancelTransaction shortOrderCancelTransaction,
      ImmutableList<string> relatedTransactionIDs,
      string lastTransactionID)
    {
      LongOrderCreateTransaction = longOrderCreateTransaction;
      LongOrderFillTransaction = longOrderFillTransaction;
      LongOrderCancelTransaction = longOrderCancelTransaction;
      ShortOrderCreateTransaction = shortOrderCreateTransaction;
      ShortOrderFillTransaction = shortOrderFillTransaction;
      ShortOrderCancelTransaction = shortOrderCancelTransaction;
      RelatedTransactionIDs = relatedTransactionIDs;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The MarketOrderTransaction created to close the long Position.
    /// </summary>
    public MarketOrderTransaction LongOrderCreateTransaction { get; }

    /// <summary>
    /// OrderFill Transaction that closes the long Position.
    /// </summary>
    public OrderFillTransaction LongOrderFillTransaction { get; }

    /// <summary>
    /// OrderCancel Transaction that cancels the MarketOrder created to close
    /// the long Position.
    /// </summary>
    public OrderCancelTransaction LongOrderCancelTransaction { get; }

    /// <summary>
    /// The MarketOrderTransaction created to close the short Position.
    /// </summary>
    public MarketOrderTransaction ShortOrderCreateTransaction { get; }

    /// <summary>
    /// OrderFill Transaction that closes the short Position.
    /// </summary>
    public OrderFillTransaction ShortOrderFillTransaction { get; }

    /// <summary>
    /// OrderCancel Transaction that cancels the MarketOrder created to close
    /// the short Position.
    /// </summary>
    public OrderCancelTransaction ShortOrderCancelTransaction { get; }

    /// <summary>
    /// The IDs of all Transactions that were created while satisfying the
    /// request.
    /// </summary>
    public ImmutableList<string> RelatedTransactionIDs { get; }

    /// <summary>
    /// The ID of the most recent Transaction created for the Account.
    /// </summary>
    public string LastTransactionID { get; }
  }
}
