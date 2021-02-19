// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda;
  using FFT.Oanda.Accounts;
  using FFT.Oanda.Trades;

  /// <summary>
  /// PositionFinancing is used to pay/collect daily financing charge for a
  /// Position within an Account.
  /// </summary>
  public sealed class PositionFinancing
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PositionFinancing"/> class.
    /// </summary>
    [JsonConstructor]
    public PositionFinancing(string instrument, decimal financing, decimal baseFinancing, decimal quoteFinancing, HomeConversionFactors homeConversionFactors, ImmutableList<OpenTradeFinancing> openTradeFinancings, AccountFinancingMode accountFinancingMode)
    {
      Instrument = instrument;
      Financing = financing;
      BaseFinancing = baseFinancing;
      QuoteFinancing = quoteFinancing;
      HomeConversionFactors = homeConversionFactors;
      OpenTradeFinancings = openTradeFinancings;
      AccountFinancingMode = accountFinancingMode;
    }

    /// <summary>
    /// The instrument of the Position that financing is being paid/collected
    /// for.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The amount of financing paid/collected for the Position.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The amount of base financing paid/collected for the Position.
    /// </summary>
    public decimal BaseFinancing { get; }

    /// <summary>
    /// The amount of quote financing paid/collected for the Position.
    /// </summary>
    public decimal QuoteFinancing { get; }

    /// <summary>
    /// The HomeConversionFactors in effect for the Position’s Instrument at the
    /// time of the DailyFinancing.
    /// </summary>
    public HomeConversionFactors HomeConversionFactors { get; }

    /// <summary>
    /// The financing paid/collected for each open Trade within the Position.
    /// </summary>
    public ImmutableList<OpenTradeFinancing> OpenTradeFinancings { get; }

    /// <summary>
    /// The account financing mode at the time of the daily financing.
    /// </summary>
    public AccountFinancingMode AccountFinancingMode { get; }
  }
}
