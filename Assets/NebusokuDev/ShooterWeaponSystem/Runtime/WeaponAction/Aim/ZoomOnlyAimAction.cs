using System;
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
    /// ズームのみのアクションです。
    /// TPSのエイム動作を実現できます。
    /// </summary>
    [Serializable, AddTypeMenu("Aim/Zoom")]
    public class ZoomOnlyAimAction : IWeaponAction
    {
        [SerializeField, Range(0f, 10f)] private float[] zoomScales = { .9f };
        [SerializeField] private float duration = .1f;
        [SerializeField] private bool useAimFlag = true;
        private int _zoomIndex;

        public UnityEvent onZoomIn;
        public UnityEvent onZoomOut;
        private IWeaponContext _weaponContext;
        private ReferenceCameraBase _referenceCamera;
        private IFireMode _mode = new SemiAuto();


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _referenceCamera = parent.GetComponentInParent<ReferenceCameraBase>();
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            _weaponContext.IsAim = isAction && useAimFlag;
            var toFov = isAction ? zoomScales[_zoomIndex] : 1f;
            var fromFov = _referenceCamera.FovScale;
            Locator<ReferenceCameraBase>.Instance.Current.FovScale = Lerp(fromFov, toFov, Time.deltaTime / duration);

            if (isAction) onZoomIn.Invoke();
            else onZoomOut.Invoke();
        }


        public void AltAction(bool isAltAction, IPlayerState playerState)
        {
            if (_mode.Evaluate(isAltAction) == false) return;

            _zoomIndex = ++_zoomIndex % zoomScales.Length;
        }


        public void OnHolster() { }


        public void OnDraw() { }
    }
}