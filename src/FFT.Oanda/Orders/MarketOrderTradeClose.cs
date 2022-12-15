// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// A MarketOrderTradeClose specifies the extensions to a Market Order that
/// has been created specifically to close a Trade.
/// </summary>
public sealed record MarketOrderTradeClose
{
  /// <summary>
  /// The ID of the Trade requested to be closed.
  /// </summary>
  public int TradeId { get; init; }

  /// <summary>
  /// The client ID of the Trade requested to be closed.
  /// </summary>
  public string? ClientTradeId { get; init; }

  /// <summary>
  /// Indication of how much of the Trade to close. Either “ALL”, or a
  /// DecimalNumber reflection a partial close of the Trade.
  /// </summary>
  public NumUnits Units { get; init; }
}
