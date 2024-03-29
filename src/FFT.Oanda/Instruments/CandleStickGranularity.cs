﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Instruments;

/// <summary>
/// The granularity of a candlestick.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CandlestickGranularity
{
  /// <summary>
  /// 5 second candlesticks, minute alignment.
  /// </summary>
  S5,

  /// <summary>
  /// 10 second candlesticks, minute alignment.
  /// </summary>
  S10,

  /// <summary>
  /// 15 second candlesticks, minute alignment.
  /// </summary>
  S15,

  /// <summary>
  /// 30 second candlesticks, minute alignment.
  /// </summary>
  S30,

  /// <summary>
  /// 1 minute candlesticks, minute alignment.
  /// </summary>
  M1,

  /// <summary>
  /// 2 minute candlesticks, hour alignment.
  /// </summary>
  M2,

  /// <summary>
  /// 4 minute candlesticks, hour alignment.
  /// </summary>
  M4,

  /// <summary>
  /// 5 minute candlesticks, hour alignment.
  /// </summary>
  M5,

  /// <summary>
  /// 10 minute candlesticks, hour alignment.
  /// </summary>
  M10,

  /// <summary>
  /// 15 minute candlesticks, hour alignment.
  /// </summary>
  M15,

  /// <summary>
  /// 30 minute candlesticks, hour alignment.
  /// </summary>
  M30,

  /// <summary>
  /// 1 hour candlesticks, hour alignment.
  /// </summary>
  H1,

  /// <summary>
  /// 2 hour candlesticks, day alignment.
  /// </summary>
  H2,

  /// <summary>
  /// 3 hour candlesticks, day alignment.
  /// </summary>
  H3,

  /// <summary>
  /// 4 hour candlesticks, day alignment.
  /// </summary>
  H4,

  /// <summary>
  /// 6 hour candlesticks, day alignment.
  /// </summary>
  H6,

  /// <summary>
  /// 8 hour candlesticks, day alignment.
  /// </summary>
  H8,

  /// <summary>
  /// 12 hour candlesticks, day alignment.
  /// </summary>
  H12,

  /// <summary>
  /// 1 day candlesticks, day alignment.
  /// </summary>
  D,

  /// <summary>
  /// 1 week candlesticks, aligned to start of week.
  /// </summary>
  W,

  /// <summary>
  /// 1 month candlesticks, aligned to first day of the month.
  /// </summary>
  M,
}
