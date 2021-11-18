using NebusokuDev.ShooterWeaponSystem.Core.AmmoHolder;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;


namespace NebusokuDev.ShooterWeaponSystem.Core.Weapon
{
    public interface IWeapon : IItem
    {
        public IMagazine Magazine { get; }
        public IAmmoHolder AmmoHolder { get; }

        public IWeaponContext Context { get; }

        public void Draw(IPlayerState playerState);

        public void Holster(IPlayerState playerState);


    }
}