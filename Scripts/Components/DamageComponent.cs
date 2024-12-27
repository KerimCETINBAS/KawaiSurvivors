using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class DamageComponent : GameComponent
{
    [Export] 
    public float DamageFactor { get => _damage; private set => _damage = value; }
    private float _damage = 0f;

}