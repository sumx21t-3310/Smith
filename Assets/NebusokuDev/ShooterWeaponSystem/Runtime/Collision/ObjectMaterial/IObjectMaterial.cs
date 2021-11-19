using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Collision.ObjectMaterial
{
    public interface IObjectMaterial
    {
        public string GetMaterial(Vector3 position);
    }
}