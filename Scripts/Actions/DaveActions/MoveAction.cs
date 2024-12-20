using Godot;
using KawaiSurvivor.Scripts.Common.InputDevices;
namespace KawaiSurvivor.Scripts.Actions.DaveActions;

public partial class MoveAction: Node
{
    

    [Export(PropertyHint.Range, "0,10000, 0.1")]
    private float CharacterMoveFactor { get; set; }
    
    [Export]
    private CharacterBody2D Character { get; set; }

    private bool _usingMobileJoystick = false;
    private MobileJoystick _mobileJoystick;

    public override void _Process(double delta)
    {
        if (_usingMobileJoystick)
        {
            Character.Velocity = _mobileJoystick.JoystickPosition * (float)delta;
            Character.Velocity *= CharacterMoveFactor;
        }
    }

    public void UseMobileJoystickMovement(MobileJoystick joystick)
    {
        _usingMobileJoystick = true;
        _mobileJoystick = joystick;
      
    }

    public void UseGamePadMovement(Vector2 movement, double delta)
    {
        
    }
}