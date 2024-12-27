using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Systems;

public partial class VelocitySystem : GameSystem
{
    public override void _PhysicsProcess(double delta)
    {
       
        foreach (var e in GetEntitiesWithin<VelocityComponent>())
        {
            var velocityComponent = e.GetComponent<VelocityComponent>();
            var characterBodyComponent = e.GetComponent<CharacterBodyComponent2D>();
            characterBodyComponent.Body.Velocity = velocityComponent.Velocity;
            characterBodyComponent.Body.MoveAndSlide();
        }
    }
    
    
}