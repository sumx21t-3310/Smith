using System;
using System.Collections.Generic;
using NebusokuDev.ShooterWeaponSystem.Runtime.Camera;
using NebusokuDev.ShooterWeaponSystem.Runtime.Magazine;
using NebusokuDev.ShooterWeaponSystem.Runtime.Sequence.FireMode;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Player;
using NebusokuDev.ShooterWeaponSystem.Runtime.State.Weapon;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Mathf;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Aim
{
    /// <summary>
    /// FPS視点でエイムできるようにするアクションです。
    /// </summary>
    [Serializable, AddTypeMenu("Aim/Aim")]
    public class AimAction : IWeaponAction
    {
        [SerializeField, Range(Single.Epsilon, 10f)]
        private float duration = .1f;

        [SerializeField] private List<Sight> sights;
        [SerializeField] private Transform hipPosition;
        [SerializeField] private int sightIndex;

        public UnityEvent onAimIn;
        public UnityEvent onAimOut;
        public UnityEvent onZoomChange;
        public UnityEvent onSightChange;

        private IFireMode _singleClick = new SemiAuto();
        private Transform _self;

        private IWeaponContext _weaponContext;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _self = parent;
            _self.localPosition = -hipPosition.localPosition;
            _weaponContext = weaponContext;

            for (int i = 0; i < sights.Count; i++) { sights[i].gameObject.SetActive(i == sightIndex); }
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            duration = Abs(duration);
            _weaponContext.IsAim = isAction;

            if (_weaponContext.IsAim) { onAimIn.Invoke(); }
            else { onAimOut.Invoke(); }

            var currentSight = sights[sightIndex];

            var referenceCamera = Locator<ReferenceCameraBase>.Instance.Current;

            var position = _weaponContext.IsAim ? sights[sightIndex].AimPoint.localPosition : hipPosition.localPosition;

            var to = _weaponContext.IsAim ? sights[sightIndex].ZoomMultiples : 1f;

            var from = referenceCamera.FovScale;

            referenceCamera.FovScale = Lerp(from, to, Time.deltaTime / currentSight.Duration);

            _self.localPosition = Vector3.Slerp(_self.localPosition, -position, Time.deltaTime / currentSight.Duration);
            sightIndex = sightIndex % sights.Count;
        }


        public void AltAction(bool isAltAction, IPlayerState playerState)
        {
            if (_weaponContext.IsAim == false) return;
            if (_singleClick.Evaluate(isAltAction) == false) return;

            sights[sightIndex].FovScaleChange();
            onZoomChange.Invoke();
        }


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


        public void SightChange(int index)
        {
            sightIndex = index % sights.Count;
            onSightChange.Invoke();
            for (int i = 0; i < sights.Count; i++) sights[i].gameObject.SetActive(i == sightIndex);
        }
    }
}