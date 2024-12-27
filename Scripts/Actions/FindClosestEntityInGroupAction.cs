
using KawaiSurvivor.Scripts.Common;
using Godot;

namespace KawaiSurvivor.Scripts.Actions;

public partial class FindClosestPlayerAction : GameAction
{
    private StringName _playerGroup = new StringName("Player");
    // public override void Execute()
    // {
    //     // var closestDistance = float.MaxValue;
    //     // var players = GetTree().GetNodesInGroup(_playerGroup).OfType<Player>().ToList();
    //     // foreach (var player in players)
    //     // {
    //     //     var distance = Entity.GetComponent<PositionComponent>().GlobalPosition.DistanceTo(player.GlobalPosition);
    //     //     if (!(distance < closestDistance)) continue;
    //     //     closestDistance = distance;
    //     //     Entity.GetComponent<ClosestPlayerComponent>().Player = player;
    //     // }
    // }
}