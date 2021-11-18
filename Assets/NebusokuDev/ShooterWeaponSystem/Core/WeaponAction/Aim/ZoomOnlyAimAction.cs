using System;
using NebusokuDev.ShooterWeaponSystem.Core.Camera;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Mathf;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Aim
{
    /// <summary>
    /// ズームのみのアクションです。
    /// TPSのエイム動作を実現できます。
    /// </summary>
    [Serializable, AddTypeMenu("Aim/Zoom")]
    public class ZoomOnlyAimAction : IWeaponAction
    {
        [SerializeField, Range(0f, 10f)] private float[] zoomScaleList = {.9f};
        [SerializeField] private float duration = .1f;
        [SerializeField] private bool useAimFlag = true;
        public UnityEvent onZoomIn;
        public UnityEvent onZoomOut;
        private IWeaponContext _weaponContext;

        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext) =>
                _weaponContext = weaponContext;


        public void Action(bool isAction, IPlayerState playerState)
        {
            _weaponContext.IsAim = isAction && useAimFlag;
            var toFov = isAction ? zoomScaleList[0] : 1f;
            var fromFov = Locator<ReferenceCameraBase>.Instance.Current.FovScale;
            Locator<ReferenceCameraBase>.Instance.Current.FovScale = Lerp(fromFov, toFov, Time.deltaTime / duration);

            if (isAction) onZoomIn.Invoke();
            else onZoomOut.Invoke();
        }


        public void AltAction(bool isAltAction, IPlayerState playerState)
        {
            
        }

        public void OnHolster() { }


        public void OnDraw() { }
    }
}