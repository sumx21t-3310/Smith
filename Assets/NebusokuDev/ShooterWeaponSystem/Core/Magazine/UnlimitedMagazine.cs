using System;
using System.Collections;
using NebusokuDev.ShooterWeaponSystem.Core.AmmoHolder;


namespace NebusokuDev.ShooterWeaponSystem.Core.Magazine
{
    [Serializable, AddTypeMenu("Unlimited")]
    public class UnlimitedMagazine : IMagazine
    {
        public IAmmoHolder AmmoHolder { get; set; }
        public uint Capacity => uint.MaxValue;
        public uint Reaming => AmmoHolder.Remaining;
        public bool UseAmmo(uint useAmount) => AmmoHolder.GetAmmo(useAmount) > 0;
        public bool IsReloading => false;

        public IEnumerator Reload()
        {
            yield break;
        }
    }
}