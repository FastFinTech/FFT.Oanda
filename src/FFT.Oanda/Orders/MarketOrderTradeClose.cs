// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

using System.Text.Json.Serialization;

/// <summary>
/// A MarketOrderTradeClose specifies the extensions to a Market Order that
/// has been created specifically to close a Trade.
/// </summary>
public sealed class MarketOrderTradeClose
{
  /// <summary>
  /// Initializes a new instance of the <see cref="MarketOrderTradeClose"/>
  /// class.
  /// </summary>
  [JsonConstructor]
  public MarketOrderTradeClose(
    string tradeId,
    string? clientTradeId,
    string units)
  {
    TradeId = tradeId;
    ClientTradeId = clientTradeId;
    Units = units;
  }

  /// <summary>
  /// The ID of the Trade requested to be closed.
  /// </summary>
  public string TradeId { get; }

  /// <summary>
  /// The client ID of the Trade requested to be closed.
  /// </summary>
  public string? ClientTradeId { get; }

  /// <summary>
  /// Indication of how much of the Trade to close. Either “ALL”, or a
  /// DecimalNumber reflection a partial close of the Trade.
  /// </summary>
  public string Units { get; }
}
