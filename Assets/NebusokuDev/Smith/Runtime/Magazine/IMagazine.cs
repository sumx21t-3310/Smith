using NebusokuDev.Smith.Runtime.Domain.AmmoHolder;

namespace NebusokuDev.Smith.Runtime.Domain.Magazine
{
    public interface IMagazine
    {
        public IAmmoHolder AmmoHolder { get; set; }
        public uint Capacity { get; }
        public uint Reaming { get; }
        public bool UseAmmo(uint useAmount);
        public bool IsReloading { get; }


        public void Reload();
        public void ReloadCancel();
    }
}