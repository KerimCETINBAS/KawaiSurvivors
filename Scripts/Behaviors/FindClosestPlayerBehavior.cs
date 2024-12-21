using System.Collections.Generic;
using System.Linq;
using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Components;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Behaviors;

public partial class FindClosestPlayerBehavior : Node
{
    [Signal] public delegate void OnClosestPlayerDirectionChangedEventHandler(Vector2 direction);
    [Export] private CharacterBody2D Character { get; set; }
    [Export] private MoveAction MoveAction { get; set; }
    [Export] private ClosestPlayerComponent ClosestPlayerComponent { get; set; }
    public Player FindClosestPlayer()
    {
        float closestDistance = float.MaxValue;
        Player closestPlayer = null;
        // Find the closest player
        List<Player> players = GetTree().GetNodesInGroup("Player").OfType<Player>().ToList();
        foreach (Player player in players)
        {
            float distance = Character.GlobalPosition.DistanceTo(player.GlobalPosition);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }

    public override void _Ready()
    {
        ClosestPlayerComponent.SetClosestPlayer(FindClosestPlayer());
        MoveAction.UseMoveClosestPlayer(this);
    }

    public override void _Process(double delta)
    {
        var direction = ClosestPlayerComponent.ClosestPlayer.GlobalPosition - Character.GlobalPosition;
        direction = direction.Normalized().Clamp(-1, 1);
        EmitSignal(SignalName.OnClosestPlayerDirectionChanged, direction);
    }
}