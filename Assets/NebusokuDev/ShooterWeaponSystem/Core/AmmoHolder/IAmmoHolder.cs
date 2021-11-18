namespace NebusokuDev.ShooterWeaponSystem.Core.AmmoHolder
{
    public interface IAmmoHolder
    {
        bool IsEmpty { get; }
        uint Remaining { get; set; }
        uint GetAmmo(uint amount);
    }
}