# FFT.Oanda

[![Source code](https://img.shields.io/static/v1?style=flat&label=&message=Source%20Code&logo=read-the-docs&color=informational)](https://github.com/FastFinTech/FFT.Oanda)
[![NuGet package](https://img.shields.io/nuget/v/FFT.Oanda.svg)](https://nuget.org/packages/FFT.Oanda)

`FFT.Oanda` is a .Net client for the [Oanda
api](https://developer.oanda.com/rest-live-v20/introduction/)

Use the latest version 2.x.x package to connect to the Oanda V2 api. When Oanda
releases new api versions, this package will adjust new major versions to match
the Oanda api version. For example, when Oanda releases their V3 version, you
can use the latest 3.x.x package to connect to it.

### Usage
The basic idea is to create a long-lived singleton instance of the api client
which you reuse throughout your application. It is threadsafe.

```csharp
using System;
using FFT.Oanda;
using FFT.Oanda.Accounts;
using var client = new OandaApiClient(AccountType.Real, "your_api_key");
var myAccounts = await client.GetAccounts();
```

For full specification of client abilities, see the reference documenation. TODO: Add link.