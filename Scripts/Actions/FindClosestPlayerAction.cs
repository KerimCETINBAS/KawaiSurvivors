using System.Runtime.CompilerServices;
using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;
using KawaiSurvivor.Scripts.Globals;

namespace KawaiSurvivor.Scripts.Actions;

public partial class FindClosestPlayerAction : GameAction
{

    [Export] private CharacterBodyComponent2D _characterBodyComponent;
    [Export] private PlayerRefComponent _playerRefComponent;

    public void Execute()
    {
 
        var closestDistance = float.MaxValue;
        Player closestPlayer = null;
       
        foreach (var player in PlayerManager.Instance.Players)
        {
            var distance = _characterBodyComponent.Body
                .GlobalPosition
                .DistanceTo(player.GetComponent<CharacterBodyComponent2D>().Body.GlobalPosition);
            
            if (!(distance < closestDistance)) continue;
            closestDistance = distance;
            closestPlayer = player;
        }
        _playerRefComponent.SetPlayer(closestPlayer);
    }
}