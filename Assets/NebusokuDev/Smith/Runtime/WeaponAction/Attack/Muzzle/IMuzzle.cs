using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    public interface IMuzzle
    {
        Vector3 Position { get; }
        Vector3 Direction { get; }

        Quaternion Rotation { get; }

        void Defuse(IPlayerState playerState, IWeaponContext weaponContext);
    }
}