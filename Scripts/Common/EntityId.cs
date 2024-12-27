using System;
using System.Collections.Generic;

namespace KawaiSurvivor.Scripts.Common;

public sealed partial class EntityId : Comparable
{
    public Guid Value { get; }

    private EntityId(Guid value)
    {
        Value = value;
    }

    public EntityId() { }

    public static EntityId CreateUnique() => new(Guid.NewGuid());
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}