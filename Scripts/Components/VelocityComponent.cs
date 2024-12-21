using Godot;

namespace KawaiSurvivor.Scripts.Components;

public partial class VelocityComponent : Node
{
    [Signal] public delegate void OnVelocityChangeEventHandler(Vector2 velocity);
    [Export] public float SpeedFactor { get; private set; }
    
    private Vector2 _velocity = Vector2.Zero;
    public Vector2 Velocity
    {
        get => _velocity;
        private set
        {
            EmitSignal(SignalName.OnVelocityChange, value);
            _velocity = value;
        }
    } 
    public void Accelerate(Vector2 direction)
    {
        Velocity = direction * SpeedFactor;
    }
}