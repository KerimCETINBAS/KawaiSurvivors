using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;
using KawaiSurvivor.Scripts.Misc;

namespace KawaiSurvivor.Scripts.Systems;

public partial class MobileJoystickInputSystem : GameSystem
{
    [Export] private MobileJoystick _joystick;
    public override void _Ready()
    {
        base._Ready();
        _joystick.OnJoystickMovement += HandleJoystickInput;
    }

    private void HandleJoystickInput(Vector2 direction)
    {
        
        foreach (var entity in GetEntitiesWithin<MobileJoystickInputComponent>())
        {
            entity.GetComponent<MobileJoystickInputComponent>().SetDirection(direction);
        }
    }



}