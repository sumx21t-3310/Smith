using NebusokuDev.ShooterWeaponSystem.Core.State.Player;


namespace NebusokuDev.ShooterWeaponSystem.Core.Weapon
{
    public interface IItem
    {
        public void PickUp(IPlayerState playerState);


        public void Drop(IPlayerState playerState);
    }
}