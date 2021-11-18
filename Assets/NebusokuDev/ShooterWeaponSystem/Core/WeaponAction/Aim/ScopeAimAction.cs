using System;
using System.Collections.Generic;
using NebusokuDev.ShooterWeaponSystem.Core.Camera;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.Sequence.FireMode;
using NebusokuDev.ShooterWeaponSystem.Core.Sequence.Timer;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Aim
{
    [Serializable, AddTypeMenu("Aim/ScopeAim")]
    public class ScopeAimAction : IWeaponAction
    {
        [SerializeField] private ScopeCameraBase scopeCamera;
        [SerializeField] private Transform hipPosition;
        [SerializeField] private Transform aimPosition;
        [SerializeField] private List<float> fovScales;
        [SerializeField] private float duration = .2f;
        [SerializeField] private SecondBasedTimer scopedTime;

        public UnityEvent onAimIn;
        public UnityEvent onAimOut;

        private SemiAuto _singleClick = new SemiAuto();
        private Transform _parent;
        private int _fovScaleIndex = 0;
        private IWeaponContext _weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _parent = parent;
            _parent.localPosition = hipPosition.localPosition;
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            // move position
            var position = isAction ? aimPosition.localPosition : hipPosition.localPosition;
            _parent.localPosition = Vector3.Slerp(_parent.localPosition, -position, Time.deltaTime / duration);


            scopeCamera.IsActive = scopedTime.IsOverTime;

            if (scopeCamera.IsActive) { onAimIn.Invoke(); }
            else { onAimOut.Invoke(); }

            // scoped time
            if (isAction == false)
            {
                scopedTime.Lap();

                return;
            }

            scopeCamera.FieldOfView = ReferenceCameraBase.FieldOfView * fovScales[_fovScaleIndex];
            scopedTime.Update();
        }


        public void AltAction(bool isAltAction, IPlayerState playerState)
        {
            if (_weaponContext.IsAim == false) return;
            if (_singleClick.Evaluate(isAltAction) == false) return;

            _fovScaleIndex = ++_fovScaleIndex % fovScales.Count;
        }


        public void OnHolster() { }


        public void OnDraw() { }
    }
}