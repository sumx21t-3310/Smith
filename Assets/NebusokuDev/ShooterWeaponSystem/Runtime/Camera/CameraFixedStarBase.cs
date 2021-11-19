using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.Camera
{
    public abstract class CameraFixedStarBase : MonoBehaviour, ICameraFixedStar
    {
        public abstract float VerticalInput { get; set; }
        public abstract float VerticalOffset { get; set; }
        public abstract float HorizontalInput { get; set; }
        public abstract float HorizontalOffset { get; set; }
    }
}