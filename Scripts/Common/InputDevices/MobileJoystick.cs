using Godot;

namespace KawaiSurvivor.Scripts.Common.InputDevices;

public partial class MobileJoystick : Control
{
    [Export] private TextureRect JoystickOutline { get; set; }
    [Export] private TextureRect JoystickThumb { get; set; }
    [Export] private ReferenceRect JoystickArea { get; set; }
    
    
    
    private bool _touchStarted = false;
    private Vector2 _pressPosition;
    private Vector2 _currentPosition;
    public Vector2 JoystickPosition => _currentPosition;
    
    private Vector2 _previousPosition;
    public override void _Ready()
    {
        JoystickOutline.Hide();
        
    }
    
    public override void _Process(double delta)
    {
        JoystickOutline.Position = _pressPosition;
        JoystickThumb.Position = _currentPosition;
    }

    
    
    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventScreenDrag drag && _touchStarted)
        {   
            Vector2 joystickCenterOffset = JoystickOutline.GetRect().Size;
            _currentPosition = ((drag.Position) - _pressPosition - joystickCenterOffset);
            float radius = JoystickOutline.GetRect().Size.X;
            if (_currentPosition.Length() > radius)
            {
                _currentPosition = _currentPosition.Normalized() * radius;
            }
        }

        if (@event is InputEventScreenTouch touch)
        {
           
            if (!_touchStarted && touch.IsPressed())
            {
                if(!JoystickArea.GetGlobalRect().HasPoint(touch.Position)) return;
                Vector2 joystickCenterOffset = JoystickOutline.GetRect().Size ;
                _pressPosition =  touch.Position - joystickCenterOffset;
                _currentPosition = Vector2.Zero;
                _touchStarted = true;
                JoystickOutline.Show();
                SetProcess(true);
                return;
            }

            if (_touchStarted && touch.IsReleased())
            {
                _touchStarted = false;
                _pressPosition = Vector2.Zero;
                _currentPosition = Vector2.Zero;
                SetProcess(false);
                JoystickOutline.Hide();
               
            }
        }
       
    }
    
}
