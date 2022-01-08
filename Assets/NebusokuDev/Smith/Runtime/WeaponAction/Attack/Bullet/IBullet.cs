using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    public interface IBullet
    {
        void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup objectGroup);
    }
}