using System;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Identity")]
    public class IdentityMuzzle : IMuzzle
    {
        [SerializeField] protected Transform shotPoint;
        public Vector3 Position => shotPoint.position;
        public Vector3 Direction => shotPoint.forward;
        public Quaternion Rotation => shotPoint.rotation;

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext) { }
    }
}