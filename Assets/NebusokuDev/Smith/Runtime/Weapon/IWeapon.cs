using NebusokuDev.Smith.Runtime.Domain.AmmoHolder;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Weapon;

namespace NebusokuDev.Smith.Runtime.Weapon
{
    public interface IWeapon
    {
        public IMagazine Magazine { get; }
        public IAmmoHolder AmmoHolder { get; }

        public IWeaponContext Context { get; }

        public void Draw();

        public void Holster();
    }
}