using Godot;

namespace KawaiSurvivor.Scripts.Common;


/// <summary>
/// Base Class for all ECS elements
/// </summary>
[Tool]
[GlobalClass]
public  partial class GameComponent : Node 
{
    [Export] private Entity _parentEntity;
    public Entity ParentEntity => _parentEntity;
}