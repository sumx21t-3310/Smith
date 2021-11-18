using System;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Identity")]
    public class IdentityMuzzle : IMuzzle
    {
        [SerializeField] protected Transform reference;
        public Vector3 Position => reference.position;
        public Vector3 Direction => reference.forward;
        public Quaternion Rotation => reference.rotation;

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext) { }
    }
}