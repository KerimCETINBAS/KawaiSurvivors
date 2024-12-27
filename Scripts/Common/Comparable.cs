using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace KawaiSurvivor.Scripts.Common;

[GlobalClass]
public abstract partial class Comparable : Node, IEquatable<Comparable>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
        if (obj is null || obj.GetType() != GetType()) return false;
        Comparable comparable = (Comparable)obj;
        return GetEqualityComponents().SequenceEqual(comparable.GetEqualityComponents());
    }

    public static bool operator ==(Comparable left, Comparable right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Comparable left, Comparable right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((x, y) => x ^ y);
    }

    public bool Equals(Comparable other)
    {
        return Equals((object)other);
    }
}