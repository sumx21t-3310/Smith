using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.Ammo
{
    public class ExplosionAmmo : ProjectileAmmo
    {
        public override IObjectPermission ObjectPermission { get; set; }
        public override IObjectGroup ObjectGroup { get; set; }

        public override void AddForce(Vector3 force)
        {
        }

        protected override void OnHitObject(UnityEngine.Collision target)
        {
        }
    }
}