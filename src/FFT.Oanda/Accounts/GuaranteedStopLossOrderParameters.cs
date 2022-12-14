// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

using System.Text.Json.Serialization;

/// <summary>
/// The mutability and hedging settings related to guaranteed Stop Loss
/// orders for an account.
/// </summary>
public sealed class GuaranteedStopLossOrderParameters
{
  /// <summary>
  /// Initializes a new instance of the <see
  /// cref="GuaranteedStopLossOrderParameters"/> class.
  /// </summary>
  [JsonConstructor]
  public GuaranteedStopLossOrderParameters(
    GuaranteedStopLossOrderMutability mutabilityMarketOpen,
    GuaranteedStopLossOrderMutability mutabilityMarketHalted)
  {
    MutabilityMarketOpen = mutabilityMarketOpen;
    MutabilityMarketHalted = mutabilityMarketHalted;
  }

  /// <summary>
  /// The current guaranteed Stop Loss Order mutability setting of the Account
  /// when market is open.
  /// </summary>
  public GuaranteedStopLossOrderMutability MutabilityMarketOpen { get; }

  /// <summary>
  /// The current guaranteed Stop Loss Order mutability setting of the Account
  /// when market is halted.
  /// </summary>
  public GuaranteedStopLossOrderMutability MutabilityMarketHalted { get; }
}
