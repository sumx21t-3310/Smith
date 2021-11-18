using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    public class ScreenSpaceIdentityMuzzle : IMuzzle
    {
        public Vector3 Position => Vector3.zero;
        public Vector3 Direction => Vector3.zero;
        public Quaternion Rotation => Quaternion.identity;


        public void Defuse(IPlayerState playerState, IWeaponContext weaponContext) { }
    }
}