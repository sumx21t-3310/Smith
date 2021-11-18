using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Collision.ObjectMaterial
{
    public interface IObjectMaterial
    {
        public string GetMaterial(Vector3 position);
    }
}