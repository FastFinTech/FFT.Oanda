// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// The financing mode of an Account.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AccountFinancingMode
{
  /// <summary>
  /// No financing is paid/charged for open Trades in the Account.
  /// </summary>
  NO_FINANCING,

  /// <summary>
  /// Second-by-second financing is paid/charged for open Trades in the
  /// Account, both daily and when the the Trade is closed.
  /// </summary>
  SECOND_BY_SECOND,

  /// <summary>
  /// A full day’s worth of financing is paid/charged for open Trades in the
  /// Account daily at 5pm New York time.
  /// </summary>
  DAILY,

  /// <summary>
  /// Not in the Oanda API documentation but in my transaction history
  /// </summary>
  DAILY_FINANCING, 
  DAILY_INSTRUMENT, 
  SECOND_BY_SECOND_COMPONENT, 

}
