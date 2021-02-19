// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Collections.Immutable;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Threading.Tasks;
  using FFT.Oanda.Accounts;

  public sealed class API : IDisposable
  {
    private readonly AccountType _accountType;
    private readonly string _key;
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="API"/> class.
    /// </summary>
    public API(AccountType accountType, string key)
    {
      _accountType = accountType;
      _key = key;
      _client = new HttpClient();
      _client.BaseAddress = new Uri(_accountType == AccountType.Real ? "https://api-fxtrade.oanda.com/" : "https://api-fxpractice.oanda.com/");
      _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_key}");
      _client.DefaultRequestHeaders.Add("AcceptDatetimeFormat", "RFC3339");
    }

    /*
    /// <summary>
    /// Get a list of all accounts.
    /// </summary>
    public async Task<AccountList> GetAccounts()
    {
      // api redirects from "v3/accounts" to "v3/users/@/accounts"
      // https://stackoverflow.com/questions/28564961/authorization-header-is-lost-on-redirect#:~:text=The%20reason%20you%20are%20experiencing,One%20reason%20is%20security.&text=Your%20API%20is%20returning%20401,is%20missing%20(or%20incomplete).
      return (await _client.GetFromJsonAsync<AccountList>("v3/users/@/accounts"))!;
    }

    /// <summary>
    /// Get a summary for a single account. Does not provide full specification
    /// of pending Orders, open Trades and Positions.
    /// </summary>
    public async Task<AccountSummaryResponse> GetAccountSummary(string accountId)
    {
      return (await _client.GetFromJsonAsync<AccountSummaryResponse>($"v3/accounts/{accountId}/summary"))!;
    }

    /// <summary>
    /// Get the full details for a single account. Full pending order, open
    /// trade and open position representations are provided.
    /// </summary>
    public async Task<AccountResponse> GetAccount(string accountId)
    {
      return (await _client.GetFromJsonAsync<AccountResponse>($"v3/accounts/{accountId}"))!;
    }
    */

    /*

    /// <summary> /// Get dancing bears and most recently completed candles
    within an /Account // for specified combinations of instrument, granularity,
    and /price // component. // </summary> /// <param
    name="dateTimeFormat">Format of DateTime fields in the request /// and
    response.</param> /// <param name="candleSpecifications">List of candle
    specifications to /get // pricing for.</param> /// <param name="units">The
    number of units used to calculate the // /volume-weighted average bid and
    ask prices in the returned candles // /[default=1].</param> /// <param
    name="smooth">A flag that controls whether the candlestick is /// “smoothed”
    or not. A smoothed candlestick uses the previous candle’s /// close price as
    its open price, while an unsmoothed candlestick uses /the // first price
    from its time range as its open price // /[default=False].</param> ///
    <param name="dailyAlignment">The hour of the day (in the specified //
    /timezone) to use for granularities that have daily alignments //
    /[default=17, minimum=0, maximum=23].</param> /// <param
    name="alignmentTimezone">The timezone to use for the // /dailyAlignment
    parameter. Candlesticks with daily alignment will be // /aligned to the
    dailyAlignment hour within the alignmentTimezone. Note // /that the returned
    times will still be represented in UTC //
    /[default=America/New_York].</param> /// <param name="weeklyAlignment">The
    day of the week used for /granularities // that have weekly alignment
    [default=Friday].</param> public async Task<string>
    GetCandles(DateTimeFormat dateTimeFormat, List<CandleSpecification>
    candleSpecifications, decimal units = 1, bool smooth = false, int
    dailyAlignment = 17, string alignmentTimezone = "America/New_York",
    DayOfWeek weeklyAlignment = DayOfWeek.Friday)
    {
      var query = new Dictionary<string, string>
      {
        { "candleSpecifications", string.Join(",", candleSpecifications) },
        { "units", units.ToString(CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString(CultureInfo.InvariantCulture) },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
      };
      var uri =
      QueryHelpers.AddQueryString($"v3/accounts/{_accountId}/candles/latest",
      query);

      //await _client.GetFromJsonAsync<List<CandleStickData>>(uri)

      using var request = new HttpRequestMessage(HttpMethod.Get, uri);
      request.Headers.Add("AcceptDatetimeFormat", dateTimeFormat.ToString());
      using var response = await _client.SendAsync(request); if
      (!response.IsSuccessStatusCode)
      {
        var issue = await response.Content.ReadAsStringAsync(); return issue;
      }
      else
      {
        return await response.Content.ReadAsStringAsync();
      }
    }

    */

    /// <inheritdoc/>
    public void Dispose()
    {
      _client.Dispose();
    }
  }
}
