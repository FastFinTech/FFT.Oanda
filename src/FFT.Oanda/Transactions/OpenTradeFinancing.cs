// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// OpenTradeFinancing is used to pay/collect daily financing charge for an
/// open Trade within an Account.
/// </summary>
public sealed record OpenTradeFinancing
{
  /// <summary>
  /// The ID of the Trade that financing is being paid/collected for.
  /// </summary>
  public int TradeId { get; init; }

  /// <summary>
  /// The amount of financing paid/collected for the Trade.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The amount of financing paid/collected in the Instrument’s base currency
  /// for the Trade.
  /// </summary>
  public decimal BaseFinancing { get; init; }

  /// <summary>
  /// The amount of financing paid/collected in the Instrument’s quote
  /// currency for the Trade.
  /// </summary>
  public decimal QuoteFinancing { get; init; }

  /// <summary>
  /// The financing rate in effect for the instrument used to calculate the
  /// the amount of financing paid/collected for the Trade. This field will
  /// only be set if the AccountFinancingMode at the time of the daily
  /// financing is DAILY_INSTRUMENT or SECOND_BY_SECOND_INSTRUMENT. The value
  /// is in decimal rather than percentage points, e.g. 5% is represented as
  /// 0.05.
  /// </summary>
  public decimal FinancingRate { get; init; }
}
