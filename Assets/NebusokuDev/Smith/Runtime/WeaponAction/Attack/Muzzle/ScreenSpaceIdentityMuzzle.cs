using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    public class ScreenSpaceIdentityMuzzle : IMuzzle
    {
        public Vector3 Position => Vector3.zero;
        public Vector3 Direction => Vector3.zero;
        public Quaternion Rotation => Quaternion.identity;


        public void Defuse(IPlayerState playerState, IWeaponContext weaponContext) { }
    }
}