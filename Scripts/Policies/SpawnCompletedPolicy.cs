
using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Policies;

public partial class SpawnCompletedPolicy : Policy
{
    [Export] private SpawnSequenceComponent _spawnSequenceComponent;
    [Export] private SpawnAction _spawnAction;

    public override void _Process(double delta)
    {
        if (IsSatisfied)
        {
            SetProcess(false);    
            return;
        }
        
        IsSatisfied = _spawnSequenceComponent.SpawnSequenceFinished &&
            _spawnAction.ActionStatus == ActionStatus.Completed;
    }
}