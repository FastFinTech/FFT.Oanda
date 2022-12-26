// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#pragma warning disable SA1118 // Parameter should not span multiple lines

namespace FFT.Oanda.Tests;

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CandlesTests
{
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
}
