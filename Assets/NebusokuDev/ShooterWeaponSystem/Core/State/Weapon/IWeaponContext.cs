namespace NebusokuDev.ShooterWeaponSystem.Core.State.Weapon
{
    public interface IWeaponContext
    {
        int ShotCount { get; set; }
        bool IsAim { get; set; }

        void Reset();
    }
}