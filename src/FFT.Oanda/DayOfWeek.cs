// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Text.Json.Serialization;

/// <summary>
/// The DayOfWeek provides a representation of the day of the week.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DayOfWeek
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
