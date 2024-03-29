﻿// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.JsonConverters;

using FFT.Oanda.Transactions;

internal sealed class TransactionConverter : JsonConverter<Transaction>
{
  public override Transaction? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    var type = reader.ExtractTypePropertyWithoutMutatingReaderState();
    return PolymorphicDeserializer.DeserializeTransaction(type, ref reader);
  }

  public override void Write(Utf8JsonWriter writer, Transaction value, JsonSerializerOptions options)
    => throw new NotSupportedException();
}
