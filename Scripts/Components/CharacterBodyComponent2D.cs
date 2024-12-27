using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class CharacterBodyComponent2D : GameComponent
{
    [Export]
    public CharacterBody2D Body { get; private set; }


    public void SetCharacterBody(CharacterBody2D characterBody)
    {
        Body = characterBody;
    }
}