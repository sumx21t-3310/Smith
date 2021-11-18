using System.Collections;
using NebusokuDev.ShooterWeaponSystem.Core.Collision;
using UnityEngine;
using UnityEngine.Events;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Bullet.Ammo
{
    public class ExplosionAmmo : ProjectileAmmo
    {
        [SerializeField] private float explosionRadius = 2.5f;
        [SerializeField] private float explosionTime = .5f;
        [SerializeField] private float explosionForce = 100f;
        [SerializeField] private LayerMask collisionMask = Physics.AllLayers;
        [SerializeField] private bool isSticky;
        [SerializeField] private BulletDamageProfile damageProfile;
        private Rigidbody _rigidbody;

        public UnityEvent onExplosion;
        private Transform _self;

        private WaitForSeconds _seconds;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _self = transform;
        }


        public override IObjectPermission ObjectPermission { get; set; }
        public override IObjectGroup ObjectGroup { get; set; }

        public override void AddForce(Vector3 force) => _rigidbody.AddForce(force, ForceMode.VelocityChange);


        protected override void OnHitObject(UnityEngine.Collision target)
        {
            StartCoroutine(Explosion());

            if (isSticky)
            {
                _self.parent = target.transform;
                _rigidbody.Sleep();
            }
        }


        private IEnumerator Explosion()
        {
            yield return _seconds ??= new WaitForSeconds(explosionTime);


            var colliders = Physics.OverlapSphere(_self.position, explosionRadius, collisionMask);

            foreach (var col in colliders)
            {
                if (col.TryGetComponent(out IHitBox damageable))
                {
                    if (damageable.ObjectGroup.SelfId == ObjectGroup.SelfId && ObjectPermission.SelfDamage)
                    {
                        damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType));
                    }

                    if (damageable.ObjectGroup.GroupId == ObjectGroup.GroupId && ObjectPermission.TeamDamage)
                    {
                        damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType));
                    }

                    if (damageable.ObjectGroup.GroupId != ObjectGroup.GroupId && ObjectPermission.EnemyDamage)
                    {
                        damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType));
                    }
                }

                if (col.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, _self.position, explosionRadius);
                }
            }

            onExplosion.Invoke();
        }


        private void OnDrawGizmos() => Gizmos.DrawWireSphere(_self.position, explosionRadius);
    }
}