﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A TradeOpen object represents a Trade for an instrument that was opened in
  /// an Account. It is found embedded in Transactions that affect the position
  /// of an instrument in the Account, specifically the OrderFill Transaction.
  /// </summary>
  public sealed class TradeOpen
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TradeOpen"/> class.
    /// </summary>
    [JsonConstructor]
    public TradeOpen(
      string tradeID,
      decimal units,
      decimal price,
      decimal? guaranteedExecutionFee,
      decimal? quoteGuaranteedExecutionFee,
      ClientExtensions clientExtensions,
      decimal halfSpreadCost,
      decimal initialMarginRequired)
    {
      TradeID = tradeID;
      Units = units;
      Price = price;
      GuaranteedExecutionFee = guaranteedExecutionFee;
      QuoteGuaranteedExecutionFee = quoteGuaranteedExecutionFee;
      ClientExtensions = clientExtensions;
      HalfSpreadCost = halfSpreadCost;
      InitialMarginRequired = initialMarginRequired;
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
    /// This is the fee charged for opening the trade if it has a guaranteed
    /// Stop Loss Order attached to it. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal? GuaranteedExecutionFee { get; }

    /// <summary>
    /// This is the fee charged for opening the trade if it has a guaranteed
    /// Stop Loss Order attached to it, expressed in the Instrument’s quote
    /// currency.
    /// </summary>
    public decimal? QuoteGuaranteedExecutionFee { get; }

    /// <summary>
    /// The client extensions for the newly opened Trade.
    /// </summary>
    public ClientExtensions ClientExtensions { get; }

    /// <summary>
    /// The half spread cost for the trade open. This can be a positive or
    /// negative value. Expressed in the account's home currency.
    /// </summary>
    public decimal HalfSpreadCost { get; }

    /// <summary>
    /// The margin required at the time the Trade was created. Note, this is the
    /// ‘pure’ margin required, it is not the ‘effective’ margin used that
    /// factors in the trade risk if a GSLO is attached to the trade. Expressed
    /// in the account's home currency.
    /// </summary>
    public decimal InitialMarginRequired { get; }
  }
}
