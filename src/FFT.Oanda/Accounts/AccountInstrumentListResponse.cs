// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;
using FFT.Oanda.Instruments;
using FFT.Oanda.JsonConverters;

/// <summary>
/// The list of tradeable instruments for the Account.
/// </summary>
public sealed record AccountInstrumentListResponse
{
  /// <summary>
  /// The requested list of instruments.
  /// </summary>
  public ImmutableList<Instrument> Instruments { get; init; }

  /// <summary>
  /// The Id of the most recent transaction generated for the account.
  /// </summary>
  [JsonConverter(typeof(Int32StringConverter))]
  public int LastTransactionId { get; init; }
}
