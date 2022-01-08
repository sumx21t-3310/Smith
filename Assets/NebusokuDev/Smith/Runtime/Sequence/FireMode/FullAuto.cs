using System;

namespace NebusokuDev.Smith.Runtime.Sequence.FireMode
{
    [Serializable, AddTypeMenu("FullAuto")]
    public class FullAuto : IFireMode
    {
        public bool Evaluate(bool input) => input;
    }
}