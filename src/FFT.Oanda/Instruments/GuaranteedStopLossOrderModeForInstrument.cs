// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The overall behaviour of the Account regarding Guaranteed Stop Loss Orders
  /// for a specific Instrument.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum GuaranteedStopLossOrderModeForInstrument
  {
    /// <summary>
    /// The Account is not permitted to create Guaranteed Stop Loss Orders for
    /// this Instrument.
    /// </summary>
    DISABLED,

    /// <summary>
    /// The Account is able, but not required to have Guaranteed Stop Loss
    /// Orders for open Trades for this Instrument.
    /// </summary>
    ALLOWED,

    /// <summary>
    /// The Account is required to have Guaranteed Stop Loss Orders for all open
    /// Trades for this Instrument.
    /// </summary>
    REQUIRED,
  }

}
