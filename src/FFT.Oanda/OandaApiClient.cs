// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Net.Http;
  using System.Net.Http.Json;
  using System.Runtime.CompilerServices;
  using System.Threading;
  using System.Threading.Tasks;
  using FFT.Disposables;
  using FFT.Oanda.Accounts;
  using FFT.Oanda.Instruments;
  using FFT.Oanda.Orders;
  using FFT.Oanda.Orders.OrderRequests;
  using FFT.Oanda.Positions;
  using FFT.Oanda.Pricing;
  using FFT.Oanda.Trades;
  using FFT.Oanda.Transactions;
  using Microsoft.AspNetCore.WebUtilities;

  /// <summary>
  /// Provides a client for the oanda api v2.
  /// </summary>
  public sealed partial class OandaApiClient : DisposeBase
  {
    private const string DATETIMEFORMATSTRING = "YYYY-MM-DDTHH:mm:ss.fffffffffZ";

    private readonly HttpClient _client;
    private readonly HttpClient _streamClient;

    /// <summary>
    /// Initializes a new instance of the <see cref="OandaApiClient"/> class.
    /// </summary>
    public OandaApiClient(AccountType accountType, string key)
    {
      AccountType = accountType;
      Key = key;

      // Specifying the handler to satisfy the Oanda api requirements here:
      // https://developer.oanda.com/rest-live-v20/best-practices/ As discussed
      // here: https://github.com/dotnet/runtime/issues/24613
      _client = new HttpClient(new SocketsHttpHandler());
      _client.BaseAddress = new Uri(AccountType == AccountType.Real ? "https://api-fxtrade.oanda.com/" : "https://api-fxpractice.oanda.com/");
      _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Key}");
      _client.DefaultRequestHeaders.Add("AcceptDatetimeFormat", "RFC3339");

      _streamClient = new HttpClient(new SocketsHttpHandler());
      _streamClient.BaseAddress = new Uri(AccountType == AccountType.Real ? "https://stream-fxtrade.oanda.com/" : "https://stream-fxpractice.oanda.com/");
      _streamClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Key}");
      _streamClient.DefaultRequestHeaders.Add("AcceptDatetimeFormat", "RFC3339");
    }

    /// <summary>
    /// The account type that this instance will connect to. Affects the
    /// endpoint used for http connections.
    /// </summary>
    public AccountType AccountType { get; }

    /// <summary>
    /// The authorization used to authenticate by this instance.
    /// </summary>
    public string Key { get; }

    /// <inheritdoc/>
    protected override void CustomDispose()
    {
      _client.Dispose();
      _streamClient.Dispose();
    }

    private static async Task<T> ParseResponse<T>(HttpResponseMessage response)
    {
      await RequestFailedException.ThrowIfNecessary(response);

      // This particular extension method automatically uses the "WebOptions"
      // options for json deserialization. If we ever switch away to manually
      // deserializing, we will need to remember to specify the "WebOptions" to
      // be used for deserialization. The "PolymorphicDeserializer" class has an
      // example of how to do that.
      return (await response.Content.ReadFromJsonAsync<T>())!;
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
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<AccountListResponse>(response);
    }

    /// <summary>
    /// Get a summary for a single account. Does not provide full specification
    /// of pending Orders, open Trades and Positions.
    /// </summary>
    public async Task<AccountSummaryResponse> GetAccountSummary(string accountId)
    {
      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/summary");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<AccountSummaryResponse>(response);
    }

    /// <summary>
    /// Get the full details for a single account. Full pending order, open
    /// trade and open position representations are provided.
    /// </summary>
    public async Task<AccountResponse> GetAccount(string accountId)
    {
      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<AccountResponse>(response);
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
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<AccountInstrumentListResponse>(response);
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
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<AccountChangesResponse>(response);
    }

    /// <summary>
    /// Set the client-configurable portions of an Account.
    /// </summary>
    public async Task<AccountConfigurationResponse> SetAccountConfiguration(string accountId, AccountConfiguration accountConfiguration)
    {
      var url = $"v3/accounts/{accountId}/configuration";
      using var message = new HttpRequestMessage(HttpMethod.Patch, url)
      {
        Content = JsonContent.Create(accountConfiguration),
      };

      using var response = await _client.SendAsync(message, DisposedToken);
      return await ParseResponse<AccountConfigurationResponse>(response);
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
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY)
    {
      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      candleSpecification.Validate();

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
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
      };
      var url = QueryHelpers.AddQueryString($"v3/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
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
    /// When null, to the present time. TODO: Check this actually works.
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
      DateTime? to,
      bool smooth = false,
      bool includeFirst = true,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY)
    {
      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      candleSpecification.Validate();

      if (dailyAlignment < 0 || dailyAlignment > 23)
        throw new ArgumentException(nameof(dailyAlignment));

      if (string.IsNullOrWhiteSpace(alignmentTimezone))
        throw new ArgumentException(nameof(alignmentTimezone));

      if (from.Kind != DateTimeKind.Utc)
        throw new ArgumentException("Kind must be set as utc.", nameof(from));

      if (to.HasValue)
      {
        if (to.Value.Kind != DateTimeKind.Utc)
          throw new ArgumentException("Kind must be set as utc.", nameof(to));
      }

      var query = new Dictionary<string, string>
      {
        { "price", candleSpecification.PricingComponent.ToString() },
        { "granularity", candleSpecification.CandleStickGranularity.ToString() },
        { "from", from.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString() },
        { "includeFirst", includeFirst.ToString() },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
      };

      // TODO: check that this works when to is null.

      if (to.HasValue)
        query["to"] = to.Value.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture);

      var url = QueryHelpers.AddQueryString($"v3/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
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
      if (string.IsNullOrWhiteSpace(instrumentName))
        throw new ArgumentException(nameof(instrumentName));

      var url = $"v3/instruments/{instrumentName}/orderBook";
      if (time.HasValue)
      {
        url = QueryHelpers.AddQueryString(url, "time", time.Value.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture));
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
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

      if (string.IsNullOrWhiteSpace(instrumentName))
        throw new ArgumentException(nameof(instrumentName));

      var url = $"v3/instruments/{instrumentName}/positionBook";
      if (time.HasValue)
      {
        url = QueryHelpers.AddQueryString(url, "time", time.Value.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture));
      }

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
      return (await response.Content.ReadFromJsonAsync<PositionBookResponse>())!;
    }
  }

  // Order endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Create an Order for an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="orderRequest">Specification of the Order to create.</param>
    public async Task<CreateOrderResponse> CreateOrder(string accountId, OrderRequest orderRequest)
    {
      // TODO: A response to a successful request also contains a link to the
      // order that was generated. Include this in the returned data.

      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Post, $"v3/accounts/{accountId}/orders")
      {
        Content = JsonContent.Create(orderRequest, orderRequest.GetType()),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<CreateOrderResponse>(response);
    }

    /// <summary>
    /// Get a list of Orders for an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
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
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

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
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetOrdersResponse>(response);
    }

    /// <summary>
    /// List all pending Orders in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    public async Task<GetOrdersResponse> GetPendingOrders(string accountId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      var url = $"v3/accounts/{accountId}/pendingOrders";
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetOrdersResponse>(response);
    }

    /// <summary>
    /// Get details for a single Order in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="orderSpecifier">
    /// The specification of an Order as referred to by clients. Either the
    /// Order’s OANDA-assigned OrderID or the Order’s client-provided ClientID
    /// prefixed by the “@” symbol.
    /// </param>
    public async Task<GetSingleOrderResponse> GetSingleOrder(string accountId, string orderSpecifier)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(orderSpecifier))
        throw new ArgumentException(nameof(orderSpecifier));

      var url = $"v3/accounts/{accountId}/orders/{orderSpecifier}";
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetSingleOrderResponse>(response);
    }

    /// <summary>
    /// Replace an Order in an Account by simultaneously cancelling it and
    /// creating a replacement Order.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="orderSpecifier">
    /// The order to be replaced.
    /// The specification of an Order as referred to by clients. Either the
    /// Order’s OANDA-assigned OrderID or the Order’s client-provided ClientID
    /// prefixed by the “@” symbol.
    /// </param>
    /// <param name="replacementOrder">
    /// Specification of the replacing Order.
    /// </param>
    /// <param name="clientRequestId">
    /// Client specified RequestID to be sent with request.
    /// </param>
    public async Task<ReplaceOrderResponse> ReplaceOrder(string accountId, string orderSpecifier, OrderRequest replacementOrder, string? clientRequestId = null)
    {
      // TODO: Response header also contains a link to the new order. Add it to
      // the method's output.

      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(orderSpecifier))
        throw new ArgumentException(nameof(orderSpecifier));

      var url = $"v3/accounts/{accountId}/orders/{orderSpecifier}";
      using var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = JsonContent.Create(replacementOrder, replacementOrder.GetType()),
      };

      if (!string.IsNullOrWhiteSpace(clientRequestId))
        request.Headers.Add("ClientRequestID", clientRequestId);

      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<ReplaceOrderResponse>(response);
    }

    /// <summary>
    /// Cancel a pending Order in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="orderSpecifier">
    /// The order to be canceled.
    /// The specification of an Order as referred to by clients. Either the
    /// Order’s OANDA-assigned OrderID or the Order’s client-provided ClientID
    /// prefixed by the “@” symbol.
    /// </param>
    /// <param name="clientRequestId">Client specified RequestID to be sent with request.</param>
    public async Task<CancelOrderResponse> CancelOrder(string accountId, string orderSpecifier, string? clientRequestId = null)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(orderSpecifier))
        throw new ArgumentException(nameof(orderSpecifier));

      var url = $"v3/accounts/{accountId}/orders/{orderSpecifier}/cancel";
      using var request = new HttpRequestMessage(HttpMethod.Put, url);

      if (!string.IsNullOrWhiteSpace(clientRequestId))
        request.Headers.Add("ClientRequestID", clientRequestId);

      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<CancelOrderResponse>(response);
    }

    /// <summary>
    /// Update the Client Extensions for an Order in an Account.Do not set,
    /// modify, or delete clientExtensions if your account is associated with
    /// MT4.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="orderSpecifier">
    /// The specification of an Order as referred to by clients. Either the
    /// Order’s OANDA-assigned OrderID or the Order’s client-provided ClientID
    /// prefixed by the “@” symbol.
    /// </param>
    /// <param name="clientExtensions">
    /// The Client Extensions to update for the Order. Do not set, modify, or
    /// delete clientExtensions if your account is associated with MT4.
    /// </param>
    /// <param name="tradeClientExtensions">
    /// The Client Extensions to update for the Trade created when the Order is
    /// filled. Do not set, modify, or delete clientExtensions if your account
    /// is associated with MT4.
    /// </param>
    public async Task<UpdateOrderClientExtensionsResponse> SetOrderClientExtensions(string accountId, string orderSpecifier, ClientExtensions? clientExtensions, ClientExtensions? tradeClientExtensions)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(orderSpecifier))
        throw new ArgumentException(nameof(orderSpecifier));

      var url = $"v3/accounts/{accountId}/orders/{orderSpecifier}/clientExtensions";
      using var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = JsonContent.Create(new
        {
          ClientExtensions = clientExtensions,
          TradeClientExtensions = tradeClientExtensions,
        }),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<UpdateOrderClientExtensionsResponse>(response);
    }
  }

  // Trade endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Get a list of Trades for an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="state">The state to filter the requested Trades by. [default=OPEN].</param>
    /// <param name="instrument">The instrument to filter the requested Trades by.</param>
    /// <param name="count">The maximum number of Trades to return. [default=50, maximum=500].</param>
    /// <param name="beforeId">The maximum Trade ID to return. If not provided the most recent Trades in the Account are returned.</param>
    /// <param name="tradeIds">List of Trade IDs to retrieve. Only supply this if you wish to specify exactly which trades you need the information for.</param>
    public async Task<GetTradesResponse> GetTrades(string accountId, TradeStateFilter state = TradeStateFilter.OPEN, string? instrument = null, int count = 50, string? beforeId = null, string[]? tradeIds = null)
    {
      // TODO: Check if state is actually a csv list.

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
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTradesResponse>(response);
    }

    /// <summary>
    /// Get the list of open Trades for an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    public async Task<GetTradesResponse> GetOpenTrades(string accountId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/openTrades");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTradesResponse>(response);
    }

    /// <summary>
    /// Get the details of a specific Trade in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="tradeSpecifier">
    /// Either the Trade’s OANDA-assigned TradeID or the Trade’s client-provided
    /// ClientID prefixed by the “@” symbol.
    /// </param>
    public async Task<GetTradeResponse> GetTrade(string accountId, string tradeSpecifier)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(tradeSpecifier))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/trades/{tradeSpecifier}");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTradeResponse>(response);
    }

    /// <summary>
    /// Close (partially or fully) a specific open Trade in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="tradeSpecifier">
    /// Either the Trade’s OANDA-assigned TradeID or the Trade’s client-provided
    /// ClientID prefixed by the “@” symbol.
    /// </param>
    /// <param name="numUnits">
    /// Indication of how much of the Trade to close. Either the string “ALL”
    /// (indicating that all of the Trade should be closed), or a DecimalNumber
    /// representing the number of units of the open Trade to Close using a
    /// TradeClose MarketOrder. The units specified must always be positive, and
    /// the magnitude of the value cannot exceed the magnitude of the Trade’s
    /// open units.
    /// </param>
    public async Task<CloseTradeResponse> CloseTrade(string accountId, string tradeSpecifier, NumUnits numUnits)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(tradeSpecifier))
        throw new ArgumentException(nameof(accountId));

      var url = $"v3/accounts/{accountId}/trades/{tradeSpecifier}/close";
      using var request = new HttpRequestMessage(HttpMethod.Put, url)
      {
        Content = JsonContent.Create(new
        {
          Units = numUnits,
        }),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<CloseTradeResponse>(response);
    }

    /// <summary>
    /// Update the Client Extensions for a Trade. Do not add, update, or delete the Client Extensions if your account is associated with MT4.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="tradeSpecifier">
    /// Either the Trade’s OANDA-assigned TradeID or the Trade’s client-provided
    /// ClientID prefixed by the “@” symbol.
    /// </param>
    /// <param name="clientExtensions">
    /// The value to be attached to the given trade.
    /// </param>
    public async Task<TradeClientExtensionsUpdateResponse> SetTradeClientExtensions(string accountId, string tradeSpecifier, ClientExtensions clientExtensions)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(tradeSpecifier))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Put, $"v3/accounts/{accountId}/trades/{tradeSpecifier}/clientExtensions")
      {
        Content = JsonContent.Create(new
        {
          ClientExtensions = clientExtensions,
        }),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<TradeClientExtensionsUpdateResponse>(response);
    }

    /// <summary>
    /// Create, replace and cancel a Trade’s dependent Orders (Take Profit, Stop
    /// Loss and Trailing Stop Loss) through the Trade itself.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="tradeSpecifier">
    /// Either the Trade’s OANDA-assigned TradeID or the Trade’s client-provided
    /// ClientID prefixed by the “@” symbol.
    /// </param>
    /// <param name="takeProfit">
    /// /// The specification of the Take Profit to create/modify/cancel. If
    /// takeProfit is set to null, the Take Profit Order will be cancelled if it
    /// exists. If takeProfit is not provided, the existing Take Profit Order
    /// will not be modified. If a sub-field of takeProfit is not specified, that
    /// field will be set to a default value on create, and be inherited by the
    /// replacing order on modify.
    /// </param>
    /// <param name="stopLoss">
    /// The specification of the Stop Loss to create/modify/cancel. If stopLoss
    /// is set to null, the Stop Loss Order will be cancelled if it exists. If
    /// stopLoss is not provided, the existing Stop Loss Order will not be
    /// modified. If a sub-field of stopLoss is not specified, that field will be
    /// set to a default value on create, and be inherited by the replacing order
    /// on modify.
    /// </param>
    /// <param name="trailingStopLoss">
    /// The specification of the Trailing Stop Loss to create/modify/cancel. If
    /// trailingStopLoss is set to null, the Trailing Stop Loss Order will be
    /// cancelled if it exists. If trailingStopLoss is not provided, the existing
    /// Trailing Stop Loss Order will not be modified. If a sub-field of
    /// trailingStopLoss is not specified, that field will be set to a default
    /// value on create, and be inherited by the replacing order on modify.
    /// </param>
    /// <param name="guaranteedStopLoss">
    /// The specification of the Guaranteed Stop Loss to create/modify/cancel. If
    /// guaranteedStopLoss is set to null, the Guaranteed Stop Loss Order will be
    /// cancelled if it exists. If guaranteedStopLoss is not provided, the
    /// existing Guaranteed Stop Loss Order will not be modified. If a sub-field
    /// of guaranteedStopLoss is not specified, that field will be set to a
    /// default value on create, and be inherited by the replacing order on
    /// modify.
    /// </param>
    public async Task<SetTradeOrdersResponse> SetTradeOrders(string accountId, string tradeSpecifier, TakeProfitDetails? takeProfit, StopLossDetails? stopLoss, TrailingStopLossDetails? trailingStopLoss, GuaranteedStopLossDetails? guaranteedStopLoss)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(tradeSpecifier))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Put, $"v3/accounts/{accountId}/trades/{tradeSpecifier}/orders")
      {
        Content = JsonContent.Create(new
        {
          TakeProfit = takeProfit,
          StopLoss = stopLoss,
          TrailingStopLoss = trailingStopLoss,
          GuaranteedStopLoss = guaranteedStopLoss,
        }),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<SetTradeOrdersResponse>(response);
    }
  }

  // Position endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// List all Positions for an Account. The Positions returned are for every
    /// instrument that has had a position during the lifetime of an the
    /// Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    public async Task<GetPositionsResponse> GetPositions(string accountId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/positions");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetPositionsResponse>(response);
    }

    /// <summary>
    /// List all open Positions for an Account. An open Position is a Position
    /// that currently has a Trade opened for it.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    public async Task<GetPositionsResponse> GetOpenPositions(string accountId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/openPositions");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetPositionsResponse>(response);
    }

    /// <summary>
    /// Get the details of a single Instrument’s Position in an Account. The
    /// Position may by open or not.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="instrument">Name of the Instrument.</param>
    public async Task<GetPositionResponse> GetPosition(string accountId, string instrument)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(instrument))
        throw new ArgumentException(nameof(instrument));

      using var request = new HttpRequestMessage(HttpMethod.Get, $"v3/accounts/{accountId}/positions/{instrument}");
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetPositionResponse>(response);
    }

    /// <summary>
    /// Closeout the open Position for a specific instrument in an Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="instrument">Name of the Instrument.</param>
    /// <param name="longUnits">
    /// Indication of how much of the long Position to closeout using a
    /// PositionCloseout MarketOrder. The units specified must always be
    /// positive.
    /// </param>
    /// <param name="shortUnits">
    /// Indication of how much of the short Position to closeout using a
    /// PositionCloseout MarketOrder. The units specified must always be
    /// positive.
    /// </param>
    /// <param name="longClientExtensions">
    /// The client extensions to add to the MarketOrder used to close the long
    /// position.
    /// </param>
    /// <param name="shortClientExtensions">
    /// The client extensions to add to the MarketOrder used to close the short
    /// position.
    /// </param>
    public async Task<ClosePositionResponse> ClosePosition(string accountId, string instrument, NumUnits longUnits, NumUnits shortUnits, ClientExtensions? longClientExtensions, ClientExtensions? shortClientExtensions)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(instrument))
        throw new ArgumentException(nameof(instrument));

      using var request = new HttpRequestMessage(HttpMethod.Put, $"v3/accounts/{accountId}/positions/{instrument}/close")
      {
        Content = JsonContent.Create(new
        {
          longUnits,
          longClientExtensions,
          shortUnits,
          shortClientExtensions,
        }),
      };
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<ClosePositionResponse>(response);
    }
  }

  // Transaction endpoint
  public partial class OandaApiClient
  {
    /// <summary>
    /// Get a list of Transactions pages that satisfy a time-based Transaction
    /// query.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="from">
    /// The starting time (inclusive) of the time range for the Transactions
    /// being queried. If null, the account creation time will be used.
    /// </param>
    /// <param name="to">
    /// The ending time (inclusive) of the time range for the Transactions being
    /// queried. If null, the current time will be used.
    /// </param>
    public async Task<GetTransactionIdRangeResponse> GetTransactionIdRange(string accountId, DateTime? from = null, DateTime? to = null)
    {
      // TODO: Test what happens when input is a range with no transactions.

      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      var query = new Dictionary<string, string>
      {
        { "pageSize", "1000" }, // maximum allowed by the api
      };

      if (from.HasValue) // otherwise fall back to api defaults
        query.Add("from", from.Value.ToString(DATETIMEFORMATSTRING));

      if (to.HasValue) // otherwise fall back to api defaults
        query.Add("to", to.Value.ToString(DATETIMEFORMATSTRING));

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/transactions", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
      return (await response.Content.ReadFromJsonAsync<GetTransactionIdRangeResponse>())!;
    }

    /// <summary>
    /// Get the details of a single Account Transaction.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="transactionId">A Transaction ID.</param>
    public async Task<GetTransactionResponse> GetTransaction(string accountId, string transactionId)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (string.IsNullOrWhiteSpace(transactionId))
        throw new ArgumentException(nameof(transactionId));

      var url = $"v3/accounts/{accountId}/transactions/{transactionId}";
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTransactionResponse>(response);
    }

    /// <summary>
    /// Get a range of Transactions for an Account based on the Transaction IDs.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="fromTransactionId">The starting Transaction ID (inclusive)
    /// to fetch.</param>
    /// <param name="toTransactionId">The ending Transaction ID (inclusive) to
    /// fetch.</param>
    /// <param name="types">The filter that restricts the types of Transactions
    /// to retrieve. Null for all transaction types.</param>
    public async Task<GetTransactionsResponse> GetTransactions(string accountId, int fromTransactionId, int toTransactionId, TransactionFilter[]? types = null)
    {
      // TODO: Experiment to see if null filter works.

      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (fromTransactionId < 0)
        throw new ArgumentException($"Must be greater than or equal to zero.", nameof(fromTransactionId));

      if (toTransactionId < 0)
        throw new ArgumentException($"Must be greater than or equal to zero.", nameof(toTransactionId));

      if (toTransactionId < fromTransactionId)
        throw new ArgumentException($"'{nameof(toTransactionId)}' must be greater than or equal to '{nameof(fromTransactionId)}'.", nameof(toTransactionId));

      if (toTransactionId - fromTransactionId >= 1000)
        throw new ArgumentException($"Max number of transactions is 1000.", nameof(toTransactionId));

      var query = new Dictionary<string, string>
      {
        { "from", fromTransactionId.ToString(CultureInfo.InvariantCulture) },
        { "to", toTransactionId.ToString(CultureInfo.InvariantCulture) },
      };

      if (types is { Length: > 0 })
        query.Add("type", string.Join(",", types));

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/transactions/idrange", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTransactionsResponse>(response);
    }

    /// <summary>
    /// Get a range of Transactions for an Account starting at (but not
    /// including) a provided Transaction ID.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="fromTransactionId">The ID of the last Transaction fetched.
    /// This query will return all Transactions newer than the
    /// TransactionID.</param>
    /// <param name="types">A filter for restricting the types of Transactions
    /// to retrieve. Null to retrieve all Transaction types.</param>
    public async Task<GetTransactionsResponse> GetTransactionsSince(string accountId, int fromTransactionId, TransactionFilter[]? types = null)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      var url = $"v3/accounts/{accountId}/transactions/sinceid?id={fromTransactionId}";
      if (types is { Length: > 0 })
        url = QueryHelpers.AddQueryString(url, "type", string.Join(",", types));

      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<GetTransactionsResponse>(response);
    }

    /// <summary>
    /// Get a stream of Transactions and TransactionHeartbeats for an Account
    /// starting from when the request is made. Values returned are either
    /// inheriting <see cref="Transaction"/> or are of type <see
    /// cref="TransactionHeartbeat"/>.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="cancellationToken">Cancels the enumeration and closes the
    /// stream connection.</param>
    public async IAsyncEnumerable<object> GetTransactionsStream(string accountId, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      using var cts = CancellationTokenSource.CreateLinkedTokenSource(DisposedToken, cancellationToken);
      var url = $"v3/accounts/{accountId}/transactions/stream";
      using var stream = await _streamClient.GetStreamAsync(url, cts.Token);
      await foreach (var slice in stream.ReadLines(cts.Token))
      {
        yield return PolymorphicDeserializer.DeserializeTransactionStreamObject(slice);
      }
    }
  }

  // Pricing endpoing
  public partial class OandaApiClient
  {
    /// <summary>
    /// Get dancing bears and most recently completed candles within an Account
    /// for specified combinations of instrument, granularity, and price
    /// component.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="candleSpecifications">List of candle specifications to get
    /// pricing for.</param>
    /// <param name="units">The number of units used to calculate the
    /// volume-weighted average bid and ask prices in the returned
    /// candles.</param>
    /// <param name="smooth">A flag that controls whether the candlestick is
    /// “smoothed” or not. A smoothed candlestick uses the previous candle’s
    /// close price as its open price, while an unsmoothed candlestick uses the
    /// first price from its time range as its open price.</param>
    /// <param name="dailyAlignment">
    /// The hour of the day (in the specified timezone) to use for granularities
    /// that have daily alignments. [default=17, minimum=0, maximum=23].
    /// </param>
    /// <param name="alignmentTimezone">The timezone to use for the
    /// dailyAlignment parameter. Candlesticks with daily alignment will be
    /// aligned to the dailyAlignment hour within the alignmentTimezone. Note
    /// that the returned times will still be represented in UTC.</param>
    /// <param name="weeklyAlignment">The day of the week used for granularities
    /// that have weekly alignment.</param>
    public async Task<LatestCandlesResponse> GetLatestCandles(
      string accountId,
      CandleSpecification[] candleSpecifications,
      decimal units = 1,
      bool smooth = false,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (candleSpecifications is not { Length: > 0 })
        throw new ArgumentNullException(nameof(candleSpecifications));

      foreach (var specification in candleSpecifications)
      {
        if (specification is null)
          throw new ArgumentException(nameof(candleSpecifications));
        specification.Validate();
      }

      if (dailyAlignment < 0 || dailyAlignment > 23)
        throw new ArgumentException(nameof(dailyAlignment));

      if (string.IsNullOrWhiteSpace(alignmentTimezone))
        throw new ArgumentException(nameof(alignmentTimezone));

      var query = new Dictionary<string, string>
      {
        { "units", units.ToString(CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString() },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
        { "candleSpecifications", string.Join<CandleSpecification>(',', candleSpecifications) },
      };

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/candles/latest", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<LatestCandlesResponse>(response);
    }

    /// <summary>
    /// Get pricing information for a specified list of Instruments within an
    /// Account.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="instruments">List of Instruments to get pricing for.
    /// </param>
    /// <param name="since">
    /// Date/Time filter to apply to the response. Only prices and home
    /// conversions (if requested) with a time later than this filter (i.e. the
    /// price has changed after the since time) will be provided, and are
    /// filtered independently.
    /// </param>
    /// <param name="includeHomeConversions">
    /// Flag that enables the inclusion of the homeConversions field in the
    /// returned response. An entry will be returned for each currency in the
    /// set of all base and quote currencies present in the requested
    /// instruments list.
    /// </param>
    public async Task<PricingInformationResponse> GetPricingInformation(string accountId, string[] instruments, DateTime? since = null, bool includeHomeConversions = false)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (instruments is not { Length: > 0 })
        throw new ArgumentNullException(nameof(instruments));

      foreach (var instrument in instruments)
      {
        if (string.IsNullOrWhiteSpace(instrument))
          throw new ArgumentException(nameof(instruments));
      }

      var query = new Dictionary<string, string>
      {
        { "instruments", string.Join(',', instruments) },
        { "includeHomeConversions", includeHomeConversions.ToString() },
      };

      if (since.HasValue)
        query["since"] = since.Value.ToString(DATETIMEFORMATSTRING);

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/pricing", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      return await ParseResponse<PricingInformationResponse>(response);
    }

    /// <summary>
    /// Get a stream of Account Prices starting from when the request is made.
    /// This pricing stream does not include every single price created for the
    /// Account, but instead will provide at most 4 prices per second (every 250
    /// milliseconds) for each instrument being requested. If more than one
    /// price is created for an instrument during the 250 millisecond window,
    /// only the price in effect at the end of the window is sent. This means
    /// that during periods of rapid price movement, subscribers to this stream
    /// will not be sent every price. Pricing windows for different connections
    /// to the price stream are not all aligned in the same way (i.e. they are
    /// not all aligned to the top of the second). This means that during
    /// periods of rapid price movement, different subscribers may observe
    /// different prices depending on their alignment.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="instruments">
    /// List of Instruments to stream Prices for.
    /// </param>
    /// <param name="snapshot">
    /// Flag that enables/disables the sending of a pricing snapshot when
    /// initially connecting to the stream.
    /// </param>
    /// <param name="includeHomeConversions">
    /// Flag that enables the inclusion of the homeConversions field in the
    /// returned response. An entry will be returned for each currency in the
    /// set of all base and quote currencies present in the requested
    /// instruments list.
    /// </param>
    /// <param name="cancellationToken">
    /// Close the stream and break the enumeration.</param>
    public async IAsyncEnumerable<object> GetPricingStream(string accountId, string[] instruments, bool snapshot = true, bool includeHomeConversions = false, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
      using var cts = CancellationTokenSource.CreateLinkedTokenSource(DisposedToken, cancellationToken);
      var query = new Dictionary<string, string>
      {
        { "instruments", string.Join(',', instruments) },
        { "snapshot", snapshot.ToString() },
        { "includeHomeConversions", includeHomeConversions.ToString() },
      };
      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/pricing/stream", query);
      using var stream = await _streamClient.GetStreamAsync(url, cts.Token);
      await foreach (var slice in stream.ReadLines(cts.Token))
      {
        yield return PolymorphicDeserializer.DeserializePriceStreamObject(slice);
      }
    }

    /// <summary>
    /// Fetch candlestick data for an instrument. This method overload uses the
    /// "count" parameter (instead of the "from" and "to" parameters) to
    /// determine the range of candles to return.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
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
    /// <param name="units">
    /// The number of units used to calculate the volume-weighted average bid
    /// and ask prices in the returned candles.
    /// </param>
    public async Task<CandlestickResponse> GetCandlestickData(
      string accountId,
      CandleSpecification candleSpecification,
      int count = 500,
      bool smooth = false,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY,
      int units = 1)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      candleSpecification.Validate();

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
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
        { "units", units.ToString(CultureInfo.InvariantCulture) },
      };
      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
      return (await response.Content.ReadFromJsonAsync<CandlestickResponse>())!;
    }

    /// <summary>
    /// Fetch candlestick data for an instrument. This method overload uses the
    /// "count" parameter (instead of the "from" and "to" parameters) to
    /// determine the range of candles to return.
    /// </summary>
    /// <param name="accountId">
    /// “-“-delimited string with format
    /// “{siteID}-{divisionID}-{userID}-{accountNumber}”. Eg:
    /// 001-011-5838423-001.
    /// </param>
    /// <param name="candleSpecification">
    /// An instrument name, a granularity, and a price component to get
    /// candlestick data for.
    /// </param>
    /// <param name="from">
    /// The start of the time range to fetch candlesticks for.
    /// </param>
    /// <param name="to">
    /// The end of the time range to fetch candlesticks for.
    /// When null, to the present time. TODO: Check this actually works.
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
    /// <param name="units">
    /// The number of units used to calculate the volume-weighted average bid
    /// and ask prices in the returned candles.
    /// </param>
    public async Task<CandlestickResponse> GetCandlestickData(
      string accountId,
      CandleSpecification candleSpecification,
      DateTime from,
      DateTime? to,
      bool smooth = false,
      bool includeFirst = true,
      int dailyAlignment = 17,
      string alignmentTimezone = "America/New_York",
      WeeklyAlignment weeklyAlignment = WeeklyAlignment.FRIDAY,
      int units = 1)
    {
      if (string.IsNullOrWhiteSpace(accountId))
        throw new ArgumentException(nameof(accountId));

      if (candleSpecification is null)
        throw new ArgumentNullException(nameof(candleSpecification));

      candleSpecification.Validate();

      if (dailyAlignment < 0 || dailyAlignment > 23)
        throw new ArgumentException(nameof(dailyAlignment));

      if (string.IsNullOrWhiteSpace(alignmentTimezone))
        throw new ArgumentException(nameof(alignmentTimezone));

      if (from.Kind != DateTimeKind.Utc)
        throw new ArgumentException("Kind must be set as utc.", nameof(from));

      if (to.HasValue)
      {
        if (to.Value.Kind != DateTimeKind.Utc)
          throw new ArgumentException("Kind must be set as utc.", nameof(to));
      }

      var query = new Dictionary<string, string>
      {
        { "price", candleSpecification.PricingComponent.ToString() },
        { "granularity", candleSpecification.CandleStickGranularity.ToString() },
        { "from", from.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture) },
        { "smooth", smooth.ToString() },
        { "includeFirst", includeFirst.ToString() },
        { "dailyAlignment", dailyAlignment.ToString(CultureInfo.InvariantCulture) },
        { "alignmentTimezone", alignmentTimezone },
        { "weeklyAlignment", weeklyAlignment.ToString() },
        { "units", units.ToString(CultureInfo.InvariantCulture) },
      };

      // TODO: check that this works when to is null.

      if (to.HasValue)
        query["to"] = to.Value.ToString(DATETIMEFORMATSTRING, CultureInfo.InvariantCulture);

      var url = QueryHelpers.AddQueryString($"v3/accounts/{accountId}/instruments/{candleSpecification.InstrumentName}/candles", query);
      using var request = new HttpRequestMessage(HttpMethod.Get, url);
      using var response = await _client.SendAsync(request, DisposedToken);
      await RequestFailedException.ThrowIfNecessary(response);
      return (await response.Content.ReadFromJsonAsync<CandlestickResponse>())!;
    }
  }
}
