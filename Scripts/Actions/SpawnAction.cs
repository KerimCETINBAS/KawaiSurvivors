using Godot;
using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Actions;

public partial class SpawnAction : GameAction
{
    [Export] private Sprite2D _sequenceRenderer;
    [Export] private Sprite2D _characterRenderer;
    [Export] private SpawnSequenceComponent _spawnSequenceComponent;
    
    private Tween _tween;

    public new ActionStatus ActionStatus = ActionStatus.Waiting;
    public override void _Ready()
    {
        CanExecute =  
            ActionStatus != (ActionStatus.Running);
        _tween = CreateTween();
        
    }

    public void Execute()
    {
        if (!CanExecute) return;
        ActionStatus = ActionStatus.Running;
        _characterRenderer.Hide();
        _sequenceRenderer.Show();
        
        PlayTween();
    }

    private void PlayTween()
    {
        var scale = _sequenceRenderer.GetScale();
        _tween.SetParallel(true);
        _tween.TweenProperty(
                _sequenceRenderer,
                "scale",
                scale * 2,
                .7f
            )
            .FromCurrent()
            .SetEase(Tween.EaseType.InOut);
        _tween.Chain().TweenProperty(
                _sequenceRenderer,
                "scale",
                scale,
                .7f
            ).SetEase(Tween.EaseType.InOut);

        _tween.SetLoops(3).Finished += HandleTweenFinished;
    }

    private void HandleTweenFinished()
    {
        _characterRenderer.Show(); 
        IsSatisfied = true;
        _spawnSequenceComponent.SpawnSequenceFinished = true;
        _sequenceRenderer.QueueFree();
        ActionStatus = ActionStatus.Completed;
    }
}