
using System.Collections.Generic;
using System.Linq;
using Godot;
using Godot.Collections;
namespace KawaiSurvivor.Scripts.Common;


/// <summary>
/// A Specialized class for Entity
/// </summary>
[Tool]
[GlobalClass]
public partial class Entity: Comparable
{
    public EntityId Id { get; } = EntityId.CreateUnique();

    [Export] private Array<GameComponent> _components;
    protected Array<GameComponent> Components => _components;
    public TComponent GetComponent<[MustBeVariant] TComponent>()
        where TComponent : GameComponent
    {
        return _components.OfType<TComponent>().FirstOrDefault();
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Components;
    }
}


