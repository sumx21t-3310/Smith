namespace NebusokuDev.ShooterWeaponSystem.Runtime.Input.Legacy
{
    public interface IInputButton
    {
        bool IsPressDown { get; }

        bool IsPressUp { get; }

        bool IsPressed { get; }
    }
}