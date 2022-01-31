using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation.KickbackAnimation
{
    public abstract class KickbackBase : ScriptableObject
    {
        public abstract (Vector3 position, Vector3 rotate) this[int index] { get; }
    }
}