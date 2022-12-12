// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;
  using FFT.Oanda.Orders;

  /// <summary>
  /// The specification of a Trade within an Account. This includes the full
  /// representation of the Trade’s dependent Orders in addition to the IDs of
  /// those Orders.
  /// </summary>
  public sealed class Trade
  {
    // TODO: This class seems to be missing the GuaranteedStopLossOrder property
    // (omitted from documenation, perhaps?)

    /// <summary>
    /// Initializes a new instance of the <see cref="Trade"/> class.
    /// </summary>
    [JsonConstructor]
    public Trade(
      string id,
      string instrument,
      decimal price,
      DateTime openTime,
      TradeState state,
      decimal initialUnits,
      decimal initialMarginRequired,
      decimal currentUnits,
      decimal realizedPL,
      decimal unrealizedPL,
      decimal marginUsed,
      decimal? averageClosePrice,
      ImmutableList<string> closingTransactionIDs,
      decimal financing,
      decimal dividendAdjustment,
      DateTime? closeTime,
      ClientExtensions? clientExtensions,
      TakeProfitOrder? takeProfitOrder,
      StopLossOrder? stopLossOrder,
      TrailingStopLossOrder? trailingStopLossOrder)
    {
      Id = id;
      Instrument = instrument;
      Price = price;
      OpenTime = openTime;
      State = state;
      InitialUnits = initialUnits;
      InitialMarginRequired = initialMarginRequired;
      CurrentUnits = currentUnits;
      RealizedPL = realizedPL;
      UnrealizedPL = unrealizedPL;
      MarginUsed = marginUsed;
      AverageClosePrice = averageClosePrice;
      ClosingTransactionIDs = closingTransactionIDs;
      Financing = financing;
      DividendAdjustment = dividendAdjustment;
      CloseTime = closeTime;
      ClientExtensions = clientExtensions;
      TakeProfitOrder = takeProfitOrder;
      StopLossOrder = stopLossOrder;
      TrailingStopLossOrder = trailingStopLossOrder;
    }

    /// <summary>
    /// The Trade’s identifier, unique within the Trade’s Account.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// The Trade’s Instrument.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The execution price of the Trade.
    /// </summary>
    public decimal Price { get; }

    /// <summary>
    /// The date/time when the Trade was opened.
    /// </summary>
    public DateTime OpenTime { get; }

    /// <summary>
    /// The current state of the Trade.
    /// </summary>
    public TradeState State { get; }

    /// <summary>
    /// The initial size of the Trade. Negative values indicate a short Trade,
    /// and positive values indicate a long Trade.
    /// </summary>
    public decimal InitialUnits { get; }

    /// <summary>
    /// The margin required at the time the Trade was created. Note, this is the
    /// ‘pure’ margin required, it is not the ‘effective’ margin used that
    /// factors in the trade risk if a GSLO is attached to the trade. Expressed
    /// in the account's home currency.
    /// </summary>
    public decimal InitialMarginRequired { get; }

    /// <summary>
    /// The number of units currently open for the Trade. This value is reduced
    /// to 0.0 as the Trade is closed.
    /// </summary>
    public decimal CurrentUnits { get; }

    /// <summary>
    /// The total profit/loss realized on the closed portion of the Trade.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal RealizedPL { get; }

    /// <summary>
    /// The unrealized profit/loss on the open portion of the Trade. Expressed
    /// in the account's home currency.
    /// </summary>
    public decimal UnrealizedPL { get; }

    /// <summary>
    /// Margin currently used by the Trade. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginUsed { get; }

    /// <summary>
    /// The average closing price of the Trade. Only present if the Trade has
    /// been closed or reduced at least once.
    /// </summary>
    public decimal? AverageClosePrice { get; }

    /// <summary>
    /// The IDs of the Transactions that have closed portions of this Trade.
    /// </summary>
    public ImmutableList<string> ClosingTransactionIDs { get; }

    /// <summary>
    /// The financing paid/collected for this Trade. Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The dividend adjustment paid for this Trade. Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal DividendAdjustment { get; }

    /// <summary>
    /// The date/time when the Trade was fully closed. Only provided for Trades
    /// whose state is CLOSED.
    /// </summary>
    public DateTime? CloseTime { get; }

    /// <summary>
    /// The client extensions of the Trade.
    /// </summary>
    public ClientExtensions? ClientExtensions { get; }

    /// <summary>
    /// Full representation of the Trade’s Take Profit Order, only provided if
    /// such an Order exists.
    /// </summary>
    public TakeProfitOrder? TakeProfitOrder { get; }

    /// <summary>
    /// Full representation of the Trade’s Stop Loss Order, only provided if
    /// such an Order exists.
    /// </summary>
    public StopLossOrder? StopLossOrder { get; }

    /// <summary>
    /// Full representation of the Trade’s Trailing Stop Loss Order, only
    /// provided if such an Order exists.
    /// </summary>
    public TrailingStopLossOrder? TrailingStopLossOrder { get; }
  }
}
