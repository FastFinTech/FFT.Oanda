// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Pricing
{
  using System;
  using System.Collections.Immutable;
  using System.Text.Json.Serialization;

  /// <summary>
  /// The specification of an Account-specific Price.
  /// </summary>
  public sealed class ClientPrice
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientPrice"/> class.
    /// </summary>
    [JsonConstructor]
    public ClientPrice(
      string type,
      string? instrument,
      DateTime timestamp,
      bool? tradeable,
      ImmutableList<PriceBucket> bids,
      ImmutableList<PriceBucket> asks,
      decimal closeoutBid,
      decimal closeoutAsk)
    {
      Type = type;
      Instrument = instrument;
      Timestamp = timestamp;
      Tradeable = tradeable;
      Bids = bids;
      Asks = asks;
      CloseoutBid = closeoutBid;
      CloseoutAsk = closeoutAsk;
    }

    /// <summary>
    /// The string “PRICE”. Used to identify the a Price object when found in a
    /// stream.
    /// </summary>
    public string Type { get; }

    /// <summary>
    /// The Price’s Instrument. Made nullable because it was found not to be included in some responses.
    /// </summary>
    public string? Instrument { get; }

    /// <summary>
    /// The date/time when the Price was created.
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Flag indicating if the Price is tradeable or not. Made nullable because it was found not to be included in some responses.
    /// </summary>
    public bool? Tradeable { get; }

    /// <summary>
    /// The list of prices and liquidity available on the Instrument’s bid side.
    /// It is possible for this list to be empty if there is no bid liquidity
    /// currently available for the Instrument in the Account.
    /// </summary>
    public ImmutableList<PriceBucket> Bids { get; }

    /// <summary>
    /// The list of prices and liquidity available on the Instrument’s ask side.
    /// It is possible for this list to be empty if there is no ask liquidity
    /// currently available for the Instrument in the Account.
    /// </summary>
    public ImmutableList<PriceBucket> Asks { get; }

    /// <summary>
    /// The closeout bid Price. This Price is used when a bid is required to
    /// closeout a Position (margin closeout or manual) yet there is no bid
    /// liquidity. The closeout bid is never used to open a new position.
    /// </summary>
    public decimal CloseoutBid { get; }

    /// <summary>
    /// The closeout ask Price. This Price is used when a ask is required to
    /// closeout a Position (margin closeout or manual) yet there is no ask
    /// liquidity. The closeout ask is never used to open a new position.
    /// </summary>
    public decimal CloseoutAsk { get; }
  }
}
