using Godot;
using KawaiSurvivor.Scripts.Actions.DaveActions;
using KawaiSurvivor.Scripts.Common.InputDevices;

namespace KawaiSurvivor.Scripts.Characters;
public partial class Dave: CharacterBody2D
{

    
    [ExportGroup("Required Components")]
    [Export] private MobileJoystick Joystick { get; set; }


    #region actions
    [ExportGroup("Actions")]
    [Export]
    private MoveAction MoveAction { get; set; }
    #endregion


    public override void _Ready()
    {
        MoveAction.UseMobileJoystickMovement(Joystick);
    }

    public override void _Process(double delta)
    {
        MoveAndSlide();
    }

    
    
}
