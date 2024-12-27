using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class PositionComponent : GameComponent
{
    [Signal] public delegate void PositionUpdatedEventHandler(
        GameComponent sender, 
        Node2D item, 
        Common.Entity parent);
    
    [Export] private Node2D _item;
    
    private Vector2 _position = Vector2.Zero;
    private Vector2 _globalPosition = Vector2.Zero;
    public Vector2 Position
    {
        get => _position;
        set
        {
            if(_position.Equals(value)) return;
            _position = value;
            EmitSignal(SignalName.PositionUpdated, this, _item, ParentEntity);
            
        }
    }

    public Vector2 GlobalPosition
    {
        get => _globalPosition;
        set
        {
            if(_globalPosition.Equals(value)) return;
            _globalPosition = value;
            EmitSignal(SignalName.PositionUpdated, this, _item, ParentEntity);
        }
    }

    public override void _Ready()
    {
        Position = _item.GlobalPosition;
    }
}