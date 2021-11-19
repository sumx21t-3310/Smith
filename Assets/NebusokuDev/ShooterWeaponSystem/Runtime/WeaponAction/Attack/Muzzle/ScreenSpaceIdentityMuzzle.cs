using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Muzzle
{
    public class ScreenSpaceIdentityMuzzle : IMuzzle
    {
        public Vector3 Position => Vector3.zero;
        public Vector3 Direction => Vector3.zero;
        public Quaternion Rotation => Quaternion.identity;


        public void Defuse(IPlayerState playerState, IWeaponContext weaponContext) { }
    }
}