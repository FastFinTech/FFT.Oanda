// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System.Text.Json.Serialization;

  /// <summary>
  /// Representation of how many units of an Instrument are available to be
  /// traded by an Order depending on its positionFill option.
  /// </summary>
  public sealed class UnitsAvailable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="UnitsAvailable"/> class.
    /// </summary>
    [JsonConstructor]
    public UnitsAvailable(
      UnitsAvailableDetails @default,
      UnitsAvailableDetails reduceFirst,
      UnitsAvailableDetails reduceOnly,
      UnitsAvailableDetails openOnly)
    {
      Default = @default;
      ReduceFirst = reduceFirst;
      ReduceOnly = reduceOnly;
      OpenOnly = openOnly;
    }

    /// <summary>
    /// The number of units that are available to be traded using an Order with
    /// a positionFill option of “DEFAULT”. For an Account with hedging enabled,
    /// this value will be the same as the “OPEN_ONLY” value. For an Account
    /// without hedging enabled, this value will be the same as the
    /// “REDUCE_FIRST” value.
    /// </summary>
    public UnitsAvailableDetails Default { get; }

    /// <summary>
    /// The number of units that may are available to be traded with an Order
    /// with a positionFill option of “REDUCE_FIRST”.
    /// </summary>
    public UnitsAvailableDetails ReduceFirst { get; }

    /// <summary>
    /// The number of units that may are available to be traded with an Order
    /// with a positionFill option of “REDUCE_ONLY”.
    /// </summary>
    public UnitsAvailableDetails ReduceOnly { get; }

    /// <summary>
    /// The number of units that may are available to be traded with an Order
    /// with a positionFill option of “OPEN_ONLY”.
    /// </summary>
    public UnitsAvailableDetails OpenOnly { get; }
  }
}
