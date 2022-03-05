using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public interface IReferenceCamera
    {
        public float FovScale { get; set; }

        public Vector3 Center { get; }
        public Quaternion Rotation { get; }
    }
}