// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

/// <summary>
/// A TradeReduce object represents a Trade for an instrument that was reduced
/// (either partially or fully) in an Account. It is found embedded in
/// Transactions that affect the position of an instrument in the account,
/// specifically the OrderFill Transaction.
/// </summary>
public sealed record TradeReduce
{
  /// <summary>
  /// The ID of the Trade that was opened.
  /// </summary>
  public int TradeID { get; init; }

  /// <summary>
  /// The number of units that the trade was reduced by.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The average price that the units were closed at.
  /// </summary>
  public decimal Price { get; init; }

  /// <summary>
  /// The PL realized when reducing the Trade. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal RealizedPL { get; init; }

  /// <summary>
  /// The financing paid/collected when reducing the Trade. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The base financing paid/collected when reducing the Trade.
  /// </summary>
  public decimal BaseFinancing { get; init; }

  /// <summary>
  /// The quote financing paid/collected when reducing the Trade.
  /// </summary>
  public decimal QuoteFinancing { get; init; }

  /// <summary>
  /// The financing rate in effect for the instrument used to calculate the
  /// amount of financing paid/collected when reducing the Trade. This field
  /// will only be set if the AccountFinancingMode at the time of the order
  /// fill is SECOND_BY_SECOND_INSTRUMENT. The value is in decimal rather than
  /// percentage points, e.g. 5% is represented as 0.05.
  /// </summary>
  public decimal FinancingRate { get; init; }

  /// <summary>
  /// This is the fee that is charged for closing the Trade if it has a
  /// guaranteed Stop Loss Order attached to it. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? GuaranteedExecutionFee { get; init; }

  /// <summary>
  /// This is the fee that is charged for closing the Trade if it has a
  /// guaranteed Stop Loss Order attached to it, expressed in the Instrument’s
  /// quote currency.
  /// </summary>
  public decimal? QuoteGuaranteedExecutionFee { get; init; }

  /// <summary>
  /// The half spread cost for the trade reduce/close. This can be a positive
  /// or negative value. Expressed in the account's home currency.
  /// </summary>
  public decimal HalfSpreadCost { get; init; }
}
