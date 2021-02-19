// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// A DividendAdjustment Transaction is created administratively to pay or
  /// collect dividend adjustment mounts to or from an Account.
  /// </summary>
  public sealed class DividendAdjustmentTransaction : Transaction
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DividendAdjustmentTransaction"/> class.
    /// </summary>
    [JsonConstructor]
    public DividendAdjustmentTransaction(
      string id,
      DateTime time,
      int? userID,
      string accountID,
      string? batchID,
      string? requestID,
      TransactionType type,
      string instrument,
      decimal dividendAdjustment,
      decimal quoteDividendAdjustment,
      HomeConversionFactors homeConversionFactors,
      decimal accountBalance,
      ImmutableList<OpenTradeDividendAdjustment> openTradeDividendAdjustments)
        : base(
          id,
          time,
          userID,
          accountID,
          batchID,
          requestID,
          type)
    {
      Instrument = instrument;
      DividendAdjustment = dividendAdjustment;
      QuoteDividendAdjustment = quoteDividendAdjustment;
      HomeConversionFactors = homeConversionFactors;
      AccountBalance = accountBalance;
      OpenTradeDividendAdjustments = openTradeDividendAdjustments;
    }

    /// <summary>
    /// The name of the instrument for the dividendAdjustment transaction.
    /// </summary>
    public string Instrument { get; }

    /// <summary>
    /// The total dividend adjustment amount paid or collected in the Account’s
    /// home currency for the Account as a result of applying the
    /// DividendAdjustment Transaction. This is the sum of the dividend
    /// adjustments paid/collected for each OpenTradeDividendAdjustment found
    /// within the Transaction. Expressed in the account's home currency.
    /// </summary>
    public decimal DividendAdjustment { get; }

    /// <summary>
    /// The total dividend adjustment amount paid or collected in the
    /// Instrument’s quote currency for the Account as a result of applying the
    /// DividendAdjustment Transaction. This is the sum of the quote dividend
    /// adjustments paid/collected for each OpenTradeDividendAdjustment found
    /// within the Transaction.
    /// </summary>
    public decimal QuoteDividendAdjustment { get; }

    /// <summary>
    /// The HomeConversionFactors in effect at the time of the
    /// DividendAdjustment.
    /// </summary>
    public HomeConversionFactors HomeConversionFactors { get; }

    /// <summary>
    /// The Account balance after applying the DividendAdjustment Transaction.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal AccountBalance { get; }

    /// <summary>
    /// The dividend adjustment payment/collection details for each open Trade,
    /// within the Account, for which a dividend adjustment is to be paid or
    /// collected.
    /// </summary>
    public ImmutableList<OpenTradeDividendAdjustment> OpenTradeDividendAdjustments { get; }
  }
}
