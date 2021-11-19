using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.WeaponAction.Aim
{
    public abstract class SightBase : MonoBehaviour
    {
        public abstract Transform AimPoint { get; }
        public abstract float ZoomMultiples { get; }
    }
}