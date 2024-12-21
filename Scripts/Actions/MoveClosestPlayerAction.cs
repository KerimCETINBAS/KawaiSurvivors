using Godot;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public partial class MoveClosestPlayerAction : Node
{
    [Export] private VelocityComponent VelocityComponent { get; set; }
}