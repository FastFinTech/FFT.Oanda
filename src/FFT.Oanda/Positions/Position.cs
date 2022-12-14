// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The specification of a position within an account.
/// </summary>
public sealed record Position
{
  /// <summary>
  /// The position’s instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// Profit/loss realized by the position over the lifetime of the account.
  /// Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal PL { get; init; }

  /// <summary>
  /// The unrealized profit/loss of all open Trades that contribute to this
  /// Position. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal UnrealizedPL { get; init; }

  /// <summary>
  /// Margin currently used by the Position. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal MarginUsed { get; init; }

  /// <summary>
  /// Profit/loss realized by the Position since the Account’s resettablePL was
  /// last reset by the client. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal ResettablePL { get; init; }

  /// <summary>
  /// The total amount of financing paid/collected for this instrument over the
  /// lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Financing { get; init; }

  /// <summary>
  /// The total amount of commission paid for this instrument over the lifetime
  /// of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal Commission { get; init; }

  /// <summary>
  /// The total amount of dividend adjustment paid for this instrument over the
  /// lifetime of the Account. Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal DividendAdjustment { get; init; }

  /// <summary>
  /// The total amount of fees charged over the lifetime of the Account for
  /// the execution of guaranteed Stop Loss Orders for this instrument.
  /// Expressed in the account's home currency.
  /// </summary>
  [JsonConverter(typeof(DecimalStringConverter))]
  public decimal GuaranteedExecutionFees { get; init; }

  /// <summary>
  /// The details of the long side of the Position.
  /// </summary>
  public PositionSide Long { get; init; }

  /// <summary>
  /// The details of the short side of the Position.
  /// </summary>
  public PositionSide Short { get; init; }
}
