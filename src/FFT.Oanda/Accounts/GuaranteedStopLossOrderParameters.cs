// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
/// <summary>
/// The mutability and hedging settings related to guaranteed Stop Loss
/// orders for an account.
/// </summary>
public sealed record GuaranteedStopLossOrderParameters
{
  /// <summary>
  /// The current guaranteed Stop Loss Order mutability setting of the Account
  /// when market is open.
  /// </summary>
  public GuaranteedStopLossOrderMutability MutabilityMarketOpen { get; init; }

  /// <summary>
  /// The current guaranteed Stop Loss Order mutability setting of the Account
  /// when market is halted.
  /// </summary>
  public GuaranteedStopLossOrderMutability MutabilityMarketHalted { get; init; }
}
