namespace NebusokuDev.Smith.Runtime.State.Weapon
{
    public interface IWeaponContext
    {
        int ShotCount { get; set; }
        bool IsAim { get; set; }

        void Reset();
    }
}