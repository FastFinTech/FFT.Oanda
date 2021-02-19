// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Trades
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The dynamic (calculated) state of an open Trade.
  /// </summary>
  public sealed class CalculatedTradeState
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="CalculatedTradeState"/>
    /// class.
    /// </summary>
    [JsonConstructor]
    public CalculatedTradeState(int id, decimal unrealizedPL, decimal marginUsed)
    {
      Id = id;
      UnrealizedPL = unrealizedPL;
      MarginUsed = marginUsed;
    }

    /// <summary>
    /// The Trade’s ID.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// The Trade’s unrealized profit/loss. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal UnrealizedPL { get; }

    /// <summary>
    /// Margin currently used by the Trade. Expressed in the account's home
    /// currency.
    /// </summary>
    public decimal MarginUsed { get; }
  }
}
