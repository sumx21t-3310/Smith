using System;
using NebusokuDev.Smith.Runtime.State.Weapon;

namespace NebusokuDev.Smith.Runtime.Recoil
{
    [Serializable]
    public abstract class RecoilBase : IRecoil
    {
        public abstract void Reset();

        public abstract void Generate(IWeaponContext context);
        public abstract void Easing();
    }
}