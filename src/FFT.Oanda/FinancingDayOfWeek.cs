// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A FinancingDayOfWeek message defines a day of the week when financing
  /// charges are debited or credited.
  /// </summary>
  public sealed class FinancingDayOfWeek
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="FinancingDayOfWeek"/> class.
    /// </summary>
    [JsonConstructor]
    public FinancingDayOfWeek(DayOfWeek dayOfWeek, int daysCharged)
    {
      DayOfWeek = dayOfWeek;
      DaysCharged = daysCharged;
    }

    /// <summary>
    /// The day of the week to charge the financing.
    /// </summary>
    public DayOfWeek DayOfWeek { get; }

    /// <summary>
    /// The number of days worth of financing to be charged on dayOfWeek.
    /// </summary>
    public int DaysCharged { get; }
  }
}
