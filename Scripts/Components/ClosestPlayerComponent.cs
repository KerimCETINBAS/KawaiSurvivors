using Godot;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Components;

public partial class ClosestPlayerComponent : Node
{
    [Signal] public delegate void OnClosestPlayerChangedEventHandler(Player player);
    
    public Player ClosestPlayer
    {
        get => _closestPlayer;
        private set
        {
            EmitSignal(SignalName.OnClosestPlayerChanged, value);
            _closestPlayer = value;
        }
    }
 
    private Player _closestPlayer;
    public void SetClosestPlayer(Player player)
    {
        ClosestPlayer = player;
    }

}