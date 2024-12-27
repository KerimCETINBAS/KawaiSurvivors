using Godot;

namespace KawaiSurvivor.Scripts.Common;

/// <summary>
/// Base satisfable class
/// </summary>
[GlobalClass]
[Tool]
public  partial class Policy : GameComponent
{
    
    [Signal] public delegate void OnSatisfiedEventHandler(Policy policy);
    private bool _isSatisfied;

    public bool IsSatisfied
    {
        get => _isSatisfied;
        protected set
        {
            _isSatisfied = value;
            EmitSignal(nameof(OnSatisfied), this);
        }
    }
}