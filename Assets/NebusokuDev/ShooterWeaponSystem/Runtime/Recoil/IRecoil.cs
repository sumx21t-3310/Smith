
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    public interface IRecoil
    {
        void Reset();
        void Generate(IWeaponContext context);
        void Easing();
    }
}
