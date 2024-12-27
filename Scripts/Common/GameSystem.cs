
using System.Linq;
using Godot;
using Godot.Collections;
using NotImplementedException = System.NotImplementedException;

namespace KawaiSurvivor.Scripts.Common;


/// <summary>
/// Is a special type of <see cref="Action"/> can live by own,
/// Specialized do <see cref="Component"/> based tasks
/// </summary>
[Tool]
[GlobalClass]
public  partial class GameSystem : GameAction
{
    [Export(PropertyHint.ArrayType)]
    protected Array<Entity> Entities { get; private set; }


    public override void _Ready()
    {
        GD.Print(GetTree().Root.GetNode<Node2D>("Lab").FindChildren("*", nameof(Entity)));
        var entities = GetTree().Root.GetNode<Node2D>("Lab").FindChildren("*", nameof(Entity));
        AddEntity(new Array<Entity>(entities.OfType<Entity>()));
    }

    protected Array<Entity> GetEntitiesWithin<[MustBeVariant]TComponent>() where TComponent : GameComponent
    {
        return new Array<Entity>(
            Entities.Where(e => e.GetComponent<TComponent>() is not null));
    }

    protected void AddEntity(Entity entity)
    {
        Entities.Add(entity);
    }
    
    protected void AddEntity(Array<Entity> entities)
    {
        Entities.AddRange(entities);
    }


    protected void RemoveEntity(Entity entity)
    {
        Entities.Remove(entity);
    }

    protected void RemoveEntity(Array<Entity> entities)
    {
        foreach (var entity in entities)
        {
            Entities.Remove(entity);
        }
    }
}



