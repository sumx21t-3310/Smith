using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [Serializable]
    public abstract class RecoilBase : IRecoil
    {
        public abstract void Reset();

        public abstract void Generate(IWeaponContext context);
        public abstract void Easing();
    }
}