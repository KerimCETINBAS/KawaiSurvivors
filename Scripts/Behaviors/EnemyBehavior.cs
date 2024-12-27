
using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Policies;

namespace KawaiSurvivor.Scripts.Behaviors;

public partial class EnemyBehavior : Behavior
{
    [Export] private FindClosestPlayerAction _findClosestPlayerAction;
    [Export] private MoveToClosestPlayerAction _moveToClosestPlayerAction;
    [Export] private SpawnAction _spawnAction;

    public override void _Process(double delta)
    {

        // Handle spawn sequence
        if (!GetPolicy<SpawnCompletedPolicy>().IsSatisfied)
        {
            if (_spawnAction.ActionStatus == ActionStatus.Waiting &&
                _spawnAction.ActionStatus != ActionStatus.Running)
            {
                _spawnAction.Execute();
            }
         
            return;
        }

        // Handle finding the closest player
        if (!GetPolicy<EnemyFoundPolicy>().IsSatisfied)
        {
            if (_findClosestPlayerAction.ActionStatus != ActionStatus.Running &&
                _findClosestPlayerAction.ActionStatus != ActionStatus.Completed)
            {
                _findClosestPlayerAction.Execute();
            }
            return; 
        }

        // Handle moving towards the player
        if (GetPolicy<EnemyFoundPolicy>().IsSatisfied)
        {
            if (
                _moveToClosestPlayerAction.ActionStatus != ActionStatus.Running &&
                _moveToClosestPlayerAction.ActionStatus != ActionStatus.Completed)
            {
                _moveToClosestPlayerAction.Execute();
            }
        }
    }
}