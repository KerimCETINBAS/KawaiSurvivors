using Godot;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public partial class Attack : Node
{
    
    [Export] protected DamageComponent DamageComponent { get; set; }
    public virtual void TryAttack()
    {
        
    }
}