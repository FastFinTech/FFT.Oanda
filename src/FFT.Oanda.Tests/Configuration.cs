// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests
{
  using System;

  internal class Configuration
  {
    public static readonly Configuration Instance = new(
      oandaApiKey: Environment.GetEnvironmentVariable("Oanda_ApiKey")!);

    private Configuration(string oandaApiKey)
    {
      OandaApiKey = oandaApiKey;
    }

    public string OandaApiKey { get; }
  }
}
