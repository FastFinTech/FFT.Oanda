// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Net;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Runtime.Serialization;
  using System.Text.Json.Serialization;
  using System.Threading.Tasks;
  using FFT.Oanda.Accounts;
  using FFT.Oanda.Instruments;
  using FFT.Oanda.Orders;
  using FFT.Oanda.Orders.OrderRequests;
  using FFT.Oanda.Pricing;
  using FFT.Oanda.Trades;
  using FFT.Oanda.Transactions;
  using Microsoft.AspNetCore.WebUtilities;

  /// <summary>
  /// Provides a client for the oanda api v2.
  /// </summary>
  public sealed partial class OandaApiClient : IDisposable
  {
    private const string DateTimeFormatString = "YYYY-MM-DDTHH:mm:ss.fffffffffZ";

    private readonly AccountType _accountType;
    private readonly string _key;
    private readonly HttpClient _client;

    /// <summary>
    /// Initializes a new instance of the <see cref="OandaApiClient"/> class.
    /// </summary>
    public OandaApiClient(AccountType accountType, string key)
    {
      _accountType = accountType;
      _key = key;

      // Specifying the handler to satisfy the Oanda api requirements here:
      // https://developer.oanda.com/rest-live-v20/best-practices/ As discussed
      // here: https://github.com/dotnet/runtime/issues/24613
      _client = new HttpClient(new SocketsHttpHandler());
      _client.BaseAddress = new Uri(_accountType == AccountType.Real ? "https://api-fxtrade.oanda.com/" : "https://api-fxpractice.oanda.com/");
      _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_key}");
      _client.DefaultRequestHeaders.Add("AcceptDatetimeFormat", "RFC3339");
    }

    /// <inheritdoc/>
    public void Dispose()
    {
      _client.Dispose();
    }

    /// <summary>
    /// Checks for http response status codes that are documented here:
    /// https://developer.oanda.com/rest-live-v20/troubleshooting-errors/.
    /// Throws known exceptions with data.
    /// </summary>
    /// <exception cref="HttpRequestException">
    /// Thrown if the <paramref name="responseMessage"/> does not have a success
    /// status code, AND the status code is not included in the api documentation.
    /// </exception>
    private async Task CheckErrors(HttpResponseMessage responseMessage)
    {
      var hasKnownException = false;
      switch (responseMessage.StatusCode)
      {
        case HttpStatusCode.BadRequest: // 400
        case HttpStatusCode.Unauthorized: // 401
        case HttpStatusCode.Forbidden: // 403
        case HttpStatusCode.NotFound: // 404
        case HttpStatusCode.MethodNotAllowed: // 405
          hasKnownException = true;
          break;
      }

      if (hasKnownException)
      {
        // TODO: Since the documentation is a little incomplete at
        // https://developer.oanda.com/rest-live-v20/troubleshooting-errors/,
        // these situations need to be investigated so we can get the details
        // and create hard-typed exceptions that contain all the available
        // information.
        var content = await responseMessage.Content.ReadAsStringAsync();
        throw new Exception($"Request was rejected by the oanda api: {content}");
      }

      responseMessage.EnsureSuccessStatusCode();
    }
  }

  // Accounts endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Get a list of all accounts.
    /// </summary>
    public async Task<AccountListResponse> GetAccounts()
    {
      // api redirects from "v3/accounts" to "v3/users/@/accounts"
      // https://stackoverflow.com/questions/28564961/authorization-header-is-lost-on-redirect#:~:text=The%20reason%20you%20are%20experiencing,One%20reason%20is%20security.&text=Your%20API%20is%20returning%20401,is%20missing%20(or%20incomplete).

      using var request = new HttpRequestMessage(HttpMethod.Get, "v3/users/@/accounts");
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountListResponse>())!;
    }

    /// <summary>
    /// Get a summary for a single account. Does not provide full specification
    /// of pending Orders, open Trades and Positions.
    /// </summary>
    public async Task<AccountSummaryResponse> GetAccountSummary(string accountId)
    {
      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/summary");
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountSummaryResponse>())!;
    }

    /// <summary>
    /// Get the full details for a single account. Full pending order, open
    /// trade and open position representations are provided.
    /// </summary>
    public async Task<AccountResponse> GetAccount(string accountId)
    {
      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}");
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountResponse>())!;
    }

    /// <summary>
    /// Get the list of tradeable instruments for the given Account.The list of
    /// tradeable instruments is dependent on the regulatory division that the
    /// Account is located in, thus should be the same for all Accounts owned by
    /// a single user.
    /// </summary>
    /// <param name="accountId">
    /// The account specifier. [Required].
    /// </param>
    /// <param name="specificInstruments">
    /// Supply this value if you wish to get instrument details for just this
    /// specific set of instruments.
    /// </param>
    public async Task<AccountInstrumentListResponse> GetAccountInstruments(string accountId, string[]? specificInstruments = null)
    {
      var url = $"v3/accounts/{accountId}/instruments";
      if (specificInstruments is { Length: > 0 })
      {
        url += $"?instruments={string.Join(',', specificInstruments)}";
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountInstrumentListResponse>())!;
    }

    /// <summary>
    /// Poll an Account for its current state and changes since a specified
    /// TransactionID.
    /// </summary>
    /// <param name="accountId">
    /// The id of the account for which data is requested.
    /// </param>
    /// <param name="sinceTransactionId">
    /// If you supply this as null, the response will not include the "Changes"
    /// data but will include the price-dependent state.
    /// </param>
    public async Task<AccountChangesResponse> GetAccountChanges(string accountId, string? sinceTransactionId)
    {
      var url = $"v3/accounts/{accountId}/changes";
      if (!string.IsNullOrWhiteSpace(sinceTransactionId))
      {
        url += $"?sinceTransactionID={sinceTransactionId}";
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountChangesResponse>())!;
    }

    /// <summary>
    /// Set the client-configurable portions of an Account.
    /// </summary>
    /// <exception cref="AccountConfigurationRejectedException">
    /// Thrown when the configuration request is denied.
    /// </exception>
    public async Task<AccountConfigurationResponse> SetAccountConfiguration(string accountId, AccountConfiguration accountConfiguration)
    {
      var url = $"v3/accounts/{accountId}/configuration";
      using var message = new HttpRequestMessage(HttpMethod.Patch, url)
      {
        Content = JsonContent.Create(accountConfiguration),
      };

      using var response = await _client.SendAsync(message);

      // TODO: The api documentation says both these status codes return the
      // same response content. I doubt it very much, this needs to be followed
      // up and investigated.

      if (response.StatusCode == (HttpStatusCode)400 || response.StatusCode == (HttpStatusCode)403)
      {
        var failData = (await response.Content.ReadFromJsonAsync<AccountConfigurationRejectedException.AccountConfigurationRejection>())!;
        throw new AccountConfigurationRejectedException(failData);
      }

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<AccountConfigurationResponse>())!;
    }
  }

  // Instrument endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Fetch candlestick data for an instrument. This method overload uses the
    /// "count" parameter (instead of the "from" and "to" parameters) to
    /// determine the range of candles to return.
    /// </summary>
    /// <param name="candleSpecification">
    /// An instrument name, a granularity, and a price component to get
    /// candlestick data for.
    /// </param>
    /// <param name="count">
    /// The number of candlesticks to return in the response. [maximum=5000].
    /// </param>
    /// <param name="smooth">
    /// A flag that controls whether the candlestick is “smoothed” or not. A
    /// smoothed candlestick uses the previous candle’s close price as its open
    /// price, while an un-smoothed candlestick uses the first price from its
    /// time range as its open price.
    /// </param>
    /// <param name="includeFirst">
    /// A flag that controls whether the candlestick that is covered by the from
    /// time should be included in the results. This flag enables clients to use
    /// the timestamp of the last completed candlestick received to poll for
    /// future candlesticks but avoid receiving the previous candlestick
    /// repeatedly.
    /// </param>
    /// <param name="dailyAlignment">
    /// The hour of the day (in the specified timezone) to use for granularities
    /// that have daily alignments. [default=17, minimum=0, maximum=23].
    /// </param>
    /// <param name="alignmentTimezone">
    /// The timezone to use for the dailyAlignment parameter. Candlesticks with
    /// daily alignment will be aligned to the dailyAlignment hour within the
    /// alignmentTimezone. Note that the returned times will still be
    /// represented in UTC. [default=America/New_York].
    /// </param>
    /// <param name="weeklyAlignment">
    /// The day of the week used for granularities that have weekly alignment.
    /// [default=Friday].
    /// </param>
    public async Task<CandlestickResponse> GetCandlestickData(
      CandleSpecification candleSpecification,
      int count = 500,
      bool smooth = false,
      bool includeFirst = true,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY)
    {
      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      if (dailyAlignment < 0 || dailyAlignment > 23)
        throw new ArgumentException(nameof(dailyAlignment));

      if (string.IsNullOrWhiteSpace(alignmentTimezone))
        throw new ArgumentException(nameof(alignmentTimezone));

      var query = new Dictionary<string, string>
      {
        { "price", candleSpecification.PricingComponent.ToString() },
        { "granularity", candleSpecification.CandleStickGranularity.ToString() },
        { "count", count.ToString(CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString() },
        { "includeFirst", includeFirst.ToString() },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
      };
      var url = QueryHelpers.AddQueryString($"v3/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<CandlestickResponse>())!;
    }

    /// <summary>
    /// Fetch candlestick data for an instrument. This method overload uses the
    /// "count" parameter (instead of the "from" and "to" parameters) to
    /// determine the range of candles to return.
    /// </summary>
    /// <param name="candleSpecification">
    /// An instrument name, a granularity, and a price component to get
    /// candlestick data for.
    /// </param>
    /// <param name="from">
    /// The start of the time range to fetch candlesticks for.
    /// </param>
    /// <param name="to">
    /// The end of the time range to fetch candlesticks for.
    /// </param>
    /// <param name="smooth">
    /// A flag that controls whether the candlestick is “smoothed” or not. A
    /// smoothed candlestick uses the previous candle’s close price as its open
    /// price, while an un-smoothed candlestick uses the first price from its
    /// time range as its open price.
    /// </param>
    /// <param name="includeFirst">
    /// A flag that controls whether the candlestick that is covered by the from
    /// time should be included in the results. This flag enables clients to use
    /// the timestamp of the last completed candlestick received to poll for
    /// future candlesticks but avoid receiving the previous candlestick
    /// repeatedly.
    /// </param>
    /// <param name="dailyAlignment">
    /// The hour of the day (in the specified timezone) to use for granularities
    /// that have daily alignments. [default=17, minimum=0, maximum=23].
    /// </param>
    /// <param name="alignmentTimezone">
    /// The timezone to use for the dailyAlignment parameter. Candlesticks with
    /// daily alignment will be aligned to the dailyAlignment hour within the
    /// alignmentTimezone. Note that the returned times will still be
    /// represented in UTC. [default=America/New_York].
    /// </param>
    /// <param name="weeklyAlignment">
    /// The day of the week used for granularities that have weekly alignment.
    /// [default=Friday].
    /// </param>
    public async Task<CandlestickResponse> GetCandlestickData(
      CandleSpecification candleSpecification,
      DateTime from,
      DateTime to,
      bool smooth = false,
      bool includeFirst = true,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY)
    {
      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      if (dailyAlignment < 0 || dailyAlignment > 23)
        throw new ArgumentException(nameof(dailyAlignment));

      if (string.IsNullOrWhiteSpace(alignmentTimezone))
        throw new ArgumentException(nameof(alignmentTimezone));

      if (from.Kind != DateTimeKind.Utc)
        throw new ArgumentException("Kind must be set as utc.", nameof(from));

      if (to.Kind != DateTimeKind.Utc)
        throw new ArgumentException("Kind must be set as utc.", nameof(to));

      var query = new Dictionary<string, string>
      {
        { "price", candleSpecification.PricingComponent.ToString() },
        { "granularity", candleSpecification.CandleStickGranularity.ToString() },
        { "from", from.ToString(DateTimeFormatString, CultureInfo.InvariantCulture) },
        { "to", to.ToString(DateTimeFormatString, CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString() },
        { "includeFirst", includeFirst.ToString() },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
      };
      var url = QueryHelpers.AddQueryString($"v3/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<CandlestickResponse>())!;
    }

    /// <summary>
    /// Fetch an order book for an instrument.
    /// </summary>
    /// <param name="instrumentName">
    /// Name of the Instrument.
    /// </param>
    /// <param name="time">
    /// The time of the snapshot to fetch. If not specified, then the most
    /// recent snapshot is fetched.
    /// </param>
    public async Task<OrderBookResponse> GetOrderBook(string instrumentName, DateTime? time = null)
    {
      var url = $"v3/instruments/{instrumentName}/orderBook";
      if (time.HasValue)
      {
        url = QueryHelpers.AddQueryString(url, "time", time.Value.ToString(DateTimeFormatString, CultureInfo.InvariantCulture));
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<OrderBookResponse>())!;
    }

    /// <summary>
    /// Fetch a position book for an instrument.
    /// </summary>
    /// <param name="instrumentName">
    /// Name of the Instrument.
    /// </param>
    /// <param name="time">
    /// The time of the snapshot to fetch. If not specified, then the most
    /// recent snapshot is fetched.
    /// </param>
    public async Task<PositionBookResponse> GetPositionBook(string instrumentName, DateTime? time = null)
    {
      // TODO: The response header contains a link to the next/previous position
      // books. Perhaps consider adding these to the method's output?

      var url = $"v3/instruments/{instrumentName}/positionBook";
      if (time.HasValue)
      {
        url = QueryHelpers.AddQueryString(url, "time", time.Value.ToString(DateTimeFormatString, CultureInfo.InvariantCulture));
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<PositionBookResponse>())!;
    }
  }

  // Order endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Create an Order for an Account.
    /// </summary>
    /// <param name="accountId">Account Identifier [required].</param>
    /// <param name="orderRequest">Specification of the Order to create.</param>
    /// <exception cref="OrderRejectedException">Thrown when the order request was rejected.</exception>
    public async Task<CreateOrderResponse> CreateOrder(string accountId, OrderRequest orderRequest)
    {
      // TODO: A response to a successful request also contains a link to the
      // order that was generated. Include this in the returned data.

      using var request = new HttpRequestMessage(HttpMethod.Post, $"v3/accounts/{accountId}/orders")
      {
        Content = JsonContent.Create(orderRequest, orderRequest.GetType()),
      };

      using var response = await _client.SendAsync(request);

      if (response.StatusCode == (HttpStatusCode)400)
      {
        var data = (await response.Content.ReadFromJsonAsync<OrderRejectedException.ErrorData>())!;
        throw new OrderRejectedException(data);
      }
      else if (response.StatusCode == (HttpStatusCode)404)
      {
        var data = (await response.Content.ReadFromJsonAsync<OrderOrAccountNotFoundException.ErrorData>())!;
        throw new OrderOrAccountNotFoundException(data);
      }

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<CreateOrderResponse>())!;
    }

    /// <summary>
    /// Get a list of Orders for an Account.
    /// </summary>
    /// <param name="accountId">
    /// Account Identifier [required].
    /// </param>
    /// <param name="instrumentName">
    /// The instrument to filter the requested orders by.
    /// </param>
    /// <param name="state">
    /// The state to filter the requested Orders by [default=PENDING].
    /// </param>
    /// <param name="count">
    /// The maximum number of Orders to return [default=50, maximum=500].
    /// </param>
    /// <param name="beforeId">
    /// The maximum Order ID to return. If not provided the most recent Orders
    /// in the Account are returned.
    /// </param>
    /// <param name="ids">
    /// List of Order IDs to retrieve.
    /// </param>
    public async Task<GetOrdersResponse> GetOrders(string accountId, string? instrumentName = null, OrderStateFilter state = OrderStateFilter.PENDING, int count = 50, string? beforeId = null, string[]? ids = null)
    {
      if (count < 1 || count > 500)
        throw new ArgumentException(nameof(count));

      var query = new Dictionary<string, string>
      {
        { "count", count.ToString(CultureInfo.InvariantCulture) },
        { "state", state.ToString() },
      };

      if (!string.IsNullOrWhiteSpace(instrumentName))
        query.Add("instrument", instrumentName);

      if (!string.IsNullOrWhiteSpace(beforeId))
        query.Add("beforeID", beforeId);

      if (ids is { Length: > 0 })
        query.Add("ids", string.Join(",", ids));

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/orders", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<GetOrdersResponse>())!;
    }

    /// <summary>
    /// List all pending Orders in an Account.
    /// </summary>
    /// <param name="accountId">
    /// Account Identifier [required].
    /// </param>
    public async Task<GetOrdersResponse> GetPendingOrders(string accountId)
    {
      var url = $"v3/accounts/{accountId}/pendingOrders";
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<GetOrdersResponse>())!;
    }

    /// <summary>
    /// Get details for a single Order in an Account.
    /// </summary>
    /// <param name="accountId">Account Identifier [required].</param>
    /// <param name="orderId">The Order Specifier [required].</param>
    public async Task<GetSingleOrderResponse> GetSingleOrder(string accountId, string orderId)
    {
      var url = $"v3/accounts/{accountId}/orders/{orderId}";
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);
      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<GetSingleOrderResponse>())!;
    }

    /// <summary>
    /// Replace an Order in an Account by simultaneously cancelling it and
    /// creating a replacement Order.
    /// </summary>
    /// <param name="accountId">Account Identifier [required].</param>
    /// <param name="orderId">
    /// The id of the order to be replaced [required].
    /// </param>
    /// <param name="replacementOrder">
    /// Specification of the replacing Order.
    /// </param>
    /// <param name="clientRequestId">
    /// Client specified RequestID to be sent with request.
    /// </param>
    /// <exception cref="OrderRejectedException">
    /// Thrown when the order replacement request is rejected.
    /// </exception>
    /// <exception cref="OrderOrAccountNotFoundException">
    /// Thrown when the account or the order to be replaced does not exist.
    /// </exception>
    /// <exception cref="HttpRequestException">
    /// Thrown for other non-success response statuses.
    /// </exception>
    public async Task<ReplaceOrderResponse> ReplaceOrder(string accountId, string orderId, OrderRequest replacementOrder, string clientRequestId = null)
    {
      // TODO: Response header also contains a link to the new order. Add it to
      // the method's output.

      var url = $"v3/accounts/{accountId}/orders/{orderId}";
      using var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = JsonContent.Create(replacementOrder, replacementOrder.GetType()),
      };

      if (!string.IsNullOrWhiteSpace(clientRequestId))
        request.Headers.Add("ClientRequestID", clientRequestId);

      using var response = (await _client.SendAsync(request))!;

      if (response.StatusCode == (HttpStatusCode)400)
      {
        var orderRejection = (await response.Content.ReadFromJsonAsync<OrderRejectedException.ErrorData>())!;
        throw new OrderRejectedException(orderRejection);
      }
      else if (response.StatusCode == (HttpStatusCode)404)
      {
        var failData = (await response.Content.ReadFromJsonAsync<OrderOrAccountNotFoundException.ErrorData>())!;
        throw new OrderOrAccountNotFoundException(failData);
      }

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<ReplaceOrderResponse>())!;
    }

    /// <summary>
    /// Cancel a pending Order in an Account.
    /// </summary>
    /// <param name="accountId">Account Identifier [required].</param>
    /// <param name="orderId">The Order Specifier. Can be the order id or "@" + the order's client id. [required].</param>
    /// <param name="clientRequestId">Client specified RequestID to be sent with request.</param>
    public async Task<CancelOrderResponse> CancelOrder(string accountId, string orderId, string? clientRequestId = null)
    {
      var url = $"v3/accounts/{accountId}/orders/{orderId}/cancel";
      using var request = new HttpRequestMessage(HttpMethod.Put, url);

      if (!string.IsNullOrWhiteSpace(clientRequestId))
        request.Headers.Add("ClientRequestID", clientRequestId);

      using var response = await _client.SendAsync(request);

      if (response.StatusCode == (HttpStatusCode)404)
      {
        var errorData = (await response.Content.ReadFromJsonAsync<OrderOrAccountNotFoundException.ErrorData>())!;
        throw new OrderOrAccountNotFoundException(errorData);
      }

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<CancelOrderResponse>())!;
    }

    /// <summary>
    /// Update the Client Extensions for an Order in an Account.Do not set, modify, or delete clientExtensions if your account is associated with MT4.
    /// </summary>
    /// <param name="accountId"></param>
    /// <param name="orderSpecifier"></param>
    /// <param name="clientExtensions"></param>
    /// <param name="tradeClientExtensions"></param>
    /// <returns></returns>
    public async Task<UpdateOrderClientExtensionsResponse> SetOrderClientExtensions(string accountId, string orderSpecifier, ClientExtensions? clientExtensions, ClientExtensions? tradeClientExtensions)
    {
      var url = $"v3/accounts/{accountId}/orders/{orderSpecifier}/clientExtensions";
      using var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = JsonContent.Create(new
        {
          ClientExtensions = clientExtensions,
          TradeClientExtensions = tradeClientExtensions,
        }),
      };
      using var response = await _client.SendAsync(request);

      if (response.StatusCode == (HttpStatusCode)400)
      {
        var data = (await response.Content.ReadFromJsonAsync<OrderClientExtensionsSpecificationInvalidException.ErrorData>())!;
        throw new OrderClientExtensionsSpecificationInvalidException(data);
      }
      else if (response.StatusCode == (HttpStatusCode)404)
      {
        var data = (await response.Content.ReadFromJsonAsync<OrderOrAccountNotFoundException.ErrorData>())!;
        throw new OrderOrAccountNotFoundException(data);
      }

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<UpdateOrderClientExtensionsResponse>())!;
    }
  }

  // Trade endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Get a list of Trades for an Account.
    /// </summary>
    /// <param name="accountId">Account Identifier [required].</param>
    /// <param name="state">The state to filter the requested Trades by. [default=OPEN].</param>
    /// <param name="instrument">The instrument to filter the requested Trades by.</param>
    /// <param name="count">The maximum number of Trades to return. [default=50, maximum=500].</param>
    /// <param name="beforeId">The maximum Trade ID to return. If not provided the most recent Trades in the Account are returned.</param>
    /// <param name="tradeIds">List of Trade IDs to retrieve. Only supply this if you wish to specify exactly which trades you need the information for.</param>
    public async Task<GetTradesResponse> GetTrades(string accountId, TradeStateFilter state = TradeStateFilter.OPEN, string? instrument = null, int count = 50, string? beforeId = null, string[]? tradeIds = null)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(accountId);

      if (count < 1 || count > 500)
        throw new ArgumentException(nameof(count));

      var query = new Dictionary<string, string>
      {
        { "state", state.ToString() },
        { "count", count.ToString(CultureInfo.InvariantCulture) },
      };

      if (!string.IsNullOrWhiteSpace(beforeId))
        query.Add("beforeID", beforeId);

      if (tradeIds is { Length: > 0 })
        query.Add("ids", string.Join(',', tradeIds));

      if (!string.IsNullOrWhiteSpace(instrument))
        query.Add("instrument", instrument);

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/trades", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request);

      await CheckErrors(response);
      return (await response.Content.ReadFromJsonAsync<GetTradesResponse>())!;
    }

    /// <summary>
    /// Get the list of open Trades for an Account.
    /// </summary>
    /// <param name="accountId"></param>
    public async Task<GetTradesResponse> GetOpenTrades(string accountId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/openTrades");
      using var response = await _client.SendAsync(request);
    }
  }
}
