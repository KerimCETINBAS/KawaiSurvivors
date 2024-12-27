using Godot;

namespace KawaiSurvivor.Scripts.Components;

[GlobalClass]
[Tool]
public partial class SpawnComponent : Node
{
    
    [Signal] public delegate void OnSpawnedEventHandler(SpawnComponent spawnComponent);
    [Export] private bool _isSpawned;

    public bool IsSpawned
    {
        get => _isSpawned;
        set
        {
            if(_isSpawned) return;
            _isSpawned = value;
        }
    }
}