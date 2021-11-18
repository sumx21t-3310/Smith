using NebusokuDev.ShooterWeaponSystem.Core.Collision;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.WeaponAction.Attack.Bullet
{
    public interface IBullet
    {
        void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup objectGroup);
    }
}