using System.Collections;
using NebusokuDev.ShooterWeaponSystem.Core.AmmoHolder;


namespace NebusokuDev.ShooterWeaponSystem.Core.Magazine
{
    public interface IMagazine
    {
        public IAmmoHolder AmmoHolder { get; set; }
        public uint Capacity { get; }
        public uint Reaming { get; }
        public bool UseAmmo(uint useAmount);
        public bool IsReloading { get; }
        public IEnumerator Reload();
    }
}