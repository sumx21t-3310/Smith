namespace NebusokuDev.ShooterWeaponSystem.Core.Sequence.FireMode
{
    public interface IFireMode
    {
        bool Evaluate(bool input);
    }
}