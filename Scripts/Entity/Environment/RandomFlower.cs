using Godot;
using Godot.Collections;
using KawaiSurvivor.Scenes.Behaviors;

namespace KawaiSurvivor.Scripts.Entity.Environment;

[Tool]
public partial class RandomFlower : Sprite2D
{
    [Export] private Components.SelectRandomBehavior SelectRandomBehavior { get; set; }

    [Export(PropertyHint.ArrayType)]
    private Array<CompressedTexture2D> Flowers { get; set; } = new();

    public override void _EnterTree()
    {
         SelectRandomTexture();
    }

    private void SelectRandomTexture()
    {
        var texture = SelectRandomBehavior.SelectRandom(Flowers);
        Texture = texture;
    }
}