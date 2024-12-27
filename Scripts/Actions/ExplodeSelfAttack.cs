using Godot;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public partial class ExplodeSelfAttack : Attack
{
    [Export] private CharacterBody2D Self { get; set; }
    [Export] private ParticleEmitterComponent Particles { get; set; }


    public override void TryAttack()
    {
        Particles.Particle.Finished += OnParticleFinished;
        Particles.Particle.Reparent(GetTree().Root);
        Particles.StartParticle();
        Self.QueueFree();
    }

    private void OnParticleFinished()
    {
        Particles.Particle.Finished -= OnParticleFinished;
        Particles.QueueFree();
    }

}