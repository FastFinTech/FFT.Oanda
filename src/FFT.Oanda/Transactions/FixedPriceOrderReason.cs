// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// The reason that the Fixed Price Order was created.
  /// </summary>
  [JsonConverter(typeof(JsonStringEnumConverter))]
  public enum FixedPriceOrderReason
  {
    /// <summary>
    /// The Fixed Price Order was created as part of a platform account
    /// migration
    /// </summary>
    PLATFORM_ACCOUNT_MIGRATION,

    /// <summary>
    /// The Fixed Price Order was created to close a Trade as part of division
    /// account migration
    /// </summary>
    TRADE_CLOSE_DIVISION_ACCOUNT_MIGRATION,

    /// <summary>
    /// The Fixed Price Order was created to close a Trade administratively
    /// </summary>
    TRADE_CLOSE_ADMINISTRATIVE_ACTION,
  }
}
