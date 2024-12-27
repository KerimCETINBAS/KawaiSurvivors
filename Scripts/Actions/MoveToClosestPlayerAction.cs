using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public partial class MoveToClosestPlayerAction : GameAction
{
    [Export] private CharacterBodyComponent2D _characterBodyComponent = null;
    [Export] private PlayerRefComponent _playerRefComponent = null;
    [Export] private VelocityComponent _velocityComponent = null;
    
    private Vector2 TargetPosition { get; set; }
    private Vector2 CurrentPosition { get; set; }


    public void Execute()
    {
        var targetPosition = _playerRefComponent
            .Player
            .GetComponent<CharacterBodyComponent2D>()
            .Body.GlobalPosition;

        var currentPosition = _characterBodyComponent.Body.GlobalPosition;
        
        
        _velocityComponent.Direction = (targetPosition - currentPosition).Normalized();
    }
}