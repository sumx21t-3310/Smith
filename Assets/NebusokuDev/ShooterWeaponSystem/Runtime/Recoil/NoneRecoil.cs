using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [Serializable, AddTypeMenu("None")]
    public class NoneRecoil : IRecoil
    {
        void IRecoil.Reset() { }

        void IRecoil.Generate() { }

        void IRecoil.Easing() { }
    }
}