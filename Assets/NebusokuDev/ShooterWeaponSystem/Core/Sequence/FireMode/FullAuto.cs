using System;


namespace NebusokuDev.ShooterWeaponSystem.Core.Sequence.FireMode
{
    [Serializable, AddTypeMenu("FullAuto")]
    public class FullAuto : IFireMode
    {
        public bool Evaluate(bool input) => input;
    }
}