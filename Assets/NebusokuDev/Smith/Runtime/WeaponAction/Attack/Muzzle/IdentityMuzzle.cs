using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Muzzle
{
    [Serializable, AddTypeMenu("Identity")]
    public class IdentityMuzzle : IMuzzle
    {
        [SerializeField] protected Transform shotPoint;
        public virtual Vector3 Position => shotPoint.position;
        public virtual Vector3 Direction => shotPoint.forward;
        public virtual Quaternion Rotation => shotPoint.rotation;

        public virtual void Reset()
        {
        }

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            var camera = Locator<IReferenceCamera>.Instance.Current;

            Debug.DrawRay(camera.Center, camera.Rotation * Vector3.forward * 1000f, Color.red);
        }
    }
}