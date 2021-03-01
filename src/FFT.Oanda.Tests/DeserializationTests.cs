// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda.Tests
{
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class DeserializationTests
{
  [TestMethod]
  public void TestConversion()
  {
    var a = JsonSerializer.Deserialize<Base>(@"{""type"":""DerivedA"", ""A"":21}");
    var b = JsonSerializer.Deserialize<Base>(@"{""type"":""DerivedB"", ""B"":22}");
    Assert.AreEqual(21, (a as DerivedA)?.A);
    Assert.AreEqual(22, (b as DerivedB)?.B);
  }

  [JsonConverter(typeof(Converter))]
  private class Base
  {
  }

  private class DerivedA : Base
  {
    public int A { get; set; }
  }

  private class DerivedB : Base
  {
    public int B { get; set; }
  }

  private class Converter : JsonConverter<Base>
  {
    public override Base? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      // Copy the reader struct and parse the entire document just to get the
      // value of the "type" property.
      var copyReader = reader;
      using var doc = JsonDocument.ParseValue(ref copyReader);
      if (!doc.RootElement.TryGetProperty("type", out var typeElement))
        throw new JsonException("Could not find 'type' property.");
      var elementType = typeElement.GetString();
      if (string.IsNullOrWhiteSpace(elementType))
        throw new JsonException("'type' property was empty.");

      // Use the original reader struct to deserialize to the correct type.
      return elementType switch
      {
        "DerivedA" => JsonSerializer.Deserialize<DerivedA>(ref reader, options),
        "DerivedB" => JsonSerializer.Deserialize<DerivedB>(ref reader, options),
        _ => throw new JsonException($"'type' property value '{elementType}' is not known."),
      };
    }

    public override void Write(Utf8JsonWriter writer, Base value, JsonSerializerOptions options)
      => throw new NotImplementedException();
  }
}
}
