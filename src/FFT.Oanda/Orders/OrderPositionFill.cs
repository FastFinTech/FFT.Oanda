// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// Specification of how Positions in the Account are modified when the Order
/// is filled.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderPositionFill
{

  /// <summary>
  /// When the Order is filled, use REDUCE_FIRST behaviour for non-client
  /// hedging Accounts, and OPEN_ONLY behaviour for client hedging Accounts.
  /// </summary>
  DEFAULT,  // moved to first place so it will be used as initialization 

  /// <summary>
  /// When the Order is filled, only allow Positions to be opened or extended.
  /// </summary>
  OPEN_ONLY,

  /// <summary>
  /// When the Order is filled, always fully reduce an existing Position
  /// before opening a new Position.
  /// </summary>
  REDUCE_FIRST,

  /// <summary>
  /// When the Order is filled, only reduce an existing Position.
  /// </summary>
  REDUCE_ONLY,

}
