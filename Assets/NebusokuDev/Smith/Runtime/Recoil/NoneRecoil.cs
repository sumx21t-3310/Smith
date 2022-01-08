using System;
using NebusokuDev.Smith.Runtime.State.Weapon;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable, AddTypeMenu("None")]
    public class NoneRecoil : IRecoil
    {
        void IRecoil.Reset() { }

        void IRecoil.Generate(IWeaponContext context) { }

        void IRecoil.Easing() { }
    }
}