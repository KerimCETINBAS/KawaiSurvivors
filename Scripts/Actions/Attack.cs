using Godot;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public abstract partial class Attack : Node
{
    
    protected DamageComponent DamageComponent { get; set; }

    protected bool _canAttack;
    public bool CanAttack => _canAttack;
    public virtual void TryAttack()
    {
            
    }
    
    
}