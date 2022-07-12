using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation.BobbingAnimation
{
    public abstract class WeaponBobbingProfileBase : ScriptableObject
    {
        public abstract (Vector3 rotation, Vector3 position) this[float time] { get; }
    }
}