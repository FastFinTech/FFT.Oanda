// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// Contains the response from calls made to the <see
/// cref="OandaApiClient.GetOrderBook(string, DateTime?, CancellationToken)"/> method.
/// </summary>
public sealed record OrderBookResponse
{
  /// <summary>
  /// The instrument’s order book.
  /// </summary>
  public OrderBook OrderBook { get; init; }
}
