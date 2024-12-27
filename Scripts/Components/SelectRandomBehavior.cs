using Godot;
using Godot.Collections;

namespace KawaiSurvivor.Scripts.Components;

[Tool]
public partial class SelectRandomBehavior : Node
{
    public TType SelectRandom<[MustBeVariant]TType>(Array<TType> items) where TType : GodotObject
    {
        return items.PickRandom();
    }
}