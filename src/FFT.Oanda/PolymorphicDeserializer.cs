// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Buffers;
  using System.Runtime.CompilerServices;
  using System.Text.Json;
  using FFT.Oanda.Orders;
  using FFT.Oanda.Pricing;
  using FFT.Oanda.Transactions;

  /// <summary>
  /// Used internally, this class provides the logic used to determine the
  /// correct type to be used in a polymorphic deserialization, and then
  /// deserialize it.
  /// </summary>
  internal static class PolymorphicDeserializer
  {
    /// <summary>
    /// These options are required to successfully deserialize the json
    /// documents received from oanda.
    /// </summary>
    private static readonly JsonSerializerOptions _webOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

    public static Order? DeserializeOrder(string type, ref Utf8JsonReader reader)
    {
      return Enum.Parse<OrderType>(type) switch
      {
        OrderType.LIMIT => JsonSerializer.Deserialize<LimitOrder>(ref reader, _webOptions),
        OrderType.MARKET => JsonSerializer.Deserialize<MarketOrder>(ref reader, _webOptions),
        OrderType.STOP => JsonSerializer.Deserialize<StopOrder>(ref reader, _webOptions),
        OrderType.MARKET_IF_TOUCHED => JsonSerializer.Deserialize<MarketIfTouchedOrder>(ref reader, _webOptions),
        OrderType.TAKE_PROFIT => JsonSerializer.Deserialize<TakeProfitOrder>(ref reader, _webOptions),
        OrderType.STOP_LOSS => JsonSerializer.Deserialize<StopLossOrder>(ref reader, _webOptions),
        OrderType.GUARANTEED_STOP_LOSS => JsonSerializer.Deserialize<GuaranteedStopLossOrder>(ref reader, _webOptions),
        OrderType.TRAILING_STOP_LOSS => JsonSerializer.Deserialize<TrailingStopLossOrder>(ref reader, _webOptions),
        OrderType.FIXED_PRICE => JsonSerializer.Deserialize<FixedPriceOrder>(ref reader, _webOptions),
        _ => throw new JsonException(),
      };
    }

    public static Transaction? DeserializeTransaction(string type, ref Utf8JsonReader reader)
    {
      return Enum.Parse<TransactionType>(type) switch
      {
        TransactionType.CLIENT_CONFIGURE => JsonSerializer.Deserialize<ClientConfigureTransaction>(ref reader, _webOptions),
        TransactionType.CLIENT_CONFIGURE_REJECT => JsonSerializer.Deserialize<ClientConfigureRejectTransaction>(ref reader, _webOptions),
        TransactionType.CLOSE => JsonSerializer.Deserialize<CloseTransaction>(ref reader, _webOptions),
        TransactionType.CREATE => JsonSerializer.Deserialize<CreateTransaction>(ref reader, _webOptions),
        TransactionType.DAILY_FINANCING => JsonSerializer.Deserialize<DailyFinancingTransaction>(ref reader, _webOptions),
        TransactionType.DELAYED_TRADE_CLOSURE => JsonSerializer.Deserialize<DelayedTradeClosureTransaction>(ref reader, _webOptions),
        TransactionType.DIVIDEND_ADJUSTMENT => JsonSerializer.Deserialize<DividendAdjustmentTransaction>(ref reader, _webOptions),
        TransactionType.FIXED_PRICE_ORDER => JsonSerializer.Deserialize<FixedPriceOrderTransaction>(ref reader, _webOptions),
        TransactionType.GUARANTEED_STOP_LOSS_ORDER => JsonSerializer.Deserialize<GuaranteedStopLossOrderTransaction>(ref reader, _webOptions),
        TransactionType.GUARANTEED_STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<GuaranteedStopLossOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.LIMIT_ORDER => JsonSerializer.Deserialize<LimitOrderTransaction>(ref reader, _webOptions),
        TransactionType.LIMIT_ORDER_REJECT => JsonSerializer.Deserialize<LimitOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.MARGIN_CALL_ENTER => JsonSerializer.Deserialize<MarginCallEnterTransaction>(ref reader, _webOptions),
        TransactionType.MARGIN_CALL_EXIT => JsonSerializer.Deserialize<MarginCallExitTransaction>(ref reader, _webOptions),
        TransactionType.MARGIN_CALL_EXTEND => JsonSerializer.Deserialize<MarginCallExtendTransaction>(ref reader, _webOptions),
        TransactionType.MARKET_IF_TOUCHED_ORDER => JsonSerializer.Deserialize<MarketIfTouchedOrderTransaction>(ref reader, _webOptions),
        TransactionType.MARKET_IF_TOUCHED_ORDER_REJECT => JsonSerializer.Deserialize<MarketIfTouchedOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.MARKET_ORDER => JsonSerializer.Deserialize<MarketOrderTransaction>(ref reader, _webOptions),
        TransactionType.MARKET_ORDER_REJECT => JsonSerializer.Deserialize<MarketOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.ORDER_CANCEL => JsonSerializer.Deserialize<OrderCancelTransaction>(ref reader, _webOptions),
        TransactionType.ORDER_CANCEL_REJECT => JsonSerializer.Deserialize<OrderCancelRejectTransaction>(ref reader, _webOptions),
        TransactionType.ORDER_CLIENT_EXTENSIONS_MODIFY => JsonSerializer.Deserialize<OrderClientExtensionsModifyTransaction>(ref reader, _webOptions),
        TransactionType.ORDER_CLIENT_EXTENSIONS_MODIFY_REJECT => JsonSerializer.Deserialize<OrderClientExtensionsModifyRejectTransaction>(ref reader, _webOptions),
        TransactionType.ORDER_FILL => JsonSerializer.Deserialize<OrderFillTransaction>(ref reader, _webOptions),
        TransactionType.REOPEN => JsonSerializer.Deserialize<ReopenTransaction>(ref reader, _webOptions),
        TransactionType.RESET_RESETTABLE_PL => JsonSerializer.Deserialize<ResetResettablePLTransaction>(ref reader, _webOptions),
        TransactionType.STOP_LOSS_ORDER => JsonSerializer.Deserialize<StopLossOrderTransaction>(ref reader, _webOptions),
        TransactionType.STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<StopLossOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.STOP_ORDER => JsonSerializer.Deserialize<StopOrderTransaction>(ref reader, _webOptions),
        TransactionType.STOP_ORDER_REJECT => JsonSerializer.Deserialize<StopOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.TAKE_PROFIT_ORDER => JsonSerializer.Deserialize<TakeProfitOrderTransaction>(ref reader, _webOptions),
        TransactionType.TAKE_PROFIT_ORDER_REJECT => JsonSerializer.Deserialize<TakeProfitOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.TRADE_CLIENT_EXTENSIONS_MODIFY => JsonSerializer.Deserialize<TradeClientExtensionsModifyTransaction>(ref reader, _webOptions),
        TransactionType.TRADE_CLIENT_EXTENSIONS_MODIFY_REJECT => JsonSerializer.Deserialize<TradeClientExtensionsModifyRejectTransaction>(ref reader, _webOptions),
        TransactionType.TRAILING_STOP_LOSS_ORDER => JsonSerializer.Deserialize<TrailingStopLossOrderTransaction>(ref reader, _webOptions),
        TransactionType.TRAILING_STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<TrailingStopLossOrderRejectTransaction>(ref reader, _webOptions),
        TransactionType.TRANSFER_FUNDS => JsonSerializer.Deserialize<TransferFundsTransaction>(ref reader, _webOptions),
        TransactionType.TRANSFER_FUNDS_REJECT => JsonSerializer.Deserialize<TransferFundsRejectTransaction>(ref reader, _webOptions),
        _ => throw new JsonException(),
      };
    }

    public static object DeserializeTransactionStreamObject(ReadOnlySequence<byte> buffer)
    {
      var reader = new Utf8JsonReader(buffer);
      var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
      if (type == "HEARTBEAT")
      {
        return JsonSerializer.Deserialize<TransactionHeartbeat>(ref reader, _webOptions)!;
      }

      return DeserializeTransaction(type, ref reader)!;
    }

    public static object DeserializePriceStreamObject(ReadOnlySequence<byte> buffer)
    {
      var reader = new Utf8JsonReader(buffer);
      var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
      if (type == "HEARTBEAT")
      {
        return JsonSerializer.Deserialize<PricingHeartbeat>(ref reader, _webOptions)!;
      }

      return JsonSerializer.Deserialize<ClientPrice>(ref reader, _webOptions)!;
    }

    /// <summary>
    /// This method parses the document contained in <paramref name="reader"/>
    /// and extracts the value of the "type" property. The reader struct is
    /// passed by value (a copy of the struct is made) so reading it here does
    /// not mutate the read position state of the reader struct in the calling
    /// method. This method has the specific "no inlining" instruction to make
    /// sure the reader struct is COPIED to prevent mutating the state of the
    /// reader struct in the calling method.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string ExtractTypePropertyWithoutMutatingReaderState(this Utf8JsonReader reader)
    {
      var type = JsonSerializer.Deserialize<TypeDTO>(ref reader, _webOptions).Type;
      if (string.IsNullOrWhiteSpace(type))
        throw new JsonException("Unable to find the 'type' property.");
      return type;
    }
  }
}
