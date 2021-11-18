namespace NebusokuDev.ShooterWeaponSystem.Core.State.Weapon
{
    public class WeaponContext : IWeaponContext
    {
        public bool IsAim { get; set; }


        public void Reset()
        {
            IsAim = false;
            ShotCount = 0;
        }


        public int ShotCount { get; set; }
    }
}