// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions;

using FFT.Oanda.Pricing;

/// <summary>
/// An OrderFillTransaction represents the filling of an Order in the client’s
/// Account.
/// </summary>
public sealed record OrderFillTransaction : Transaction
{
  /// <summary>
  /// The ID of the Order filled.
  /// </summary>
  public string OrderID { get; init; }

  /// <summary>
  /// The client Order ID of the Order filled (only provided if the client has
  /// assigned one).
  /// </summary>
  public string? ClientOrderID { get; init; }

  /// <summary>
  /// The name of the filled Order’s instrument.
  /// </summary>
  public string Instrument { get; init; }

  /// <summary>
  /// The number of units filled by the OrderFill.
  /// </summary>
  public decimal Units { get; init; }

  /// <summary>
  /// The HomeConversionFactors in effect at the time of the OrderFill.
  /// </summary>
  public HomeConversionFactors HomeConversionFactors { get; init; }

  /// <summary>
  /// The price that all of the units of the OrderFill should have been filled
  /// at, in the absence of guaranteed price execution. This factors in the
  /// Account’s current ClientPrice, used liquidity and the units of the
  /// OrderFill only. If no Trades were closed with their price clamped for
  /// guaranteed stop loss enforcement, then this value will match the price
  /// fields of each Trade opened, closed, and reduced, and they will all be
  /// the exact same.
  /// </summary>
  public decimal FullVWAP { get; init; }

  /// <summary>
  /// The price in effect for the account at the time of the Order fill.
  /// </summary>
  public ClientPrice FullPrice { get; init; }

  /// <summary>
  /// The reason that an Order was filled.
  /// </summary>
  public OrderFillReason Reason { get; init; }

  /// <summary>
  /// The profit or loss incurred when the Order was filled. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal PL { get; init; }

  /// <summary>
  /// The profit or loss incurred when the Order was filled, in the
  /// Instrument’s quote currency.
  /// </summary>
  public decimal QuotePL { get; init; }

  /// <summary>
  /// The financing paid or collected when the Order was filled. Expressed in
  /// the account's home currency.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The financing paid or collected when the Order was filled, in the
  /// Instrument’s base currency.
  /// </summary>
  public decimal BaseFinancing { get; init; }

  /// <summary>
  /// The financing paid or collected when the Order was filled, in the
  /// Instrument’s quote currency.
  /// </summary>
  public decimal QuoteFinancing { get; init; }

  /// <summary>
  /// The commission charged in the Account’s home currency as a result of
  /// filling the Order. The commission is always represented as a positive
  /// quantity of the Account’s home currency, however it reduces the balance
  /// in the Account. Expressed in the account's home currency.
  /// </summary>
  public decimal Commission { get; init; }

  /// <summary>
  /// The total guaranteed execution fees charged for all Trades opened,
  /// closed or reduced with guaranteed Stop Loss Orders. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal? GuaranteedExecutionFee { get; init; }

  /// <summary>
  /// The total guaranteed execution fees charged for all Trades opened,
  /// closed or reduced with guaranteed Stop Loss Orders, expressed in the
  /// Instrument’s quote currency.
  /// </summary>
  public decimal? QuoteGuaranteedExecutionFee { get; init; }

  /// <summary>
  /// The Account’s balance after the Order was filled. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal AccountBalance { get; init; }

  /// <summary>
  /// The Trade that was opened when the Order was filled (only provided if
  /// filling the Order resulted in a new Trade).
  /// </summary>
  public TradeOpen? TradeOpened { get; init; }

  /// <summary>
  /// The Trades that were closed when the Order was filled (only provided if
  /// filling the Order resulted in a closing open Trades).
  /// </summary>
  public ImmutableList<TradeReduce>? TradesClosed { get; init; }

  /// <summary>
  /// The Trade that was reduced when the Order was filled (only provided if
  /// filling the Order resulted in reducing an open Trade).
  /// </summary>
  public TradeReduce? TradeReduced { get; init; }

  /// <summary>
  /// The half spread cost for the OrderFill, which is the sum of the
  /// halfSpreadCost values in the tradeOpened, tradesClosed and tradeReduced
  /// fields. This can be a positive or negative value. Expressed in the
  /// account's home currency.
  /// </summary>
  public decimal HalfSpreadCost { get; init; }
}
