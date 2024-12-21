using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Behaviors;

public partial class AttackOnCollideBehavior : Node
{
    [Export] private Area2D TargetArea { get; set; }
    [Export] private Attack Attack { get; set; }
    
    public override void _Ready()
    {
        TargetArea.BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node body)
    {
        if (body is not Player) return;
        GD.Print(Attack);
        Attack.TryAttack();
    }
}