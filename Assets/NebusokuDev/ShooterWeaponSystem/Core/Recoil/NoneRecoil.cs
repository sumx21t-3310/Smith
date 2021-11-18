using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.Recoil
{
    [Serializable, AddTypeMenu("None")]
    public class NoneRecoil : IRecoil
    {
        void IRecoil.Reset() { }

        void IRecoil.Generate() { }

        void IRecoil.Easing() { }
    }
}