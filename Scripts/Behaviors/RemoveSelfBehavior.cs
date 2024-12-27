using Godot;

namespace KawaiSurvivor.Scripts.Behaviors;

public partial class RemoveSelfBehavior : Node
{
    [Export] private Node Entity { get; set; }

    public void RemoveSelf()
    {
        Entity.QueueFree();
    }
}