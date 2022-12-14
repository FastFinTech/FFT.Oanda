// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions;

using System.Collections.Immutable;
using System.Text.Json.Serialization;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The representation of a position for a single direction (long or short).
/// </summary>
public sealed class PositionSide
{
  /// <summary>
  /// Initializes a new instance of the <see cref="PositionSide"/> class.
  /// </summary>
  [JsonConstructor]
  public PositionSide(
    decimal units,
    decimal averagePrice,
    ImmutableList<string> tradeIDs,
    decimal pL,
    decimal unrealizedPL,
    decimal resettablePL,
    decimal financing,
    decimal dividendAdjustment,
    decimal guaranteedExecutionFees)
  {
    Units = units;
    AveragePrice = averagePrice;
    TradeIDs = tradeIDs;
    PL = pL;
    UnrealizedPL = unrealizedPL;
    ResettablePL = resettablePL;
    Financing = financing;
    DividendAdjustment = dividendAdjustment;
    GuaranteedExecutionFees = guaranteedExecutionFees;
  }

  /// <summary>
  /// Number of units in the position (negative value indicates short
  /// position, positive indicates long position).
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Units { get; }

  /// <summary>
  /// Volume-weighted average of the underlying Trade open prices for the
  /// Position.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal AveragePrice { get; }

  /// <summary>
  /// List of the open Trade IDs which contribute to the open Position.
  /// </summary>
  public ImmutableList<string> TradeIDs { get; }

  /// <summary>
  /// Profit/loss realized by the PositionSide over the lifetime of the
  /// Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal PL { get; }

  /// <summary>
  /// The unrealized profit/loss of all open Trades that contribute to this
  /// PositionSide. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal UnrealizedPL { get; }

  /// <summary>
  /// Profit/loss realized by the PositionSide since the Account’s
  /// resettablePL was last reset by the client. Expressed in the account's
  /// home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal ResettablePL { get; }

  /// <summary>
  /// The total amount of financing paid/collected for this PositionSide over
  /// the lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Financing { get; }

  /// <summary>
  /// The total amount of dividend adjustment paid for the PositionSide over
  /// the lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal DividendAdjustment { get; }

  /// <summary>
  /// The total amount of fees charged over the lifetime of the Account for
  /// the execution of guaranteed Stop Loss Orders attached to Trades for this
  /// PositionSide. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal GuaranteedExecutionFees { get; }
}
