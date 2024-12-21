using Godot;

namespace KawaiSurvivor.Scripts.Actions;

public partial class ExplodeSelfAttack : Attack
{
    [Export] private Node Item { get; set; }
    public override void TryAttack()
    {
        Item.QueueFree();
    }
}