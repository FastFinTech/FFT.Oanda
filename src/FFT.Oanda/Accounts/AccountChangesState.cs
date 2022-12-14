// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.Positions;
using FFT.Oanda.Trades;

/// <summary>
/// An AccountState Object is used to represent an Account’s current
/// price-dependent state. Price-dependent Account state is dependent on
/// OANDA’s current Prices and includes things like unrealized PL NAV and
/// Trailing Stop Loss Order state. Fields will be omitted if their value has
/// not changed since the specified transaction ID.
/// </summary>
public sealed record AccountChangesState
{
  /// <summary>
  /// The total unrealized profit/loss for all Trades currently open in the
  /// Account. Expressed in the account's home currency.
  /// </summary>
  public decimal? UnrealizedPL { get; init; }

  /// <summary>
  /// The net asset value of the Account. Equal to Account balance +
  /// unrealizedPL. Expressed in the account's home currency.
  /// </summary>
  public decimal? NAV { get; init; }

  /// <summary>
  /// Margin currently used for the Account. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? MarginUsed { get; init; }

  /// <summary>
  /// Margin available for Account currency. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? MarginAvailable { get; init; }

  /// <summary>
  /// The value of the Account’s open positions. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? PositionValue { get; init; }

  /// <summary>
  /// The Account’s margin closeout unrealized PL. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? MarginCloseoutUnrealizedPL { get; init; }

  /// <summary>
  /// The Account’s margin closeout NAV. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? MarginCloseoutNAV { get; init; }

  /// <summary>
  /// The Account’s margin closeout margin used. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? MarginCloseoutMarginUsed { get; init; }

  /// <summary>
  /// The Account’s margin closeout percentage. When this value is 1.0 or
  /// above the Account is in a margin closeout situation.
  /// </summary>
  public decimal? MarginCloseoutPercent { get; init; }

  /// <summary>
  /// The value of the Account’s open positions as used for margin closeout
  /// calculations represented in the Account’s home currency.
  /// </summary>
  public decimal? MarginCloseoutPositionValue { get; init; }

  /// <summary>
  /// The current WithdrawalLimit for the account which will be zero or a
  /// positive value indicating how much can be withdrawn from the account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal? WithdrawalLimit { get; init; }

  /// <summary>
  /// The Account’s margin call margin used. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? MarginCallMarginUsed { get; init; }

  /// <summary>
  /// The Account’s margin call percentage. When this value is 1.0 or above
  /// the Account is in a margin call situation.
  /// </summary>
  public decimal? MarginCallPercent { get; init; }

  /// <summary>
  /// The current balance of the account. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? Balance { get; init; }

  /// <summary>
  /// The total profit/loss realized over the lifetime of the Account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal? PL { get; init; }

  /// <summary>
  /// The total realized profit/loss for the account since it was last reset
  /// by the client. Expressed in the account's home currency.
  /// </summary>
  public decimal? ResettablePL { get; init; }

  /// <summary>
  /// The total amount of financing paid/collected over the lifetime of the
  /// account. Expressed in the account's home currency.
  /// </summary>
  public decimal? Financing { get; init; }

  /// <summary>
  /// The total amount of commission paid over the lifetime of the Account.
  /// Expressed in the account's home currency.
  /// </summary>
  public decimal? Commission { get; init; }

  /// <summary>
  /// The total amount of dividend adjustment paid over the lifetime of the
  /// Account in the Account’s home currency. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal? DividendAdjustment { get; init; }

  /// <summary>
  /// The total amount of fees charged over the lifetime of the Account for
  /// the execution of guaranteed Stop Loss Orders. Expressed in the account's
  /// home currency.
  /// </summary>
  public decimal? GuaranteedExecutionFees { get; init; }

  /// <summary>
  /// The date/time when the Account entered a margin call state. Only
  /// provided if the Account is in a margin call.
  /// </summary>
  public DateTime? MarginCallEnterTime { get; init; }

  /// <summary>
  /// The number of times that the Account’s current margin call was extended.
  /// </summary>
  public int? MarginCallExtensionCount { get; init; }

  /// <summary>
  /// The date/time of the Account’s last margin call extension.
  /// </summary>
  public DateTime? LastMarginCallExtensionTime { get; init; }

  /// <summary>
  /// The price-dependent state of each pending Order in the Account.
  /// </summary>
  public ImmutableList<DynamicOrderState>? Orders { get; init; }

  /// <summary>
  /// The price-dependent state for each open Trade in the Account.
  /// </summary>
  public ImmutableList<CalculatedTradeState>? Trades { get; init; }

  /// <summary>
  /// The price-dependent state for each open Position in the Account.
  /// </summary>
  public ImmutableList<CalculatedPositionState>? Positions { get; init; }
}
