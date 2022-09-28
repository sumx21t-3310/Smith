using System;
using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.HitScanner;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("HitScan")]
    public class HitScanBullet : IBullet
    {
        [SerializeField] private DamageProfileBase damageProfile;
        [SerializeReference, SubclassSelector] private IHitScanner _scanner = new SphereHitScanner();

        [SerializeReference, SubclassSelector]
        private IDamageValidator _damageValidator = new StandardObjectValidator();

        /// <summary>
        /// onShot.Invoke(hit, position, direction);
        /// </summary>
        public UnityEvent<RaycastHit, Ray> onShot;

        public void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectIdentity identity)
        {
            var ray = new Ray(position, direction);

            if (_scanner.Scan(ray, out var hit) == false)
            {
                onShot.Invoke(hit, ray);
                return;
            }

            onShot.Invoke(hit, ray);


            var distance = hit.distance;

            if (identity == null || permission == null) return;

            if (!hit.collider.TryGetComponent(out IHitBox damageable)) return;

            if (_damageValidator.CanAddDamage(identity, damageable.ObjectIdentity, permission) == false) return;

            damageable.AddDamage(damageProfile.GetDamage(damageable.HitType, distance));
        }
    }
}