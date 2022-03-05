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
        public virtual Vector3 Position => SavedPosition;
        public virtual Vector3 Direction => SavedDirection;
        public Quaternion Rotation => SavedRotation;

        protected Vector3 SavedDirection;
        protected Vector3 SavedPosition;
        protected Quaternion SavedRotation;


        public virtual void Reset()
        {
        }

        public virtual void Defuse(IPlayerState playerState, IWeaponContext weaponContext)
        {
            var referenceCamera = Locator<IReferenceCamera>.Instance.Current;
            SavedRotation = referenceCamera.Rotation;
            SavedPosition = referenceCamera.Center;
            SavedDirection = Rotation * Vector3.forward;
        }
    }
}