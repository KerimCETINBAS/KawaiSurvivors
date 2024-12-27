using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;


public partial class ParticleEmitterComponent : GameComponent
{
    [Export] private GpuParticles2D _particle;
    [Export] public bool IsOneShot { get; set; } = false;
    [Export] public bool IsPlaying { get; set; } = false;

    
    public GpuParticles2D Particle => _particle;

    public override void _Ready()
    {
        Particle.OneShot = IsOneShot;
        Particle.Emitting = false;
        Particle.Finished += OnParticleFinished;
    }


    public GpuParticles2D GetParticle() => Particle;
    public void StartParticle()
    {
        Particle.Emitting = true;    
    }

    private void OnParticleFinished()
    {
        Particle.Finished -= OnParticleFinished;
        Particle.QueueFree();
    }
    
}