using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.HitScanner
{
    [Serializable, AddTypeMenu("Line")]
    public class LineHitScanner : IHitScanner
    {
        [SerializeField] private float distance = 1000f;
        [SerializeField] private LayerMask collisionLayer = -1;


        public bool Scan(Ray ray, out RaycastHit hit) => Physics.Raycast(ray, out hit, distance, collisionLayer);
    }
}