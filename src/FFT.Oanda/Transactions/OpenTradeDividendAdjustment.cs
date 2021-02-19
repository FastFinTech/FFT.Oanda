// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Used to pay or collect a dividend adjustment amount for an open Trade within the Account.
  /// </summary>
  public sealed class OpenTradeDividendAdjustment
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="OpenTradeDividendAdjustment"/> class.
    /// </summary>
    [JsonConstructor]
    public OpenTradeDividendAdjustment(
      string tradeId,
      decimal dividentAdjustment,
      decimal quoteDividendAdjustment)
    {
      TradeId = tradeId;
      DividentAdjustment = dividentAdjustment;
      QuoteDividendAdjustment = quoteDividendAdjustment;
    }

    /// <summary>
    /// The ID of the Trade for which the dividend adjustment is to be paid or
    /// collected.
    /// </summary>
    public string TradeId { get; }

    /// <summary>
    /// The dividend adjustment amount to pay or collect for the Trade.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal DividentAdjustment { get; }

    /// <summary>
    /// The dividend adjustment amount to pay or collect for the Trade, in the
    /// Instrument’s quote currency.
    /// </summary>
    public decimal QuoteDividendAdjustment { get; }
  }
}
