using UnityEngine;

namespace NebusokuDev.Smith.Runtime.WeaponAction.Aim
{
    public abstract class SightBase : MonoBehaviour
    {
        public abstract Transform AimPoint { get; }
        public abstract float ZoomMultiples { get; }
    }
}