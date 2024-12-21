using Godot;
using KawaiSurvivor.Scripts.Actions;
using KawaiSurvivor.Scripts.Misc;

namespace KawaiSurvivor.Scripts.Entity.Characters.Playable;

public partial class Dave : Player
{
    [Export] private MobileJoystick _mobileJoystick;
    [Export] private MoveAction _moveAction;
    
    public override void _Ready()
    {
         _moveAction.UseMobileJoystick(_mobileJoystick); 
    }

}