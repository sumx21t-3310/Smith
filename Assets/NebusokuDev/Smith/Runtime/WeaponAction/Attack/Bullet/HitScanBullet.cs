using System;
using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Physics;


namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("HitScan")]
    public class HitScanBullet : IBullet
    {
        [SerializeField] private BulletDamageProfile bulletDamageProfile;
        [SerializeField] private float hitRadius = .025f;
        [SerializeField] private float bulletImpactPower = 10f;
        [SerializeField] private LayerMask collisionLayer = AllLayers;

        /// <summary>
        /// onShot.Invoke(hit, position, direction);
        /// </summary>
        public UnityEvent<RaycastHit, Ray> onShot;
        public UnityEvent<RaycastHit> onSelfHit;
        public UnityEvent<RaycastHit> onFriendlyHit;
        public UnityEvent<RaycastHit> onEnemyHit;

        public void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup group)
        {
            var ray = new Ray(position, direction);

            if (SphereCast(ray, hitRadius, out RaycastHit hit, bulletDamageProfile.MaxDistance, collisionLayer)
                == false)
            {
                onShot.Invoke(hit, ray);
                return;
            }
            
            onShot.Invoke(hit, ray);


            var distance = hit.distance;

            if (hit.collider.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddForce(-hit.normal * (bulletImpactPower * bulletDamageProfile.GetImpact(distance)),
                                   ForceMode.Impulse
                );
            }

            if (group == null || permission == null) return;

            if (hit.collider.TryGetComponent(out IHitBox damageable))
            {
                if (damageable.ObjectGroup.SelfId == group.SelfId)
                {
                    onSelfHit.Invoke(hit);

                    if (permission.SelfDamage)
                    {
                        damageable.AddDamage(bulletDamageProfile.GetDamage(damageable.BodyType, distance));
                    }
                }

                if (damageable.ObjectGroup.GroupId == group.GroupId)
                {
                    onFriendlyHit.Invoke(hit);

                    if (permission.TeamDamage)
                    {
                        damageable.AddDamage(bulletDamageProfile.GetDamage(damageable.BodyType, distance));
                    }
                }

                if (damageable.ObjectGroup.GroupId != group.GroupId)
                {
                    onEnemyHit.Invoke(hit);

                    if (permission.EnemyDamage)
                    {
                        damageable.AddDamage(bulletDamageProfile.GetDamage(damageable.BodyType, distance));
                    }
                }
            }
        }
    }
}