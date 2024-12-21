using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Behaviors;

namespace KawaiSurvivor.Scripts.Entity.Characters.Enemy;

public partial class RedGhost : CharacterBody2D
{

    [Export] private MoveAction _moveAction;
    [Export] private FindClosestPlayerBehavior _findClosestPlayerBehavior;
    public override void _Ready()
    {
        _moveAction.UseMoveClosestPlayer(_findClosestPlayerBehavior);
    }
}