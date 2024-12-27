using KawaiSurvivor.Scripts.Common;
using KawaiSurvivor.Scripts.Components;

namespace KawaiSurvivor.Scripts.Policies;

public partial class EnemyFoundPolicy: Policy
{
    public override void _Ready()
    {
        IsSatisfied = ParentEntity
            .GetComponent<PlayerRefComponent>()
            .Player is not null;
    }

    public override void _Process(double delta)
    {
        if (IsSatisfied) return;
        IsSatisfied = ParentEntity
            .GetComponent<PlayerRefComponent>()
            .Player is not null;
    }
}