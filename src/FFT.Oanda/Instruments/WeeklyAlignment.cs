// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The day of the week to use for candlestick granularities with weekly
/// alignment.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WeeklyAlignment
{
  /// <summary>
  /// Sunday.
  /// </summary>
  SUNDAY,

  /// <summary>
  /// Monday.
  /// </summary>
  MONDAY,

  /// <summary>
  /// Tuesday.
  /// </summary>
  TUESDAY,

  /// <summary>
  /// Wednesday.
  /// </summary>
  WEDNESDAY,

  /// <summary>
  /// Thursday.
  /// </summary>
  THURSDAY,

  /// <summary>
  /// Friday.
  /// </summary>
  FRIDAY,

  /// <summary>
  /// Saturday.
  /// </summary>
  SATURDAY,
}
