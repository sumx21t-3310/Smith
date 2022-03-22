using System;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("NoneWait")]
    public class NoneWaitTimer : IRpmTimer
    {
        public bool IsOverTime => true;
        public void Update() { }

        public void Reset() { }

        public void Lap() { }
    }
}