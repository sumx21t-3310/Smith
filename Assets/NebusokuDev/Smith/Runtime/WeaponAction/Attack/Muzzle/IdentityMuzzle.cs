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
        [SerializeField] protected float minDistance = .5f;
        [SerializeField] protected bool isAlignCameraCenter = true;
        [SerializeField] protected float alignDirection = 75f;
        public virtual Vector3 Position => shotPoint.position;
        public virtual Vector3 Direction => shotPoint.forward;
        public virtual Quaternion Rotation => shotPoint.rotation;

        public virtual void Reset()
        {
        }

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            AlignCameraCenter();
        }

        protected virtual void AlignCameraCenter()
        {
            if (isAlignCameraCenter == false)
            {
                shotPoint.localRotation = Quaternion.Euler(Vector3.zero);

                return;
            }

            var refCam = Locator<IReferenceCamera>.Instance.Current;

            if (refCam == null) return;

            var ray = new Ray(refCam.Center, refCam.Rotation * Vector3.forward);


            if (Physics.Raycast(ray, out var hit) && hit.distance > minDistance)
            {
                shotPoint.forward = (hit.point - shotPoint.position).normalized;
            }
            else
            {
                shotPoint.forward = (ray.GetPoint(alignDirection) - shotPoint.position).normalized;
            }
        }
    }
}