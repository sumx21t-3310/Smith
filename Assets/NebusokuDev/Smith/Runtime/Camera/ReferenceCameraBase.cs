using System.Collections.Generic;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public abstract class ReferenceCameraBase : MonoBehaviour, IReferenceCamera
    {
        public static FieldOfView FieldOfView
        {
            get => _fieldOfView;
        }

        private static FieldOfView _fieldOfView = new FieldOfView {Horizontal = 103f};
        

        public abstract Vector3 Center { get; }

        public abstract Quaternion Rotation { get; }
        public abstract IDictionary<object, float> VirtualFov { get; }
    }
}