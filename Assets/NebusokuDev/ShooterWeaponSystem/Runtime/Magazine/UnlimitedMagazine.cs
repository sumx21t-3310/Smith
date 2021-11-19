using System;
using System.Collections;
using NebusokuDev.ShooterWeaponSystem.Runtime.AmmoHolder;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Magazine
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