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
    public override Transaction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
      return PolymorphicDeserializer.DeserializeTransaction(type, ref reader);
    }

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, Transaction value, JsonSerializerOptions options)
      => throw new NotSupportedException();
  }
}
