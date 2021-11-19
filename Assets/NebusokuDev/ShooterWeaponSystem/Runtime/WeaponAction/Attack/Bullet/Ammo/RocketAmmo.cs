using NebusokuDev.ShooterWeaponSystem.Runtime.Collision;
using UnityEngine;
using Random = UnityEngine.Random;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Bullet.Ammo
{
    public class RocketAmmo : ProjectileAmmo
    {
        [SerializeField] private float range = 1;
        public override IObjectPermission ObjectPermission { get; set; }
        public override IObjectGroup ObjectGroup { get; set; }

        private Vector3 _savedForce;
        private Rigidbody _rigidbody;


        public override void AddForce(Vector3 force)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _savedForce = force;
            _rigidbody.velocity = _savedForce;
        }


        private void FixedUpdate()
        {
            _rigidbody.useGravity = false;
            transform.forward = _rigidbody.velocity.normalized;
            _rigidbody.AddForce(Vector3.ProjectOnPlane(Random.insideUnitSphere,transform.forward) * range);
        }


        protected override void OnHitObject(UnityEngine.Collision target) { }
    }
}