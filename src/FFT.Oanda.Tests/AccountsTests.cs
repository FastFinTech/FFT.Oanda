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
      using var api = new API(AccountType.Practice, Configuration.Instance.OandaApiKey);

      var accountList = (await api.GetAccounts())!;

      var accountId = accountList.Accounts[0].Id;
      var accountSummary = (await api.GetAccountSummary(accountId))!;
      var accountFull = (await api.GetAccount(accountId))!;
    }

    [TestMethod]
    public void TableToEnum()
    {
      var typeName = "GuaranteedStopLossOrderModeForInstrument";
      var typeDescription = "The overall behaviour of the Account regarding Guaranteed Stop Loss Orders for a specific Instrument.";
      var enumData = @"DISABLED	The Account is not permitted to create Guaranteed Stop Loss Orders for this Instrument.
ALLOWED	The Account is able, but not required to have Guaranteed Stop Loss Orders for open Trades for this Instrument.
REQUIRED	The Account is required to have Guaranteed Stop Loss Orders for all open Trades for this Instrument.";

      var sb = new StringBuilder();
      sb.AppendLine("/// <summary>");
      sb.AppendLine($"/// {typeDescription}");
      sb.AppendLine("/// </summary>");
      sb.AppendLine(@"[JsonConverter(typeof(JsonStringEnumConverter))]");
      sb.AppendLine($@"public enum {typeName}");
      sb.Append('{');
      foreach (var line in enumData.Split('\n').Select(x => x.Trim()))
      {
        sb.AppendLine();
        var parts = line.Split('\t');
        sb.AppendLine("/// <summary>");
        sb.AppendLine($"/// {parts[1]}");
        sb.AppendLine("/// </summary>");
        sb.AppendLine($"{parts[0]},");
      }

      sb.AppendLine("}");

      var text = sb.ToString();
    }
  }
}
