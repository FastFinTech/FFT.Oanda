// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// A ConversionFactor contains information used to convert an amount, from an
  /// Instrument’s base or quote currency, to the home currency of an Account.
  /// </summary>
  public sealed class ConversionFactor
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ConversionFactor"/> class.
    /// </summary>
    [JsonConstructor]
    public ConversionFactor(decimal factor)
    {
      Factor = factor;
    }

    /// <summary>
    /// The factor by which to multiply the amount in the given currency to
    /// obtain the amount in the home currency of the Account.
    /// </summary>
    public decimal Factor { get; }
  }
}
