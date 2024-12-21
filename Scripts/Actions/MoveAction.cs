using Godot;
using KawaiSurvivor.Scripts.Behaviors;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;


public partial class MoveAction : Node
{   
    [ExportGroup("Required Items")]
    // Velocity Component that holds velocity information
    [Export] private VelocityComponent VelocityComponent { get; set; }
    
    // Entity to move
    [Export] private CharacterBody2D CharacterBody { get; set; }

    public override void _Ready()
    {
        // subscibe on velocity changed event to update character velocity
        VelocityComponent.OnVelocityChange += OnVelocityChanged;
    }

    
    // move the entity with virtual joystick input
    public void UseMobileJoystick(Misc.MobileJoystick joystick)
    {
        joystick.OnJoystickMovement += OnDirectionChanged;
    }

    // move the entity to the closest player
    public void UseMoveClosestPlayer(FindClosestPlayerBehavior closestPlayerBehavior)
    {
        closestPlayerBehavior.OnClosestPlayerDirectionChanged += OnDirectionChanged;
        
    }
    
    // move character based on updated velocity
    public override void _Process(double delta)
    {
        CharacterBody.MoveAndSlide();
        
    }
    
    // When mobilejoystick's thumb position changes
    // Update velocity
    private void OnDirectionChanged(Vector2 direction)
    {
        VelocityComponent.Accelerate(direction);
    }

    
    // set character velocity
    // when velocity component emits
    // OnVelocityChange event
    private void OnVelocityChanged(Vector2 velocity)
    {
        CharacterBody.Velocity = velocity;
    }
}