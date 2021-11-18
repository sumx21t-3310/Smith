using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.Recoil
{
    [Serializable]
    public abstract class RecoilBase : IRecoil
    {
        public abstract void Reset();

        public abstract void Generate();

        public abstract void Easing();
    }
}