using System;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode
{
    [Serializable, AddTypeMenu("FullAuto")]
    public class FullAuto : IFireMode
    {
        public bool Evaluate(bool input) => input;
    }
}