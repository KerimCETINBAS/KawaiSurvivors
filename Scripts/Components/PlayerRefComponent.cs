
using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Components;

public partial class PlayerRefComponent : GameComponent
{
    [Signal] public delegate void OnPlayerChangedEventHandler(PlayerRefComponent component);
   
    private Player _player;
    
    public Player Player => _player;
    public void SetPlayer(Player player)
    {
        _player = player;
        EmitSignal(nameof(OnPlayerChanged), this);
    }
}