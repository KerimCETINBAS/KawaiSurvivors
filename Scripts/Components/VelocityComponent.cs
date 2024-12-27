using System;
using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Components;

public partial class VelocityComponent : GameComponent
{   
    /// <summary>
    /// #todo refactor this emit signals from a central signal hup
    /// </summary>
    [Signal] public delegate void OnVelocityChangeEventHandler(
        VelocityComponent component, 
        Common.Entity entity);

    [Export] private float _speedFactor = 0.0f;
    
    private Vector2 _direction = Vector2.Zero;
    
    public float SpeedFactor
    {
        get => _speedFactor;
        private set
        {
            GD.Print(value);
            _speedFactor = value;
            EmitSignal(nameof(OnVelocityChange), this, ParentEntity);
        }
    }
    public Vector2 Direction { get => _direction;
        set
        {
      
            if (_direction.Equals(value)) return;
            _direction = value;
            if (ParentEntity is Dave) 
                GD.Print(value, _speedFactor, Velocity);
            EmitSignal(nameof(OnVelocityChange), this, ParentEntity);
        }
    }
    
    public Vector2 Velocity => _direction * _speedFactor;
}