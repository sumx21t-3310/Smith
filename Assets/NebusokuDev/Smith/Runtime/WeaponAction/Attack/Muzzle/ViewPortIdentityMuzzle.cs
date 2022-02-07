using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("ViewPortIdentity")]
    public class ViewPortIdentityMuzzle : IMuzzle
    {
        public virtual Vector3 Position => Locator<IReferenceCamera>.Instance.Current.Center;
        public virtual Vector3 Direction => Rotation * Vector3.forward;
        public Quaternion Rotation => Locator<IReferenceCamera>.Instance.Current.Rotation;

        public virtual void Reset()
        {
        }

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
        }
    }
}