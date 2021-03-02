// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda
{
  using System;
  using System.Globalization;
  using System.Text.Json;
  using System.Text.Json.Serialization;

  /// <summary>
  /// Represents "ALL" units or a fixed number of units.
  /// </summary>
  [JsonConverter(typeof(NumUnitsJsonConverter))]
  public struct NumUnits
  {
    private readonly decimal? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="NumUnits"/> struct.
    /// </summary>
    /// <param name="numUnits">Either "ALL" or the string representation of a
    /// decimal value for a fixed number of units.</param>
    public NumUnits(string numUnits)
    {
      _value = numUnits == "ALL"
        ? null
        : decimal.Parse(numUnits, NumberStyles.Any, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumUnits"/> struct. Use
    /// this constructor when you need to specify a fixed number of units.
    /// </summary>
    /// <param name="value">The fixed number of units that you wish to
    /// specify.</param>
    public NumUnits(decimal value)
    {
      _value = value;
    }

    /// <summary>
    /// A singleton value to be used for quick access to an instance
    /// representing "ALL" units.
    /// </summary>
    public static NumUnits All { get; } = new NumUnits("ALL");

    /// <summary>
    /// Gets <see langword="true"/> if this value represents "ALL" units rather
    /// than a fixed number of units. Gets <see langword="false"/> otherwise.
    /// </summary>
    public bool IsAllUnits => !_value.HasValue;

    /// <summary>
    /// Gets the fixed number of units represented by this value, if it is NOT
    /// "ALL" units.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if this value
    /// represents "ALL" units.</exception>
    public decimal Value => _value!.Value;

    /// <inheritdoc/>
    public override string ToString()
      => _value?.ToString() ?? "ALL";

    private sealed class NumUnitsJsonConverter : JsonConverter<NumUnits>
    {
      public override bool CanConvert(Type typeToConvert)
        => typeToConvert == typeof(NumUnits);

      public override NumUnits Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      {
        if (reader.TokenType != JsonTokenType.String) throw new JsonException();
        return new NumUnits(reader.GetString()!);
      }

      public override void Write(Utf8JsonWriter writer, NumUnits value, JsonSerializerOptions options)
      {
        writer.WriteStringValue(value.ToString());
      }
    }
  }
}
