using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Entity.Enemies;

public partial class RedGhost : Common.Entity
{
    public override void _Ready()
    {
        GD.Print("EntityId :", Id.Value);
    }
}