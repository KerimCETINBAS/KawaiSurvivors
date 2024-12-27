
using Godot;
using Godot.Collections;

namespace KawaiSurvivor.Scenes.Behaviors;

public partial class SelectRandomBehavior : Node
{
    public TType SelectRandom<[MustBeVariant]TType>(Array<TType> array)
    {
        return array[GD.RandRange(0, array.Count - 1)];
    }
}