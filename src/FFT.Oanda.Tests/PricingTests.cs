//// Copyright (c) True Goodwill. All rights reserved.
//// Licensed under the MIT license. See LICENSE file in the project root for full license information.

//namespace FFT.Oanda.Tests
//{
//  using System.Collections.Generic;
//  using System.Threading.Tasks;
//  using Microsoft.VisualStudio.TestTools.UnitTesting;

//  [TestClass]
//  public class PricingTests
//  {
//    [TestMethod]
//    public async Task Candles()
//    {
//      using var api = new API(AccountType.Practice, Configuration.Instance.OandaAccountId, Configuration.Instance.OandaApiKey);

//      var candles = await api.GetCandles(
//        DateTimeFormat.UNIX,
//#pragma warning disable SA1118 // Parameter should not span multiple lines
//        new()
//        {
//          new()
//          {
//            InstrumentName = InstrumentNames.EURUSD,
//            CandleStickGranularity = CandleStickGranularity.M10,
//            PricingComponent = PricingComponent.M | PricingComponent.B | PricingComponent.A,
//          },
//        });
//    }
//  }
//}
