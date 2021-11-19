using System;
using NebusokuDev.ShooterWeaponSystem.Runtime.Collision;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("Blank")]
    public class BlankBullet : IBullet
    {
        public void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup objectGroup)
        {
        #if UNITY_EDITOR
            
        #endif
        }
    }
}