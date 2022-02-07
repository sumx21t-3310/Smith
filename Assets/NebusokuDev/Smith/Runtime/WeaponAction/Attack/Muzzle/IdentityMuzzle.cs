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
            if (isAlignCameraCenter == false) return;

            var refCam = Locator<IReferenceCamera>.Instance.Current;

            if (refCam == null) return;
            var camera = refCam.Camera;

            var ray = camera.ViewportPointToRay(Vector2.one / 2f);


            if (Physics.Raycast(ray, out var hit))
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