using Godot;

namespace KawaiSurvivor.Scripts.Entity.Characters.Playable;

public partial interface IPlayer
{
    bool IsMe { get; set; }
    CharacterBody2D GetPlayer();
}