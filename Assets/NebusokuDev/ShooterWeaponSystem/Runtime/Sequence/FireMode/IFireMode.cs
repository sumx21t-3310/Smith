namespace NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode
{
    public interface IFireMode
    {
        bool Evaluate(bool input);
    }
}