using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.HitScanner
{
    [Serializable, AddTypeMenu("Sphere")]
    public class SphereHitScanner : IHitScanner
    {
        [SerializeField] private float distance = 1000f;
        [SerializeField] private float radius = .01f;
        [SerializeField] private LayerMask collisionLayer = -1;


        public bool Scan(Ray ray, out RaycastHit hit)
        {
            return Physics.SphereCast(ray, radius, out hit, distance, collisionLayer);
        }
    }
}