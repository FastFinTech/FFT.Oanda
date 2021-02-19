// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The status of the Price.
  /// </summary>
  /// <remarks>This enum uses a custom json converter because the oanda api
  /// specifies string that have invalid characters for enum names and we needed
  /// to create a workaround for that if we are to use an enum to represent PriceStatus.</remarks>
  [JsonConverter(typeof(PriceStatusConverter))]
  public enum PriceStatus
  {
    /// <summary>
    /// The Instrument’s price is tradeable.
    /// </summary>
    TRADEABLE,

    /// <summary>
    /// The Instrument’s price is not tradeable.
    /// </summary>
    NONTRADEABLE,

    /// <summary>
    /// The Instrument of the price is invalid or there is no valid Price for the Instrument.
    /// </summary>
    INVALID,
  }
}
