// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions;
/// <summary>
/// The dynamic (calculated) state of a position.
/// </summary>
public sealed record CalculatedPositionState
{
  /// <summary>
  /// The position’s instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The position’s net unrealized profit/loss.  Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal NetUnrealizedPL { get; init; }

  /// <summary>
  /// The unrealized profit/loss of the position’s long open trades. Expressed
  /// in the account's home currency.
  /// </summary>
  public decimal LongUnrealizedPL { get; init; }

  /// <summary>
  /// The unrealized profit/loss of the position’s short open trades.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal ShortUnrealizedPL { get; init; }

  /// <summary>
  /// Margin currently used by the position. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginUsed { get; init; }
}
