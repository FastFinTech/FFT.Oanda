// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Transactions
{
  using System;
  using System.Text.Json;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Provides a way for inherited transaction types to be deserialized by parsing the
  /// <see cref="Transaction.Type"/> property to determine the appropriate type for
  /// deserialization.
  /// </summary>
  public sealed class TransactionConverter : JsonConverter<Transaction>
  {
    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
      => typeToConvert == typeof(Transaction);

    /// <inheritdoc/>
    public override Transaction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var readerCopy = reader;
      var element = JsonSerializer.Deserialize<JsonElement>(ref readerCopy, options);
      var typeElement = element.GetProperty("type");
      if (typeElement.ValueKind != JsonValueKind.String) throw new JsonException();
      var transactionType = Enum.Parse<TransactionType>(typeElement.GetString()!);
      return transactionType switch
      {
        TransactionType.CLIENT_CONFIGURE => JsonSerializer.Deserialize<ClientConfigureTransaction>(ref reader, options),
        TransactionType.CLIENT_CONFIGURE_REJECT => JsonSerializer.Deserialize<ClientConfigureRejectTransaction>(ref reader, options),
        TransactionType.CLOSE => JsonSerializer.Deserialize<CloseTransaction>(ref reader, options),
        TransactionType.CREATE => JsonSerializer.Deserialize<CreateTransaction>(ref reader, options),
        TransactionType.DAILY_FINANCING => JsonSerializer.Deserialize<DailyFinancingTransaction>(ref reader, options),
        TransactionType.DELAYED_TRADE_CLOSURE => JsonSerializer.Deserialize<DelayedTradeClosureTransaction>(ref reader, options),
        TransactionType.DIVIDEND_ADJUSTMENT => JsonSerializer.Deserialize<DividendAdjustmentTransaction>(ref reader, options),
        TransactionType.FIXED_PRICE_ORDER => JsonSerializer.Deserialize<FixedPriceOrderTransaction>(ref reader, options),
        TransactionType.GUARANTEED_STOP_LOSS_ORDER => JsonSerializer.Deserialize<GuaranteedStopLossOrderTransaction>(ref reader, options),
        TransactionType.GUARANTEED_STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<GuaranteedStopLossOrderRejectTransaction>(ref reader, options),
        TransactionType.LIMIT_ORDER => JsonSerializer.Deserialize<LimitOrderTransaction>(ref reader, options),
        TransactionType.LIMIT_ORDER_REJECT => JsonSerializer.Deserialize<LimitOrderRejectTransaction>(ref reader, options),
        TransactionType.MARGIN_CALL_ENTER => JsonSerializer.Deserialize<MarginCallEnterTransaction>(ref reader, options),
        TransactionType.MARGIN_CALL_EXIT => JsonSerializer.Deserialize<MarginCallExitTransaction>(ref reader, options),
        TransactionType.MARGIN_CALL_EXTEND => JsonSerializer.Deserialize<MarginCallExtendTransaction>(ref reader, options),
        TransactionType.MARKET_IF_TOUCHED_ORDER => JsonSerializer.Deserialize<MarketIfTouchedOrderTransaction>(ref reader, options),
        TransactionType.MARKET_IF_TOUCHED_ORDER_REJECT => JsonSerializer.Deserialize<MarketIfTouchedOrderRejectTransaction>(ref reader, options),
        TransactionType.MARKET_ORDER => JsonSerializer.Deserialize<MarketOrderTransaction>(ref reader, options),
        TransactionType.MARKET_ORDER_REJECT => JsonSerializer.Deserialize<MarketOrderRejectTransaction>(ref reader, options),
        TransactionType.ORDER_CANCEL => JsonSerializer.Deserialize<OrderCancelTransaction>(ref reader, options),
        TransactionType.ORDER_CANCEL_REJECT => JsonSerializer.Deserialize<OrderCancelRejectTransaction>(ref reader, options),
        TransactionType.ORDER_CLIENT_EXTENSIONS_MODIFY => JsonSerializer.Deserialize<OrderClientExtensionsModifyTransaction>(ref reader, options),
        TransactionType.ORDER_CLIENT_EXTENSIONS_MODIFY_REJECT => JsonSerializer.Deserialize<OrderClientExtensionsModifyRejectTransaction>(ref reader, options),
        TransactionType.ORDER_FILL => JsonSerializer.Deserialize<OrderFillTransaction>(ref reader, options),
        TransactionType.REOPEN => JsonSerializer.Deserialize<ReopenTransaction>(ref reader, options),
        TransactionType.RESET_RESETTABLE_PL => JsonSerializer.Deserialize<ResetResettablePLTransaction>(ref reader, options),
        TransactionType.STOP_LOSS_ORDER => JsonSerializer.Deserialize<StopLossOrderTransaction>(ref reader, options),
        TransactionType.STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<StopLossOrderRejectTransaction>(ref reader, options),
        TransactionType.STOP_ORDER => JsonSerializer.Deserialize<StopOrderTransaction>(ref reader, options),
        TransactionType.STOP_ORDER_REJECT => JsonSerializer.Deserialize<StopOrderRejectTransaction>(ref reader, options),
        TransactionType.TAKE_PROFIT_ORDER => JsonSerializer.Deserialize<TakeProfitOrderTransaction>(ref reader, options),
        TransactionType.TAKE_PROFIT_ORDER_REJECT => JsonSerializer.Deserialize<TakeProfitOrderRejectTransaction>(ref reader, options),
        TransactionType.TRADE_CLIENT_EXTENSIONS_MODIFY => JsonSerializer.Deserialize<TradeClientExtensionsModifyTransaction>(ref reader, options),
        TransactionType.TRADE_CLIENT_EXTENSIONS_MODIFY_REJECT => JsonSerializer.Deserialize<TradeClientExtensionsModifyRejectTransaction>(ref reader, options),
        TransactionType.TRAILING_STOP_LOSS_ORDER => JsonSerializer.Deserialize<TrailingStopLossOrderTransaction>(ref reader, options),
        TransactionType.TRAILING_STOP_LOSS_ORDER_REJECT => JsonSerializer.Deserialize<TrailingStopLossOrderRejectTransaction>(ref reader, options),
        TransactionType.TRANSFER_FUNDS => JsonSerializer.Deserialize<TransferFundsTransaction>(ref reader, options),
        TransactionType.TRANSFER_FUNDS_REJECT => JsonSerializer.Deserialize<TransferFundsRejectTransaction>(ref reader, options),
        _ => throw new JsonException(),
      };
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Transaction value, JsonSerializerOptions options)
      => throw new NotSupportedException();
  }
}
