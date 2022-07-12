using System.Collections.Generic;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public interface IReferenceCamera
    {


        public Vector3 Center { get; }
        public Quaternion Rotation { get; }

        public IDictionary<object, float> VirtualFov { get; }
    }
}