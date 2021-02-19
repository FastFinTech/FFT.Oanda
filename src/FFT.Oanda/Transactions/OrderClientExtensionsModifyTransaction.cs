// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A OrderClientExtensionsModifyTransaction represents the modification of an
  /// Order’s Client Extensions.
  /// </summary>
  public class OrderClientExtensionsModifyTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderClientExtensionsModifyTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public OrderClientExtensionsModifyTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string orderID,
      string? clientOrderID,
      ClientExtensions? clientExtensionsModify,
      ClientExtensions? tradeClientExtensionsModify)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      OrderID = orderID;
      ClientOrderID = clientOrderID;
      ClientExtensionsModify = clientExtensionsModify;
      TradeClientExtensionsModify = tradeClientExtensionsModify;
    }

    /// <summary>
    /// The ID of the Order who’s client extensions are to be modified.
    /// </summary>
    public string OrderID { get; }

    /// <summary>
    /// The original Client ID of the Order who’s client extensions are to be
    /// modified.
    /// </summary>
    public string? ClientOrderID { get; }

    /// <summary>
    /// The new Client Extensions for the Order.
    /// </summary>
    public ClientExtensions? ClientExtensionsModify { get; }

    /// <summary>
    /// The new Client Extensions for the Order’s Trade on fill.
    /// </summary>
    public ClientExtensions? TradeClientExtensionsModify { get; }
  }
}
