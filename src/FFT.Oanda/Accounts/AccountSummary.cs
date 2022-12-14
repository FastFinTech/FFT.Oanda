// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.JsonConverters;

/// <summary>
/// A summary representation of a client’s account. Does not provide full
/// specification of pending Orders, open Trades and Positions.
/// </summary>
public abstract record AccountSummary
{
  /// <summary>
  /// The account’s identifier.
  /// </summary>
  public string Id { get; init; }

  /// <summary>
  /// Client-assigned alias for the Account. Only provided if the account has
  /// an alias set.
  /// </summary>
  public string? Alias { get; init; }

  /// <summary>
  /// The home currency of the account.
  /// </summary>
  public string Currency { get; init; }

  /// <summary>
  /// ID of the user that created the account.
  /// </summary>
  public int CreatedByUserId { get; init; }

  /// <summary>
  /// The date/time when the account was created.
  /// </summary>
  public DateTime CreatedTime { get; init; }

  /// <summary>
  /// The current guaranteed Stop Loss Order settings of the account. This
  /// field will only be present if the guaranteedStopLossOrderMode is not
  /// ‘DISABLED’.
  /// </summary>
  public GuaranteedStopLossOrderParameters? GuaranteedStopLossOrderParameters { get; init; }

  /// <summary>
  /// The current guaranteed Stop Loss Order mode of the account.
  /// </summary>
  public GuaranteedStopLossOrderMode GuaranteedStopLossOrderMode { get; init; }

  /*
  /// <summary>
  /// The date/time that the account’s resettablePL was last reset.
  /// </summary>
  public DateTime ResettablePLTime { get; init; }
  */

  /// <summary>
  /// Client-provided margin rate override for the account. The effective
  /// margin rate of the account is the lesser of this value and the OANDA
  /// margin rate for the account’s division. This value is only provided if a
  /// margin rate override exists for the account.
  /// </summary>
  public decimal? MarginRate { get; init; }

  /// <summary>
  /// The number of trades currently open in the account.
  /// </summary>
  public int OpenTradeCount { get; init; }

  /// <summary>
  /// The number of positions currently open in the account.
  /// </summary>
  public int OpenPositionCount { get; init; }

  /// <summary>
  /// The number of orders currently pending in the account.
  /// </summary>
  public int PendingOrderCount { get; init; }

  /// <summary>
  /// Flag indicating that the account has hedging enabled.
  /// </summary>
  public bool HedgingEnabled { get; init; }

  /// <summary>
  /// The total unrealized profit/loss for all trades currently open in the
  /// account. Expressed in the account's home currency.
  /// </summary>
  public decimal UnrealizedPL { get; init; }

  /// <summary>
  /// The net asset value of the account. Equal to account balance +
  /// unrealizedPL.
  /// </summary>
  public decimal NAV { get; init; }

  /// <summary>
  /// Margin currently used for the account. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginUsed { get; init; }

  /// <summary>
  /// Margin available for the account. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginAvailable { get; init; }

  /// <summary>
  /// The value of the account’s open positions represented in the account’s
  /// home currency.
  /// </summary>
  public decimal PositionValue { get; init; }

  /// <summary>
  /// The account’s margin closeout unrealized PL. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal MarginCloseoutUnrealizedPL { get; init; }

  /// <summary>
  /// The Account’s margin closeout NAV. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginCloseoutNAV { get; init; }

  /// <summary>
  /// The Account’s margin closeout margin used. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal MarginCloseoutMarginUsed { get; init; }

  /// <summary>
  /// The account’s margin closeout percentage. When this value is 1.0 or
  /// above the account is in a margin closeout situation.
  /// </summary>
  public decimal MarginCloseoutPercent { get; init; }

  /// <summary>
  /// The value of the account’s open positions as used for margin closeout
  /// calculations. Expressed in the account's home currency.
  /// </summary>
  public decimal MarginCloseoutPositionValue { get; init; }

  /// <summary>
  /// The current WithdrawalLimit for the account which will be zero or a
  /// positive value indicating how much can be withdrawn from the account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal WithdrawalLimit { get; init; }

  /// <summary>
  /// The account’s margin call margin used. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginCallMarginUsed { get; init; }

  /// <summary>
  /// The account’s margin call percentage. When this value is 1.0 or above
  /// the account is in a margin call situation.
  /// </summary>
  public decimal MarginCallPercent { get; init; }

  /// <summary>
  /// The current balance of the account. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal Balance { get; init; }

  /// <summary>
  /// The total profit/loss realized over the lifetime of the account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal PL { get; init; }

  /// <summary>
  /// The total realized profit/loss for the account since it was last reset
  /// by the client. Expressed in the account's home currency.
  /// </summary>
  public decimal ResettablePL { get; init; }

  /// <summary>
  /// The total amount of financing paid/collected over the lifetime of the
  /// account. Expressed in the account's home currency.
  /// </summary>
  public decimal Financing { get; init; }

  /// <summary>
  /// The total amount of commission paid over the lifetime of the account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal Commission { get; init; }

  /// <summary>
  /// The total amount of dividend adjustment paid over the lifetime of the
  /// account. Expressed in the account’s home currency.
  /// </summary>
  public decimal DividendAdjustment { get; init; }

  /// <summary>
  /// The total amount of fees charged over the lifetime of the account for the
  /// execution of guaranteed Stop Loss Orders. Expressed in the account’s home currency.
  /// </summary>
  public decimal GuaranteedExecutionFees { get; init; }

  /// <summary>
  /// The date/time when the account entered a margin call state. Only
  /// provided if the account is in a margin call.
  /// </summary>
  public DateTime? MarginCallEnterTime { get; init; }

  /// <summary>
  /// The number of times that the account’s current margin call was extended.
  /// </summary>
  public int MarginCallExtensionCount { get; init; }

  /// <summary>
  /// The date/time of the account’s last margin call extension.
  /// </summary>
  public DateTime LastMarginCallExtensionTime { get; init; }

  /// <summary>
  /// The ID of the last Transaction created for the Account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionID { get; init; }
}
