namespace NebusokuDev.ShooterWeaponSystem.Core.Sequence.Timer
{
    public class NoneWaitTimer : IRpmTimer
    {
        public bool IsOverTime => true;
        public void Update() { }

        public void Reset() { }

        public void Lap() { }
    }
}