using NebusokuDev.ShooterWeaponSystem.Runtime.Collision;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Bullet
{
    public interface IBullet
    {
        void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup objectGroup);
    }
}