namespace NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.Timer
{
    public interface IRpmTimer
    {
        public bool IsOverTime { get; }
        public void Update();
        public void Reset();
        public void Lap();
    }
}