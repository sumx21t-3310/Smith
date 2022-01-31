using System;
using NebusokuDev.Smith.Runtime.Collision;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("Blank")]
    public class BlankBullet : IBullet
    {
        public void Shot(Vector3 position, Vector3 direction, IObjectPermission permission, IObjectGroup objectGroup)
        {
        #if UNITY_EDITOR
            Debug.Log("Shot!");
        #endif
        }
    }
}