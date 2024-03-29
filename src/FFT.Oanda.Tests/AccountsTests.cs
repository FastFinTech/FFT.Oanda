// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FFT.Oanda.Accounts;
using FFT.Oanda.Orders.OrderRequests;
using FFT.Oanda.Orders;
using FFT.Oanda.Pricing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFT.IgnoreTasks;
using System.IO.Pipelines;
using System.Threading.Channels;
using FFT.Oanda.Transactions;

[TestClass]
public class AccountsTests
{
  public TestContext TestContext { get; set; }

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

  [TestMethod]
  public async Task PlaceMarketOrder()
  {
    var client = Services.Client;
    var accountIds = (await client.GetAccounts()).Accounts.Select(x => x.Id).ToList();
    var accountId = "";
    foreach (var id in accountIds)
    {
      var account = await client.GetAccount(id);
      if (account.Account.Alias.Contains("Gamble"))
      {
        accountId = account.Account.Id;
        break;
      }
    }

    using var cts = new CancellationTokenSource();
    var channel = Channel.CreateUnbounded<Transaction>();

    var transactionStream = client.GetTransactionsStream(accountId, cts.Token).GetAsyncEnumerator(cts.Token);
    var streamKickoffTask = transactionStream.MoveNextAsync();
    await Task.Delay(1000);

    var response = await client.CreateOrder(
      accountId,
      new MarketOrderRequest
      {
        Units = 1,
        Instrument = "AUD_USD",
        PositionFill = OrderPositionFill.OPEN_ONLY,
        TimeInForce = TimeInForce.FOK,
        StopLossOnFill = new() { Distance = 0.0100m, },
        TakeProfitOnFill = new() { Distance = 0.0100m, },
      },
      default);

    Assert.IsTrue(await streamKickoffTask);
    Assert.IsInstanceOfType<MarketOrderTransaction>(transactionStream.Current);

    Assert.IsTrue(await transactionStream.MoveNextAsync());
    Assert.IsInstanceOfType<OrderFillTransaction>(transactionStream.Current);

    Assert.IsTrue(await transactionStream.MoveNextAsync());
    Assert.IsInstanceOfType<TakeProfitOrderTransaction>(transactionStream.Current);

    Assert.IsTrue(await transactionStream.MoveNextAsync());
    Assert.IsInstanceOfType<StopLossOrderTransaction>(transactionStream.Current);

    cts.Cancel();

    await Assert.ThrowsExceptionAsync<TaskCanceledException>(async () => await transactionStream.MoveNextAsync());
  }
}
