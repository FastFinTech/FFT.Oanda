// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The representation of a position for a single direction (long or short).
/// </summary>
public sealed record PositionSide
{
  /// <summary>
  /// Number of units in the position (negative value indicates short
  /// position, positive indicates long position).
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Units { get; init; }

  /// <summary>
  /// Volume-weighted average of the underlying Trade open prices for the
  /// Position.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal AveragePrice { get; init; }

  /// <summary>
  /// List of the open Trade IDs which contribute to the open Position.
  /// </summary>
  public ImmutableList<string> TradeIDs { get; init; }

  /// <summary>
  /// Profit/loss realized by the PositionSide over the lifetime of the
  /// Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal PL { get; init; }

  /// <summary>
  /// The unrealized profit/loss of all open Trades that contribute to this
  /// PositionSide. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal UnrealizedPL { get; init; }

  /// <summary>
  /// Profit/loss realized by the PositionSide since the Account’s
  /// resettablePL was last reset by the client. Expressed in the account's
  /// home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal ResettablePL { get; init; }

  /// <summary>
  /// The total amount of financing paid/collected for this PositionSide over
  /// the lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Financing { get; init; }

  /// <summary>
  /// The total amount of dividend adjustment paid for the PositionSide over
  /// the lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal DividendAdjustment { get; init; }

  /// <summary>
  /// The total amount of fees charged over the lifetime of the Account for
  /// the execution of guaranteed Stop Loss Orders attached to Trades for this
  /// PositionSide. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal GuaranteedExecutionFees { get; init; }
}
