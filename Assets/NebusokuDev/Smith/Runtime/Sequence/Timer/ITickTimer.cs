namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    public interface ITickTimer
    {
        public bool IsOverTime { get; }
        public void Update();
        public void Reset();
        public void Lap();
    }
}