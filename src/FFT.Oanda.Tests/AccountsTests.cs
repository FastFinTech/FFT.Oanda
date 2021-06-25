// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Net;
  using System.Text;
  using System.Threading;
  using System.Threading.Tasks;
  using FFT.Oanda.Accounts;
  using FFT.Oanda.Pricing;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class AccountsTests
  {
    [TestMethod]
    public async Task GetAccounts()
    {
      var client = Services.Client;
      var accountList = (await client.GetAccounts())!;
      var accountId = accountList.Accounts[0].Id;
      var accountSummary = (await client.GetAccountSummary(accountId))!;
      var accountFull = (await client.GetAccount(accountId))!;
      var instruments = (await client.GetAccountInstruments(accountId))!;
    }

    [TestMethod]
    public async Task GetPriceStream()
    {
      var client = Services.Client;
      var accountId = (await client.GetAccounts()).Accounts[0].Id;
      var instrumentNames = (await client.GetAccountInstruments(accountId)).Instruments.Select(i => i.Name).ToArray();

      var updateCount = 0L;
      await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () =>
      {
        using var cts = new CancellationTokenSource(10000);
        var inputStream = client.GetPricingStream(accountId, instrumentNames, true, false, cts.Token);
        await foreach (var update in inputStream)
        {
          if (update is ClientPrice price)
          {
            updateCount++;
          }
        }
      });
      Assert.IsTrue(updateCount > 10, $"Only '{updateCount}' updates were received.");
    }
  }
}
