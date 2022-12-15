// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;
using FFT.Oanda;
using FFT.Oanda.Accounts;

/// <summary>
/// PositionFinancing is used to pay/collect daily financing charge for a
/// Position within an Account.
/// </summary>
public sealed record PositionFinancing
{
  /// <summary>
  /// The instrument of the Position that financing is being paid/collected
  /// for.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The amount of financing paid/collected for the Position.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The amount of base financing paid/collected for the Position.
  /// </summary>
  public decimal BaseFinancing { get; init; }

  /// <summary>
  /// The amount of quote financing paid/collected for the Position.
  /// </summary>
  public decimal QuoteFinancing { get; init; }

  /// <summary>
  /// The HomeConversionFactors in effect for the Position’s Instrument at the
  /// time of the DailyFinancing.
  /// </summary>
  public HomeConversionFactors HomeConversionFactors { get; init; }

  /// <summary>
  /// The financing paid/collected for each open Trade within the Position.
  /// </summary>
  public ImmutableList<OpenTradeFinancing> OpenTradeFinancings { get; init; }

  /// <summary>
  /// The account financing mode at the time of the daily financing.
  /// </summary>
  public AccountFinancingMode AccountFinancingMode { get; init; }
}
