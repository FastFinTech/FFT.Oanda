// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Positions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The specification of a position within an account.
  /// </summary>
  public sealed class Position
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class.
    /// </summary>
    [JsonConstructor]
    public Position(
      string instrument,
      decimal pL,
      decimal unrealizedPL,
      decimal marginUsed,
      decimal resettablePL,
      decimal financing,
      decimal commission,
      decimal dividendAdjustment,
      decimal guaranteedExecutionFees,
      PositionSide @long,
      PositionSide @short)
    {
      Instrument = instrument;
      PL = pL;
      UnrealizedPL = unrealizedPL;
      MarginUsed = marginUsed;
      ResettablePL = resettablePL;
      Financing = financing;
      Commission = commission;
      DividendAdjustment = dividendAdjustment;
      GuaranteedExecutionFees = guaranteedExecutionFees;
      Long = @long;
      Short = @short;
    }

    /// <summary>
    /// The position’s instrument.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// Profit/loss realized by the position over the lifetime of the account.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal PL { get; }

    /// <summary>
    /// The unrealized profit/loss of all open Trades that contribute to this
    /// Position. Expressed in the account's home currency.
    /// </summary>
    public decimal UnrealizedPL { get; }

    /// <summary>
    /// Margin currently used by the Position. Expressed in the account's home currency.
    /// </summary>
    public decimal MarginUsed { get; }

    /// <summary>
    /// Profit/loss realized by the Position since the Account’s resettablePL was
    /// last reset by the client. Expressed in the account's home currency.
    /// </summary>
    public decimal ResettablePL { get; }

    /// <summary>
    /// The total amount of financing paid/collected for this instrument over the
    /// lifetime of the Account. Expressed in the account's home currency.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The total amount of commission paid for this instrument over the lifetime
    /// of the Account. Expressed in the account's home currency.
    /// </summary>
    public decimal Commission { get; }

    /// <summary>
    /// The total amount of dividend adjustment paid for this instrument over the
    /// lifetime of the Account. Expressed in the account's home currency.
    /// </summary>
    public decimal DividendAdjustment { get; }

    /// <summary>
    /// The total amount of fees charged over the lifetime of the Account for
    /// the execution of guaranteed Stop Loss Orders for this instrument.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal GuaranteedExecutionFees { get; }

    /// <summary>
    /// The details of the long side of the Position.
    /// </summary>
    public PositionSide Long { get; }

    /// <summary>
    /// The details of the short side of the Position.
    /// </summary>
    public PositionSide Short { get; }
  }
}
