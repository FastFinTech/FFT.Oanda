// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests;

using System;

internal static class Services
{
  static Services()
  {
    Client = new OandaApiClient(Accounts.AccountType.Practice, Environment.GetEnvironmentVariable("Oanda_ApiKey")!);
  }

  public static OandaApiClient Client { get; }
}
