// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// Base class for all order requests that will close an existing trade.
/// </summary>
public abstract class CloseTradeOrderRequest : OrderRequest
{
  /// <summary>
  /// Initializes a new instance of the <see cref="CloseTradeOrderRequest"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  protected CloseTradeOrderRequest(
    OrderType type,
    TimeInForce timeInForce,
    DateTime? gtdTime,
    OrderTriggerCondition triggerCondition,
    ClientExtensions? clientExtensions,
    string tradeID,
    string? clientTradeID)
      : base(
          type,
          timeInForce,
          gtdTime,
          triggerCondition,
          clientExtensions)
  {
    if (string.IsNullOrWhiteSpace(tradeID))
    {
      throw new ArgumentException($"'{nameof(tradeID)}' cannot be empty.", nameof(tradeID));
    }

    TradeID = tradeID;
    ClientTradeID = clientTradeID;
  }

  /// <summary>
  /// The ID of the Trade to close when the price threshold is breached.
  /// </summary>
  public string TradeID { get; }

  /// <summary>
  /// The client ID of the Trade to be closed when the price threshold is
  /// breached.
  /// </summary>
  public string? ClientTradeID { get; }
}
