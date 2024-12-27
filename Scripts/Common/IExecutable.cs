namespace KawaiSurvivor.Scripts.Common;


/// <summary>
/// Base class for all type of executable class
/// </summary>
///
/// <derivedBy>
/// <see cref="Action"/>
/// </derivedBy>
public abstract partial class Executable : Policy
{
    public bool CanExecute
    {
        get => IsSatisfied;
        protected set => IsSatisfied = value;
    }
}