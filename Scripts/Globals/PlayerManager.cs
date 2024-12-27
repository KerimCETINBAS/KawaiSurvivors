using System.Linq;
using Godot;
using Godot.Collections;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Entity.Characters.Playable;

namespace KawaiSurvivor.Scripts.Globals;

public partial class PlayerManager : GameSystem
{

    public static PlayerManager Instance
    {
        get; 
        private set;
    } 
    [Export] public Array<Player> Players { get; private set; }
    
    public override void _Ready()
    {
        Instance = this;
        Players = new Array<Player>(GetTree().GetNodesInGroup(nameof(Player)).Cast<Player>());
    }
}