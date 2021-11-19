using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Recoil
{
    [Serializable]
    public abstract class RecoilBase : IRecoil
    {
        public abstract void Reset();

        public abstract void Generate();

        public abstract void Easing();
    }
}