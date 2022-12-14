// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;

using System.Text.Json.Serialization;

/// <summary>
/// The classification of trade PLs.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TradePL
{
  /// <summary>
  /// An open trade currently has a positive (profitable) unrealized P/L, or a
  /// closed trade realized a positive amount of P/L.
  /// </summary>
  POSITIVE,

  /// <summary>
  /// An open trade currently has a negative (losing) unrealized P/L, or a
  /// closed trade realized a negative amount of P/L.
  /// </summary>
  NEGATIVE,

  /// <summary>
  /// An open trade currently has unrealized P/L of zero (neither profitable
  /// nor losing), or a closed trade realized a P/L amount of zero.
  /// </summary>
  ZERO,
}
