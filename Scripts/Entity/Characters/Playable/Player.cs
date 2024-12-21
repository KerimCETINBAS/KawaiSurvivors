using Godot;

namespace KawaiSurvivor.Scripts.Entity.Characters.Playable;

public partial class Player : CharacterBody2D, IPlayer
{
    public bool IsMe { get; set; }
    public CharacterBody2D GetPlayer()
    {
        return this;
    }
}