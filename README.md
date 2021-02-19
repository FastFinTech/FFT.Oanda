# FFT.Oanda

[![Source code](https://img.shields.io/static/v1?style=flat&label=&message=Source%20Code&logo=read-the-docs&color=informational)](https://github.com/FastFinTech/FFT.Oanda)
[![NuGet package](https://img.shields.io/nuget/v/FFT.Oanda.svg)](https://nuget.org/packages/FFT.Oanda)

`FFT.Oanda` implements a .net client for the [Oanda api](https://developer.oanda.com/rest-live-v20/introduction/)

### Usage
```csharp
using System;
using FFT.Oanda;
using var client = new API("my api key");
var myAccounts = await client.GetAccounts();
```

For full specification of client abilities, see the reference documenation. TODO: Add link.