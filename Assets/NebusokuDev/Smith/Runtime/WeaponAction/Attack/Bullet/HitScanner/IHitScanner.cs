using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Attack.Bullet.HitScanner
{
    public interface IHitScanner
    {
        bool Scan(Ray ray, out RaycastHit hit);
    }
}