// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// In the context of an Order or a Trade, defines whether the units are
  /// positive or negative.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum Direction
  {
    /// <summary>
    /// A long Order is used to to buy units of an Instrument. A Trade is long
    /// when it has bought units of an Instrument.
    /// </summary>
    LONG,

    /// <summary>
    /// A short Order is used to to sell units of an Instrument. A Trade is
    /// short when it has sold units of an Instrument.
    /// </summary>
    SHORT,
  }
}
