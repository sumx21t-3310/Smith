using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;
using static UnityEngine.Mathf;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Aim
{
    /// <summary>
    /// FPS視点でエイムできるようにするアクションです。
    /// </summary>
    [Serializable, AddTypeMenu("Aim/Aim")]
    public class AimAction : IWeaponAction
    {
        [SerializeField, Range(float.Epsilon, 10f)]
        private float duration = .1f;

        [SerializeField, Range(float.Epsilon, 1f)]
        private float fovScale = .8f;

        // [SerializeField] private Sight sights;
        [SerializeField] private Transform aimPosition;
        [SerializeField] private Transform hipPosition;

        private Transform _self;

        private IWeaponContext _weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _self = parent;
            _self.localPosition = -hipPosition.localPosition;
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            _weaponContext.IsAim = isAction;
            var toPosition = isAction ? aimPosition.localPosition : hipPosition.localPosition;
            var toFovScale = isAction ? fovScale : 1f;
            _self.localPosition = Vector3.Slerp(_self.localPosition, -toPosition, Time.deltaTime / duration);
            var referenceCamera = Locator<IReferenceCamera>.Instance.Current;


            if (referenceCamera.VirtualFov.ContainsKey(this) == false) referenceCamera.VirtualFov[this] = 1f;


            var fromFov = referenceCamera.VirtualFov[this];
            referenceCamera.VirtualFov[this] = Lerp(fromFov, toFovScale, Time.deltaTime / duration);
        }


        public void AltAction(bool isAltAction, IPlayerState playerState) { }


        public void OnHolster()
        {
            _weaponContext.IsAim = false;
            _self.localPosition = -hipPosition.localPosition;
        }


        public void OnDraw()
        {
            _weaponContext.IsAim = false;
            _self.localPosition = -hipPosition.localPosition;
        }
    }
}