using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class MobileJoystickInputComponent : GameComponent
{
    [Signal] public delegate void OnDirectionChangeEventHandler(
        MobileJoystickInputComponent component);
    
    private Vector2 _direction = Vector2.Zero;
    public Vector2 Direction
    {
        get => _direction;
        private set
        {
            if (_direction.Equals(value)) return;
         
            _direction = value;
            EmitSignal(SignalName.OnDirectionChange, this);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}