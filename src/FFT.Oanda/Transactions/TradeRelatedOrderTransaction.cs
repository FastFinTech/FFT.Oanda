// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
/// <summary>
/// Base class for order transactions that are related to existing trades.
/// </summary>
public abstract record TradeRelatedOrderTransaction : OrderTransaction
{
  /// <summary>
  /// The ID of the Trade to close when the order is filled.
  /// </summary>
  public int TradeID { get; init; }

  /// <summary>
  /// The client ID of the Trade to be closed when the order is filled.
  /// </summary>
  public string? ClientTradeID { get; init; }
}
