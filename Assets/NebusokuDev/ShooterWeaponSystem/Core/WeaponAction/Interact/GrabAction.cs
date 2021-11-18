using System;
using NebusokuDev.ShooterWeaponSystem.Core.Magazine;
using NebusokuDev.ShooterWeaponSystem.Core.State.Player;
using NebusokuDev.ShooterWeaponSystem.Core.State.Weapon;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Interact
{
    [Serializable, AddTypeMenu("Position")]
    public class GrabAction : IWeaponAction
    {
        [SerializeField] private Transform reference;
        [SerializeField] private float searchDistance = 5f;
        [SerializeField] private float gravDistance = 2f;
        [SerializeField] private float radius = .2f;
        private UnityEngine.Camera _camera;


        public void Injection(Transform parent, IMagazine magazine, IWeaponContext weaponContext)
        {
            _camera = parent.GetComponentInParent<UnityEngine.Camera>();
        }


        public void Action(bool isAction, IPlayerState playerState)
        {
            var ray = new Ray(reference.position, reference.forward);

            if (isAction == false) return;

            if (Physics.SphereCast(ray, radius, out var hit, searchDistance))
            {
                var camCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, gravDistance);
                var toWorld = _camera.ScreenToWorldPoint(camCenter);

                if (hit.transform.TryGetComponent(out ICanGrab grab) == false) return;

                grab.Grab(toWorld, reference.forward);
            }
        }


        public void AltAction(bool isAltAction, IPlayerState playerState) { }


        public void OnHolster() { }


        public void OnDraw() { }
    }
}