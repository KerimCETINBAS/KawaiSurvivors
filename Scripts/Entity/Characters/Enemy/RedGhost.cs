
using System.Linq;
using Godot;
using Godot.Collections;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Behaviors;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Entity.Characters.Enemy;

public partial class RedGhost : CharacterBody2D
{
    [Export] private Array<Node> Components { get; set; }

    public override void _Ready()
    {
     //   _moveAction.UseMoveClosestPlayer(_findClosestPlayerBehavior);
    }

  
}