using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public abstract class CameraRotorBase : MonoBehaviour, ICameraRotor
    {
        public abstract float VerticalInput { get; set; }
        public abstract float VerticalOffset { get; set; }
        public abstract float HorizontalInput { get; set; }
        public abstract float HorizontalOffset { get; set; }
    }
}