using Godot;

namespace KawaiSurvivor.Scripts.Common;


/// <summary>
/// <see cref="GameAction"/> are high level executables
/// </summary>
[Tool]
[GlobalClass]
public abstract partial class GameAction : Executable
{
    [Signal] public delegate void OnActionStatusChangedEventHandler(ActionStatus status);
    [Signal] public delegate void OnActionCanExecuteEventHandler();

   
    
    private ActionStatus _actionStatus = ActionStatus.Waiting;
    public ActionStatus ActionStatus
    {
        get => _actionStatus;
        protected set
        {
            _actionStatus = value;
            EmitSignal(nameof(OnActionStatusChanged), (int)value);
        }
    }


    public void Execute(params object[] args) {}
}