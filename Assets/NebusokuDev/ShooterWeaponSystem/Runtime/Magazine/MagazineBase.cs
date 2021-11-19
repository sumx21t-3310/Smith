using System.Collections;
using NebusokuDev.ShooterWeaponSystem.Runtime.AmmoHolder;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Magazine
{
    public abstract class MagazineBase : IMagazine
    {
        public UnityEvent<uint> onReamingChange;
        
        public abstract IAmmoHolder AmmoHolder { get; set; }
        public abstract uint Capacity { get; }
        public abstract uint Reaming { get; }
        public abstract bool UseAmmo(uint useAmount);
        public abstract bool IsReloading { get; }
        public abstract IEnumerator Reload();
    }
}