// Copyright (c) True Goodwill. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace FFT.Oanda;

using System.Diagnostics.CodeAnalysis;
using System.Numerics;

/// <summary>
/// Represents "ALL" units or a fixed number of units.
/// </summary>
[JsonConverter(typeof(NumUnitsJsonConverter))]
public struct NumUnits : IEquatable<NumUnits>
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
  public static NumUnits All { get; } = new("ALL");

  /// <summary>
  /// A singleton value to be used for quick access to an instance
  /// representing "0" units.
  /// </summary>
  public static NumUnits Zero { get; } = new(0m);

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

  /// <summary>
  /// Implicitly converts a decimal value to a <see cref="NumUnits"/> value.
  /// </summary>
  /// <param name="value">The value to be converted.</param>
  public static implicit operator NumUnits(decimal value) => new(value);

  /// <summary>
  /// Implicitly converts an int32 value to a <see cref="NumUnits"/> value.
  /// </summary>
  /// <param name="value">The value to be converted.</param>
  public static implicit operator NumUnits(int value) => new(value);

  public static bool operator ==(NumUnits left, NumUnits right)
  => left.Equals(right);

  public static bool operator !=(NumUnits left, NumUnits right)
    => !left.Equals(right);

  /// <summary>
  /// Returns "ALL" if this value represents all units. Otherwise, it returns
  /// a string representation of the decimal value.
  /// </summary>
  public override string ToString()
    => _value?.ToString() ?? "ALL";

  public override int GetHashCode()
    => _value?.GetHashCode() ?? 0;

  public override bool Equals([NotNullWhen(true)] object? obj)
    => obj is NumUnits other && Equals(other);

  public bool Equals(NumUnits other)
    => _value == other._value;

  private sealed class NumUnitsJsonConverter : JsonConverter<NumUnits>
  {
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
