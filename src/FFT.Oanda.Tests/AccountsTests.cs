// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Text;
  using System.Threading.Tasks;
  using FFT.Oanda.Accounts;
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
  }
}
