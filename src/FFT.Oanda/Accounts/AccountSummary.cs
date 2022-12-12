// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts
{
  using System;
  using System.Text.Json.Serialization;
  using FFT.Oanda.JsonConverters;

  /// <summary>
  /// A summary representation of a client’s account. Does not provide full
  /// specification of pending Orders, open Trades and Positions.
  /// </summary>
  public class AccountSummary
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AccountSummary"/> class.
    /// </summary>
    [JsonConstructor]
    public AccountSummary(
      string id,
      string? alias,
      string currency,
      int createdByUserId,
      DateTime createdTime,
      GuaranteedStopLossOrderParameters? guaranteedStopLossOrderParameters,
      GuaranteedStopLossOrderMode guaranteedStopLossOrderMode,
      decimal? marginRate,
      int openTradeCount,
      int openPositionCount,
      int pendingOrderCount,
      bool hedgingEnabled,
      decimal unrealizedPL,
      decimal nAV,
      decimal marginUsed,
      decimal marginAvailable,
      decimal positionValue,
      decimal marginCloseoutUnrealizedPL,
      decimal marginCloseoutNAV,
      decimal marginCloseoutMarginUsed,
      decimal marginCloseoutPercent,
      decimal marginCloseoutPositionValue,
      decimal withdrawalLimit,
      decimal marginCallMarginUsed,
      decimal marginCallPercent,
      decimal balance,
      decimal pL,
      decimal resettablePL,
      decimal financing,
      decimal commission,
      decimal dividendAdjustment,
      decimal guaranteedExecutionFees,
      DateTime? marginCallEnterTime,
      int marginCallExtensionCount,
      DateTime lastMarginCallExtensionTime,
      int lastTransactionID)
    {
      Id = id;
      Alias = alias;
      Currency = currency;
      CreatedByUserId = createdByUserId;
      CreatedTime = createdTime;
      GuaranteedStopLossOrderParameters = guaranteedStopLossOrderParameters;
      GuaranteedStopLossOrderMode = guaranteedStopLossOrderMode;
      MarginRate = marginRate;
      OpenTradeCount = openTradeCount;
      OpenPositionCount = openPositionCount;
      PendingOrderCount = pendingOrderCount;
      HedgingEnabled = hedgingEnabled;
      UnrealizedPL = unrealizedPL;
      NAV = nAV;
      MarginUsed = marginUsed;
      MarginAvailable = marginAvailable;
      PositionValue = positionValue;
      MarginCloseoutUnrealizedPL = marginCloseoutUnrealizedPL;
      MarginCloseoutNAV = marginCloseoutNAV;
      MarginCloseoutMarginUsed = marginCloseoutMarginUsed;
      MarginCloseoutPercent = marginCloseoutPercent;
      MarginCloseoutPositionValue = marginCloseoutPositionValue;
      WithdrawalLimit = withdrawalLimit;
      MarginCallMarginUsed = marginCallMarginUsed;
      MarginCallPercent = marginCallPercent;
      Balance = balance;
      PL = pL;
      ResettablePL = resettablePL;
      Financing = financing;
      Commission = commission;
      DividendAdjustment = dividendAdjustment;
      GuaranteedExecutionFees = guaranteedExecutionFees;
      MarginCallEnterTime = marginCallEnterTime;
      MarginCallExtensionCount = marginCallExtensionCount;
      LastMarginCallExtensionTime = lastMarginCallExtensionTime;
      LastTransactionID = lastTransactionID;
    }

    /// <summary>
    /// The account’s identifier.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Client-assigned alias for the Account. Only provided if the account has
    /// an alias set.
    /// </summary>
    public string? Alias { get; }

    /// <summary>
    /// The home currency of the account.
    /// </summary>
    public string Currency { get; }

    /// <summary>
    /// ID of the user that created the account.
    /// </summary>
    public int CreatedByUserId { get; }

    /// <summary>
    /// The date/time when the account was created.
    /// </summary>
    public DateTime CreatedTime { get; }

    /// <summary>
    /// The current guaranteed Stop Loss Order settings of the account. This
    /// field will only be present if the guaranteedStopLossOrderMode is not
    /// ‘DISABLED’.
    /// </summary>
    public GuaranteedStopLossOrderParameters? GuaranteedStopLossOrderParameters { get; }

    /// <summary>
    /// The current guaranteed Stop Loss Order mode of the account.
    /// </summary>
    public GuaranteedStopLossOrderMode GuaranteedStopLossOrderMode { get; }

    /*
    /// <summary>
    /// The date/time that the account’s resettablePL was last reset.
    /// </summary>
    public DateTime ResettablePLTime { get; }
    */

    /// <summary>
    /// Client-provided margin rate override for the account. The effective
    /// margin rate of the account is the lesser of this value and the OANDA
    /// margin rate for the account’s division. This value is only provided if a
    /// margin rate override exists for the account.
    /// </summary>
    public decimal? MarginRate { get; }

    /// <summary>
    /// The number of trades currently open in the account.
    /// </summary>
    public int OpenTradeCount { get; }

    /// <summary>
    /// The number of positions currently open in the account.
    /// </summary>
    public int OpenPositionCount { get; }

    /// <summary>
    /// The number of orders currently pending in the account.
    /// </summary>
    public int PendingOrderCount { get; }

    /// <summary>
    /// Flag indicating that the account has hedging enabled.
    /// </summary>
    public bool HedgingEnabled { get; }

    /// <summary>
    /// The total unrealized profit/loss for all trades currently open in the
    /// account. Expressed in the account's home currency.
    /// </summary>
    public decimal UnrealizedPL { get; }

    /// <summary>
    /// The net asset value of the account. Equal to account balance +
    /// unrealizedPL.
    /// </summary>
    public decimal NAV { get; }

    /// <summary>
    /// Margin currently used for the account. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginUsed { get; }

    /// <summary>
    /// Margin available for the account. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginAvailable { get; }

    /// <summary>
    /// The value of the account’s open positions represented in the account’s
    /// home currency.
    /// </summary>
    public decimal PositionValue { get; }

    /// <summary>
    /// The account’s margin closeout unrealized PL. Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal MarginCloseoutUnrealizedPL { get; }

    /// <summary>
    /// The Account’s margin closeout NAV. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginCloseoutNAV { get; }

    /// <summary>
    /// The Account’s margin closeout margin used. Expressed in the account's
    /// home currency.
    /// </summary>
    public decimal MarginCloseoutMarginUsed { get; }

    /// <summary>
    /// The account’s margin closeout percentage. When this value is 1.0 or
    /// above the account is in a margin closeout situation.
    /// </summary>
    public decimal MarginCloseoutPercent { get; }

    /// <summary>
    /// The value of the account’s open positions as used for margin closeout
    /// calculations. Expressed in the account's home currency.
    /// </summary>
    public decimal MarginCloseoutPositionValue { get; }

    /// <summary>
    /// The current WithdrawalLimit for the account which will be zero or a
    /// positive value indicating how much can be withdrawn from the account.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal WithdrawalLimit { get; }

    /// <summary>
    /// The account’s margin call margin used. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginCallMarginUsed { get; }

    /// <summary>
    /// The account’s margin call percentage. When this value is 1.0 or above
    /// the account is in a margin call situation.
    /// </summary>
    public decimal MarginCallPercent { get; }

    /// <summary>
    /// The current balance of the account. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal Balance { get; }

    /// <summary>
    /// The total profit/loss realized over the lifetime of the account.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal PL { get; }

    /// <summary>
    /// The total realized profit/loss for the account since it was last reset
    /// by the client. Expressed in the account's home currency.
    /// </summary>
    public decimal ResettablePL { get; }

    /// <summary>
    /// The total amount of financing paid/collected over the lifetime of the
    /// account. Expressed in the account's home currency.
    /// </summary>
    public decimal Financing { get; }

    /// <summary>
    /// The total amount of commission paid over the lifetime of the account.
    /// Expressed in the account's home currency.
    /// </summary>
    public decimal Commission { get; }

    /// <summary>
    /// The total amount of dividend adjustment paid over the lifetime of the
    /// account. Expressed in the account’s home currency.
    /// </summary>
    public decimal DividendAdjustment { get; }

    /// <summary>
    /// The total amount of fees charged over the lifetime of the account for the
    /// execution of guaranteed Stop Loss Orders. Expressed in the account’s home currency.
    /// </summary>
    public decimal GuaranteedExecutionFees { get; }

    /// <summary>
    /// The date/time when the account entered a margin call state. Only
    /// provided if the account is in a margin call.
    /// </summary>
    public DateTime? MarginCallEnterTime { get; }

    /// <summary>
    /// The number of times that the account’s current margin call was extended.
    /// </summary>
    public int MarginCallExtensionCount { get; }

    /// <summary>
    /// The date/time of the account’s last margin call extension.
    /// </summary>
    public DateTime LastMarginCallExtensionTime { get; }

    /// <summary>
    /// The ID of the last Transaction created for the Account.
    /// </summary>
    [JsonConverter(typeof(Int32StringConverter))]
    public int LastTransactionID { get; }
  }
}
