// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The dynamic (calculated) state of an open Trade.
/// </summary>
public sealed record CalculatedTradeState
{
  /// <summary>
  /// The Trade’s ID.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int Id { get; init; }

  /// <summary>
  /// The Trade’s unrealized profit/loss. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal UnrealizedPL { get; init; }

  /// <summary>
  /// Margin currently used by the Trade. Expressed in the account's home
  /// currency.
  /// </summary>
  public decimal MarginUsed { get; init; }
}
