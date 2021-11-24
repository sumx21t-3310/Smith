using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [Serializable, AddTypeMenu("None")]
    public class NoneRecoil : IRecoil
    {
        void IRecoil.Reset() { }

        void IRecoil.Generate(IWeaponContext context) { }

        void IRecoil.Easing() { }
    }
}