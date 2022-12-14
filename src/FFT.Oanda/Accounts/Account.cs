// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

using System;
using System.Collections.Immutable;
using System.Text.Json.Serialization;
using FFT.Oanda.Orders;
using FFT.Oanda.Positions;
using FFT.Oanda.Trades;

/// <summary>
/// The full details of an account. This includes full open trade, open
/// position and pending order representation.
/// </summary>
public sealed class Account : AccountSummary
{
  /// <summary>
  /// Initializes a new instance of the <see cref="Account"/> class.
  /// </summary>
  [JsonConstructor]
  public Account(
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
    int lastTransactionID,
    ImmutableList<TradeSummary> trades,
    ImmutableList<Position> positions,
    ImmutableList<Order> orders)
      : base(
        id,
        alias,
        currency,
        createdByUserId,
        createdTime,
        guaranteedStopLossOrderParameters,
        guaranteedStopLossOrderMode,
        marginRate,
        openTradeCount,
        openPositionCount,
        pendingOrderCount,
        hedgingEnabled,
        unrealizedPL,
        nAV,
        marginUsed,
        marginAvailable,
        positionValue,
        marginCloseoutUnrealizedPL,
        marginCloseoutNAV,
        marginCloseoutMarginUsed,
        marginCloseoutPercent,
        marginCloseoutPositionValue,
        withdrawalLimit,
        marginCallMarginUsed,
        marginCallPercent,
        balance,
        pL,
        resettablePL,
        financing,
        commission,
        dividendAdjustment,
        guaranteedExecutionFees,
        marginCallEnterTime,
        marginCallExtensionCount,
        lastMarginCallExtensionTime,
        lastTransactionID)
  {
    Trades = trades;
    Positions = positions;
    Orders = orders;
  }

  /// <summary>
  /// The details of the trades currently open in the account.
  /// </summary>
  public ImmutableList<TradeSummary> Trades { get; }

  /// <summary>
  /// The details all account positions.
  /// </summary>
  public ImmutableList<Position> Positions { get; }

  /// <summary>
  /// The details of the orders currently pending in the account.
  /// </summary>
  public ImmutableList<Order> Orders { get; }
}
