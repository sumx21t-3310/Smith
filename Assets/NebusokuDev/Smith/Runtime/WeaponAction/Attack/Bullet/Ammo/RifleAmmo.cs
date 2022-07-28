using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.DamageValidation;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.Ammo
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    [AddComponentMenu("WeaponSystem/RifleAmmo")]
    public class RifleAmmo : ProjectileAmmo
    {
        [SerializeField] private DamageProfile damageProfile;
        private Rigidbody _rigidbody;
        private Vector3 _startPosition;
        public override IObjectPermission ObjectPermission { get; set; }
        public override IObjectIdentity ObjectGroup { get; set; }


        public override void AddForce(Vector3 force)
        {
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            _rigidbody.AddForce(force, ForceMode.VelocityChange);
        }


        protected override void OnHitObject(UnityEngine.Collision target)
        {
            if (target.collider.TryGetComponent(out IHitBox damageable) == false) return;

            var distance = Mathf.Abs(Vector3.Distance(target.transform.position, _startPosition));


            if (damageable.ObjectIdentity.SelfId == ObjectGroup.SelfId && ObjectPermission.SelfDamage)
            {
                damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType, distance));
            }

            if (damageable.ObjectIdentity.TeamId == ObjectGroup.TeamId && ObjectPermission.TeamDamage)
            {
                damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType, distance));
            }

            if (damageable.ObjectIdentity.TeamId != ObjectGroup.TeamId && ObjectPermission.EnemyDamage)
            {
                damageable.AddDamage(damageProfile.GetDamage(damageable.BodyType, distance));
            }
        }


        private void Awake() => _rigidbody = GetComponent<Rigidbody>();


        private void OnEnable()
        {
            _startPosition = transform.position;
            _rigidbody.Sleep();
        }
    }
}