using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Collision.ObjectMaterial
{
    public interface IObjectMaterial
    {
        public string GetMaterial(Vector3 position);
    }
}