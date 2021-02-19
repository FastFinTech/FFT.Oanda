// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The dynamic (calculated) state of a position.
  /// </summary>
  public sealed class CalculatedPositionState
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatedPositionState"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public CalculatedPositionState(
      string instrument,
      decimal netUnrealizedPL,
      decimal longUnrealizedPL,
      decimal shortUnrealizedPL,
      decimal marginUsed)
    {
      Instrument = instrument;
      NetUnrealizedPL = netUnrealizedPL;
      LongUnrealizedPL = longUnrealizedPL;
      ShortUnrealizedPL = shortUnrealizedPL;
      MarginUsed = marginUsed;
    }

    /// <summary>
    /// The position’s instrument.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The position’s net unrealized profit/loss.  Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal NetUnrealizedPL { get; }

    /// <summary>
    /// The unrealized profit/loss of the position’s long open trades. Expressed
    /// in the account's home currency.
    /// </summary>
    public decimal LongUnrealizedPL { get; }

    /// <summary>
    /// The unrealized profit/loss of the position’s short open trades.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal ShortUnrealizedPL { get; }

    /// <summary>
    /// Margin currently used by the position. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginUsed { get; }
  }
}
