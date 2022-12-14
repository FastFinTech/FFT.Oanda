// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using System.Text.Json.Serialization;

/// <summary>
/// A TradeReduce object represents a Trade for an instrument that was reduced
/// (either partially or fully) in an Account. It is found embedded in
/// Transactions that affect the position of an instrument in the account,
/// specifically the OrderFill Transaction.
/// </summary>
public sealed class TradeReduce
{
  /// <summary>
  /// Initializes a new instance of the <see cref="TradeReduce"/> class.
  /// </summary>
  [JsonConstructor]
  public TradeReduce(
    string tradeID,
    decimal units,
    decimal price,
    decimal realizedPL,
    decimal financing,
    decimal baseFinancing,
    decimal quoteFinancing,
    decimal financingRate,
    decimal? guaranteedExecutionFee,
    decimal? quoteGuaranteedExecutionFee,
    decimal halfSpreadCost)
  {
    TradeID = tradeID;
    Units = units;
    Price = price;
    RealizedPL = realizedPL;
    Financing = financing;
    BaseFinancing = baseFinancing;
    QuoteFinancing = quoteFinancing;
    FinancingRate = financingRate;
    GuaranteedExecutionFee = guaranteedExecutionFee;
    QuoteGuaranteedExecutionFee = quoteGuaranteedExecutionFee;
    HalfSpreadCost = halfSpreadCost;
  }

  /// <summary>
  /// The ID of the Trade that was opened.
  /// </summary>
  public string TradeID { get; }

  /// <summary>
  /// The number of units opened by the Trade.
  /// </summary>
  public decimal Units { get; }

  /// <summary>
  /// The average price that the units were opened at.
  /// </summary>
  public decimal Price { get; }

  /// <summary>
  /// The PL realized when reducing the Trade. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal RealizedPL { get; }

  /// <summary>
  /// The financing paid/collected when reducing the Trade. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal Financing { get; }

  /// <summary>
  /// The base financing paid/collected when reducing the Trade.
  /// </summary>
  public decimal BaseFinancing { get; }

  /// <summary>
  /// The quote financing paid/collected when reducing the Trade.
  /// </summary>
  public decimal QuoteFinancing { get; }

  /// <summary>
  /// The financing rate in effect for the instrument used to calculate the
  /// amount of financing paid/collected when reducing the Trade. This field
  /// will only be set if the AccountFinancingMode at the time of the order
  /// fill is SECOND_BY_SECOND_INSTRUMENT. The value is in decimal rather than
  /// percentage points, e.g. 5% is represented as 0.05.
  /// </summary>
  public decimal FinancingRate { get; }

  /// <summary>
  /// This is the fee that is charged for closing the Trade if it has a
  /// guaranteed Stop Loss Order attached to it. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? GuaranteedExecutionFee { get; }

  /// <summary>
  /// This is the fee that is charged for closing the Trade if it has a
  /// guaranteed Stop Loss Order attached to it, expressed in the Instrument’s
  /// quote currency.
  /// </summary>
  public decimal? QuoteGuaranteedExecutionFee { get; }

  /// <summary>
  /// The half spread cost for the trade reduce/close. This can be a positive
  /// or negative value. Expressed in the account's home currency.
  /// </summary>
  public decimal HalfSpreadCost { get; }
}
