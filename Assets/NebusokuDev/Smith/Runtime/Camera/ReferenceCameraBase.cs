using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public abstract class ReferenceCameraBase : MonoBehaviour, IReferenceCamera
    {
        public static float FieldOfView
        {
            get => _fieldOfView;
            set => _fieldOfView = Mathf.Clamp(Mathf.Abs(value), 0.01f, 170f);
        }

        private static float _fieldOfView = 60f;

        public abstract float FovScale { get; set; }

        public abstract Vector3 Center { get; }

        public abstract Quaternion Rotation { get; }
    }
}