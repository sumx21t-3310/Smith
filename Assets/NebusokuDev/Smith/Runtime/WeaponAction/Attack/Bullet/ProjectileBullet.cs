using System;
using NebusokuDev.Smith.Runtime.Collision;
using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Dependency.ObjectPool;
using NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.Ammo;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("Projectile")]
    public class ProjectileBullet : IBullet
    {
        [SerializeField] private float bulletSpeed = 500f;
        [SerializeField] private ProjectileAmmo ammo;
        private IObjectPool<ProjectileAmmo> _ammoPool;
        
        public void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup group)
        {
            _ammoPool ??= Locator<IObjectPoolFactory>.Instance.Current.CreatePool(ammo, 10);

            var fireAmmo = _ammoPool.GetObject();
            fireAmmo.transform.position = position;
            fireAmmo.gameObject.SetActive(true);
            fireAmmo.ObjectGroup = group;
            fireAmmo.ObjectPermission = permission;
            fireAmmo.AddForce(direction * bulletSpeed);
        }
    }
}