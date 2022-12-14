// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders.OrderRequests;
/// <summary>
/// Base class for all order requests that will close an existing trade.
/// </summary>
public abstract record CloseTradeOrderRequest : OrderRequest
{
  /// <summary>
  /// The ID of the Trade to close when the price threshold is breached.
  /// </summary>
  public int TradeID { get; init; }

  /// <summary>
  /// The client ID of the Trade to be closed when the price threshold is
  /// breached.
  /// </summary>
  public string? ClientTradeID { get; init; }
}
