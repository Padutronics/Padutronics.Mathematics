using Padutronics.Diagnostics.Debugging;
using Padutronics.Ranges;
using System;
using System.Diagnostics;

namespace Padutronics.Mathematics;

[DebuggerDisplay(DebuggerDisplayValues.ToStringWithoutQuotes)]
public sealed class NormalizedValue : IComparable<NormalizedValue>, IEquatable<NormalizedValue>
{
    private static readonly Range<double> validRange = new Range<double>(0.0, 1.0);

    private readonly double value;

    public NormalizedValue(double value)
    {
        if (!validRange.Contains(value))
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, $"Normalized value {value} is out range.");
        }

        this.value = value;
    }

    public int CompareTo(NormalizedValue? other)
    {
        return value.CompareTo(other?.value);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as NormalizedValue);
    }

    public bool Equals(NormalizedValue? other)
    {
        return other is not null && value == other.value;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(value);
    }

    public double ToDouble()
    {
        return value;
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public static bool operator ==(NormalizedValue? left, NormalizedValue? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(NormalizedValue? left, NormalizedValue? right)
    {
        return !(left == right);
    }

    public static bool operator >=(NormalizedValue? left, NormalizedValue? right)
    {
        return right <= left;
    }

    public static bool operator <=(NormalizedValue? left, NormalizedValue? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(NormalizedValue? left, NormalizedValue? right)
    {
        return right < left;
    }

    public static bool operator <(NormalizedValue? left, NormalizedValue? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static implicit operator NormalizedValue(double value)
    {
        return new NormalizedValue(value);
    }
}