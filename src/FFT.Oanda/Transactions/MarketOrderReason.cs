// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System.Text.Json.Serialization;

/// <summary>
/// The reason that the Market Order was created.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MarketOrderReason
{
  /// <summary>
  /// The Market Order was created at the request of a client.
  /// </summary>
  CLIENT_ORDER,

  /// <summary>
  /// The Market Order was created to close a Trade at the request of a
  /// client.
  /// </summary>
  TRADE_CLOSE,

  /// <summary>
  /// The Market Order was created to close a Position at the request of a
  /// client.
  /// </summary>
  POSITION_CLOSEOUT,

  /// <summary>
  /// The Market Order was created as part of a Margin Closeout.
  /// </summary>
  MARGIN_CLOSEOUT,

  /// <summary>
  /// The Market Order was created to close a trade marked for delayed
  /// closure.
  /// </summary>
  DELAYED_TRADE_CLOSE,
}
