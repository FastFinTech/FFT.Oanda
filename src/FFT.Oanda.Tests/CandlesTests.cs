// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1118 // Parameter should not span multiple lines

namespace FFT.Oanda.Tests;

using System;
using System.Linq;
using System.Threading.Tasks;
using FFT.Oanda.Instruments;
using FFT.Oanda.Pricing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CandlesTests
{
  private static string _accountId = null!;

  [ClassInitialize]
  public static async Task Initialize(TestContext context)
  {
    _accountId = (await Services.Client.GetAccounts()).Accounts.First().Id;
  }

  [TestMethod]
  public async Task TestCandles()
  {
    var client = Services.Client;
    var accountId = (await client.GetAccounts()).Accounts.First().Id;
    var data = await client.GetCandlestickData(
      accountId: accountId,
      candleSpecification: new()
      {
        InstrumentName = "AUD_USD",
        CandleStickGranularity = Instruments.CandlestickGranularity.S5,
        PricingComponent = new() { Mid = true },
      },
      from: DateTime.UtcNow.Date.AddDays(-30),
      to: null,
      cancellationToken: default);
  }

  [TestMethod]
  public async Task Latest5000Candles()
  {
    var data = await Services.Client.GetCandlestickData(
      accountId: _accountId,
      candleSpecification: new CandleSpecification() { InstrumentName = "AUD_USD", CandleStickGranularity = CandlestickGranularity.S5, PricingComponent = new() { Bid = true, Ask = true, Mid = true } },
      from: null,
      to: null,
      count: 5000,
      smooth: false,
      includeFirst: null);

    data.Candles.Count.Should().Be(5000);
    data.Candles[^1].Time.Should().BeAfter(DateTime.UtcNow.AddMinutes(-1));
  }

}
