namespace NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon
{
    public interface IWeaponContext
    {
        int ShotCount { get; set; }
        bool IsAim { get; set; }

        void Reset();
    }
}