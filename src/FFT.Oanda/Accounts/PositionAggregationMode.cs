// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Accounts;

/// <summary>
/// The way that position values for an Account are calculated and aggregated.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PositionAggregationMode
{
  /// <summary>
  /// The Position value or margin for each side (long and short) of the
  /// Position are computed independently and added together.
  /// </summary>
  ABSOLUTE_SUM,

  /// <summary>
  /// The Position value or margin for each side (long and short) of the
  /// Position are computed independently. The Position value or margin chosen
  /// is the maximal absolute value of the two.
  /// </summary>
  MAXIMAL_SIDE,

  /// <summary>
  /// The units for each side (long and short) of the Position are netted
  /// together and the resulting value (long or short) is used to compute the
  /// Position value or margin.
  /// </summary>
  NET_SUM,
}
