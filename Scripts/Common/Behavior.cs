using System.Linq;
using Godot;
using Godot.Collections;

namespace KawaiSurvivor.Scripts.Common;

[Tool]
[GlobalClass]
public abstract partial class Behavior : GameAction
{
    [Export(PropertyHint.ArrayType)] private Array<Policy> _policies;
    
    protected Array<Policy> Policies
    {
        get => _policies; 
        set => _policies = value;
    }
    
    
    /// <summary>
    /// Gets a policy by type
    /// </summary>
    /// <typeparam name="TPolicy"></typeparam>
    /// <returns></returns>
    protected Policy GetPolicy<TPolicy>() where TPolicy : Policy
    {
        return Policies?.OfType<TPolicy>()?.First();
    }
    
    protected void AddPolicy(Policy policy)
    {
        Policies.Add(policy);
    }

    protected void RemovePolicy(Policy policy)
    {
        Policies.Remove(policy);
    }
}