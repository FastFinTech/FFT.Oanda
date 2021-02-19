// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// An OrderFillTransaction represents the filling of an Order in the client’s
  /// Account.
  /// </summary>
  public sealed class OrderFillTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OrderFillTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public OrderFillTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string orderID,
      string? clientOrderID,
      string instrument,
      decimal units,
      HomeConversionFactors homeConversionFactors,
      decimal fullVWAP,
      decimal fullPrice,
      OrderFillReason reason,
      decimal pL,
      decimal quotePL,
      decimal financing,
      decimal baseFinancing,
      decimal quoteFinancing,
      decimal commission,
      decimal? guaranteedExecutionFee,
      decimal? quoteGuaranteedExecutionFee,
      decimal accountBalance,
      TradeOpen? tradeOpened,
      ImmutableList<TradeReduce>? tradesClosed,
      TradeReduce? tradeReduced,
      decimal halfSpreadCost)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      OrderID = orderID;
      ClientOrderID = clientOrderID;
      Instrument = instrument;
      Units = units;
      HomeConversionFactors = homeConversionFactors;
      FullVWAP = fullVWAP;
      FullPrice = fullPrice;
      Reason = reason;
      PL = pL;
      QuotePL = quotePL;
      Financing = financing;
      BaseFinancing = baseFinancing;
      QuoteFinancing = quoteFinancing;
      Commission = commission;
      GuaranteedExecutionFee = guaranteedExecutionFee;
      QuoteGuaranteedExecutionFee = quoteGuaranteedExecutionFee;
      AccountBalance = accountBalance;
      TradeOpened = tradeOpened;
      TradesClosed = tradesClosed;
      TradeReduced = tradeReduced;
      HalfSpreadCost = halfSpreadCost;
    }

    /// <summary>
    /// The ID of the Order filled.
    /// </summary>
    public string OrderID { get; }

    /// <summary>
    /// The client Order ID of the Order filled (only provided if the client has
    /// assigned one).
    /// </summary>
    public string? ClientOrderID { get; }

    /// <summary>
    /// The name of the filled Order’s instrument.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The number of units filled by the OrderFill.
    /// </summary>
    public decimal Units { get; }

    /// <summary>
    /// The HomeConversionFactors in effect at the time of the OrderFill.
    /// </summary>
    public HomeConversionFactors HomeConversionFactors { get; }

    /// <summary>
    /// The price that all of the units of the OrderFill should have been filled
    /// at, in the absence of guaranteed price execution. This factors in the
    /// Account’s current ClientPrice, used liquidity and the units of the
    /// OrderFill only. If no Trades were closed with their price clamped for
    /// guaranteed stop loss enforcement, then this value will match the price
    /// fields of each Trade opened, closed, and reduced, and they will all be
    /// the exact same.
    /// </summary>
    public decimal FullVWAP { get; }

    /// <summary>
    /// The price in effect for the account at the time of the Order fill.
    /// </summary>
    public decimal FullPrice { get; }

    /// <summary>
    /// The reason that an Order was filled.
    /// </summary>
    public OrderFillReason Reason { get; }

    /// <summary>
    /// The profit or loss incurred when the Order was filled. Expressed in the
    /// account's home currency.
    /// </summary>
    public decimal PL { get; }

    /// <summary>
    /// The profit or loss incurred when the Order was filled, in the
    /// Instrument’s quote currency.
    /// </summary>
    public decimal QuotePL { get; }

    /// <summary>
    /// The financing paid or collected when the Order was filled. Expressed in
    /// the account's home currency.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The financing paid or collected when the Order was filled, in the
    /// Instrument’s base currency.
    /// </summary>
    public decimal BaseFinancing { get; }

    /// <summary>
    /// The financing paid or collected when the Order was filled, in the
    /// Instrument’s quote currency.
    /// </summary>
    public decimal QuoteFinancing { get; }

    /// <summary>
    /// The commission charged in the Account’s home currency as a result of
    /// filling the Order. The commission is always represented as a positive
    /// quantity of the Account’s home currency, however it reduces the balance
    /// in the Account. Expressed in the account's home currency.
    /// </summary>
    public decimal Commission { get; }

    /// <summary>
    /// The total guaranteed execution fees charged for all Trades opened,
    /// closed or reduced with guaranteed Stop Loss Orders. Expressed in the
    /// account's home currency.
    /// </summary>
    public decimal? GuaranteedExecutionFee { get; }

    /// <summary>
    /// The total guaranteed execution fees charged for all Trades opened,
    /// closed or reduced with guaranteed Stop Loss Orders, expressed in the
    /// Instrument’s quote currency.
    /// </summary>
    public decimal? QuoteGuaranteedExecutionFee { get; }

    /// <summary>
    /// The Account’s balance after the Order was filled. Expressed in the
    /// account's home currency.
    /// </summary>
    public decimal AccountBalance { get; }

    /// <summary>
    /// The Trade that was opened when the Order was filled (only provided if
    /// filling the Order resulted in a new Trade).
    /// </summary>
    public TradeOpen? TradeOpened { get; }

    /// <summary>
    /// The Trades that were closed when the Order was filled (only provided if
    /// filling the Order resulted in a closing open Trades).
    /// </summary>
    public ImmutableList<TradeReduce>? TradesClosed { get; }

    /// <summary>
    /// The Trade that was reduced when the Order was filled (only provided if
    /// filling the Order resulted in reducing an open Trade).
    /// </summary>
    public TradeReduce? TradeReduced { get; }

    /// <summary>
    /// The half spread cost for the OrderFill, which is the sum of the
    /// halfSpreadCost values in the tradeOpened, tradesClosed and tradeReduced
    /// fields. This can be a positive or negative value. Expressed in the
    /// account's home currency.
    /// </summary>
    public decimal HalfSpreadCost { get; }
  }
}
