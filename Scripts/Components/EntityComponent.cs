using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public sealed partial class EntityComponent : GameComponent
{
    [Signal] public delegate void EntityChangedEventHandler(
        EntityComponent component, 
        Common.Entity entity);
    
    
    private Common.Entity _entity;
    public Common.Entity Entity
    {
        get => _entity;
        set {
            if (_entity != value) return;
            _entity = value;
            EmitSignal(nameof(EntityChanged), value, this);
        }
    }
 
}