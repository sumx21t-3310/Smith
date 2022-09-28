using System;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Domain.Magazine;
using NebusokuDev.Smith.Runtime.Sequence.FireMode;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Runtime.State.Weapon;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Mathf;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Aim
{
    /// <summary>
    /// ズームのみのアクションです。
    /// TPSのエイム動作を実現できます。
    /// </summary>
    [Serializable, AddTypeMenu("Aim/Zoom")]
    public class ZoomOnlyAimAction : IWeaponAction
    {
        [SerializeField, Range(0f, 10f)] private float[] zoomScales = {.9f};
        [SerializeField] private float duration = .1f;
        [SerializeField] private bool useAimFlag = true;
        private int _zoomIndex;

        public UnityEvent onZoomIn;
        public UnityEvent onZoomOut;
        private IWeaponContext _weaponContext;
        private IFireMode _mode = new SemiAuto();


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _weaponContext = weaponContext;
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            _weaponContext.IsAim = isAction && useAimFlag;
            var toFov = isAction ? zoomScales[_zoomIndex] : 1f;
            var referenceCamera = Locator<IReferenceCamera>.Instance.Current;


            if (referenceCamera.VirtualFov.ContainsKey(this) == false) referenceCamera.VirtualFov[this] = 1f;


            var fromFov = referenceCamera.VirtualFov[this];
            referenceCamera.VirtualFov[this] = Lerp(fromFov, toFov, Time.deltaTime / duration);

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