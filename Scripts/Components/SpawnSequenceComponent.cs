using Godot;
using KawaiSurvivor.Scripts.Common;

namespace KawaiSurvivor.Scripts.Components;

public partial class SpawnSequenceComponent : GameComponent
{
    [Signal] public delegate void OnSpawnFinishEventHandler(SpawnSequenceComponent component);
    [Export] private bool _spawnSequenceFinished;
    
    public bool SpawnSequenceFinished
    {
        get => _spawnSequenceFinished;
        set
        {
            if (!value && !_spawnSequenceFinished) return;
            _spawnSequenceFinished = true;
            EmitSignal(SignalName.OnSpawnFinish, this);
        }
    }
}