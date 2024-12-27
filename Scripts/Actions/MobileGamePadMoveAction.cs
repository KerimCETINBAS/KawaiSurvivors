using System;
using Godot;
using KawaiSurvivor.Scripts.Behaviors;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;


public partial class MobileGamePadMoveAction : GameAction
{
    [Export] private VelocityComponent _velocityComponent;
    [Export] private MobileJoystickInputComponent _joystickInputComponent;
    public override void _Ready()
    {
        _joystickInputComponent.OnDirectionChange += HandleMobileJoystickInputChanged;
    }

    private void HandleMobileJoystickInputChanged(
        MobileJoystickInputComponent component)
    {
       _velocityComponent.Direction = component.Direction;
    }
}