// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The overall behaviour of the account regarding guaranteed Stop Loss
  /// Orders.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum GuaranteedStopLossOrderMode
  {
    /// <summary>
    /// The Account is not permitted to create guaranteed Stop Loss Orders.
    /// </summary>
    DISABLED,

    /// <summary>
    /// The Account is able, but not required to have guaranteed Stop Loss
    /// Orders for open Trades.
    /// </summary>
    ALLOWED,

    /// <summary>
    /// The Account is required to have guaranteed Stop Loss Orders for all open
    /// Trades.
    /// </summary>
    REQUIRED,
  }
}
