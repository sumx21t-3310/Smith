using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet
{
    [Serializable, AddTypeMenu("Sphere")]
    public class SphereHitScanner : IHitScanner
    {
        [SerializeField] private float radius = .01f;

        public bool Scan(Ray ray, out RaycastHit hit)
        {
            return Physics.SphereCast(ray, radius, out hit);
        }
    }
}