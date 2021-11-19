using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle
{
    public interface IMuzzle
    {
        Vector3 Position { get; }
        Vector3 Direction { get; }

        Quaternion Rotation { get; }

        void Defuse(IPlayerState playerState, IWeaponContext weaponContext);
    }
}