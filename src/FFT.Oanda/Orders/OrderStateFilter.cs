// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Orders;

/// <summary>
/// The state to filter the requested Orders by.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum OrderStateFilter
{
  /// <summary>
  /// The Orders that are currently pending execution.
  /// </summary>
  PENDING,

  /// <summary>
  /// The Orders that have been filled.
  /// </summary>
  FILLED,

  /// <summary>
  /// The Orders that have been triggered.
  /// </summary>
  TRIGGERED,

  /// <summary>
  /// The Orders that have been cancelled.
  /// </summary>
  CANCELLED,

  /// <summary>
  /// The Orders that are in any of the possible states listed above.
  /// </summary>
  ALL,
}
