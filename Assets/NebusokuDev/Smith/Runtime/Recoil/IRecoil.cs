using NebusokuDev.Smith.Runtime.State.Weapon;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    public interface IRecoil
    {
        void Reset();
        void Reverse();
        void Generate(IWeaponContext context);
        void Easing();
    }
}