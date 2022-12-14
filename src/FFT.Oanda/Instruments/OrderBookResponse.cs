// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

using System;
using System.Text.Json.Serialization;

/// <summary>
/// Contains the response from calls made to the <see
/// cref="OandaApiClient.GetOrderBook(string, DateTime?, CancellationToken)"/> method.
/// </summary>
public sealed class OrderBookResponse
{
  /// <summary>
  /// Initializes a new instance of the <see cref="OrderBookResponse"/> class.
  /// </summary>
  [JsonConstructor]
  public OrderBookResponse(
    OrderBook orderBook)
  {
    OrderBook = orderBook;
  }

  /// <summary>
  /// The instrument’s order book.
  /// </summary>
  public OrderBook OrderBook { get; }
}
