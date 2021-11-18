using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    public interface IMuzzle
    {
        Vector3 Position { get; }
        Vector3 Direction { get; }

        Quaternion Rotation { get; }

        void Defuse(IPlayerState playerState, IWeaponContext weaponContext);
    }
}