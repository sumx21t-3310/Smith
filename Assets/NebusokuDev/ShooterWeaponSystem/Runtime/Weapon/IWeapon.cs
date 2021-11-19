using NebusokuDev.ShooterWeaponSystem.Runtime.AmmoHolder;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Weapon
{
    public interface IWeapon
    {
        public IMagazine Magazine { get; }
        public IAmmoHolder AmmoHolder { get; }

        public IWeaponContext Context { get; }
    }
}