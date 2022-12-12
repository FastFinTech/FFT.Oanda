// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Returned by the <see cref="OandaApiClient.GetPricingInformation(string, string[], DateTime?, bool, CancellationToken)"/> method.
  /// </summary>
  public sealed class PricingInformationResponse
  {
    /// <summary>
    /// Initializes a new instance of the <see
    /// cref="PricingInformationResponse"/> class.
    /// </summary>
    [JsonConstructor]
    public PricingInformationResponse(
      ImmutableList<ClientPrice> prices,
      ImmutableList<HomeConversions>? homeConversions,
      DateTime time)
    {
      Prices = prices;
      HomeConversions = homeConversions;
      Time = time;
    }

    /// <summary>
    /// The list of price objects requested.
    /// </summary>
    public ImmutableList<ClientPrice> Prices { get; }

    /// <summary>
    /// The list of home currency conversion factors requested. This field will
    /// only be present if includeHomeConversions was set to true in the
    /// request.
    /// </summary>
    public ImmutableList<HomeConversions>? HomeConversions { get; }

    /// <summary>
    /// The DateTime value to use for the “since” parameter in the next poll
    /// request.
    /// </summary>
    public DateTime Time { get; }
  }
}
