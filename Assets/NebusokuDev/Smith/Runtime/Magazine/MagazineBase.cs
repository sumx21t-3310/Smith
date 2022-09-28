using System.Collections;
using NebusokuDev.Smith.Runtime.Domain.AmmoHolder;

namespace NebusokuDev.Smith.Runtime.Domain.Magazine
{
    public abstract class MagazineBase : IMagazine
    {
        public abstract IAmmoHolder AmmoHolder { get; set; }
        public abstract uint Capacity { get; }
        public abstract uint Reaming { get; }
        public abstract bool UseAmmo(uint useAmount);
        public abstract bool IsReloading { get; }
        protected abstract IEnumerator ReloadCoroutine();
        public abstract void Reload();
        public abstract void ReloadCancel();
    }
}