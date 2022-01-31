using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Recoil.RecoilProfile
{
    public abstract class RecoilPatternProfileBase : ScriptableObject
    {
        public abstract Vector2 this[int index] { get; }
        
        public abstract float Duration { get; }
    }
}