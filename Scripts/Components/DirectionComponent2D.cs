using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class DirectionComponent2D : GameComponent
{
    
    [Signal] public delegate void DirectionChangedEventHandler(DirectionComponent2D directionComponent2D);
    private Vector2 _direction = Vector2.Zero;

    public Vector2 Direction
    {
        get => _direction;
        private set
        {
            _direction = value;
            EmitSignal(nameof(DirectionChanged), this);
        }
    }

    public void SetDirectionBetweenPoints(Vector2 from, Vector2 to)
    {
        var direction = to - from;
        Direction = direction.Normalized().Clamp(-1, 1);
    }
}