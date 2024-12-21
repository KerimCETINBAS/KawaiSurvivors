using Godot;

namespace KawaiSurvivor.Scripts.Misc;

public partial class MobileJoystick : Control
{
    [Signal] public delegate void OnJoystickMovementEventHandler(Vector2 direction);
    [Export] private TextureRect JoystickOutline { get; set; }
    [Export] private TextureRect JoystickThumb { get; set; }
    [Export] private ReferenceRect JoystickArea { get; set; }
    
    
    private bool _touchStarted = false;
    private Vector2 PressPosition { get; set; }  = Vector2.Zero;
    private Vector2 CurrentPosition { get; set; } = Vector2.Zero;
    private Vector2 JoystickCenterOffset => JoystickOutline.GetRect().Size;
    private float JoystickOutlineRadius => JoystickOutline.GetRect().Size.X;
    
    
    private bool TouchStarted
    {
        get => _touchStarted;
        set
        {
            _touchStarted = value;
            if (value) JoystickOutline.Show();
            else JoystickOutline.Hide();
            SetProcess(value);
        }
    }

    public override void _Ready()
    {
        JoystickOutline.Hide();
    }
    public override void _Process(double delta)
    {
        JoystickOutline.Position = PressPosition;
        JoystickThumb.Position = CurrentPosition;
    }
    public override void _Input(InputEvent @event)
    {
        HandleScreenDrag(@event);
        HandleScreenTouch(@event);
    }
    
    private bool IsInRadius() => CurrentPosition.Length() > JoystickOutlineRadius;

    private void HandleScreenDrag(InputEvent @event)
    {
        if (@event is InputEventScreenDrag drag && TouchStarted)
        {   
            CurrentPosition = ((drag.Position) - PressPosition - JoystickCenterOffset);
            if (IsInRadius())  CurrentPosition = CurrentPosition.Normalized() * JoystickOutlineRadius;
            EmitSignal(SignalName.OnJoystickMovement, CurrentPosition.Normalized());
        }
    }

    private void HandleScreenTouch(InputEvent @event)
    {
        if (@event is InputEventScreenTouch touch)
        {
            if (!TouchStarted && touch.IsPressed())
            {
                if(!JoystickArea.GetGlobalRect().HasPoint(touch.Position)) return;
                PressPosition =  touch.Position - JoystickCenterOffset;
                EmitSignal(SignalName.OnJoystickMovement, CurrentPosition);
                TouchStarted = true;
                return;
            }

            if (TouchStarted && touch.IsReleased())
            {
                TouchStarted = false;
                PressPosition = Vector2.Zero;
                CurrentPosition = Vector2.Zero;
                EmitSignal(SignalName.OnJoystickMovement, CurrentPosition);
            }
        }
    }
}