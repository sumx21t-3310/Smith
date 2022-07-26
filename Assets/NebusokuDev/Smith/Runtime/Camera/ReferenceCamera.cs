using System.Collections.Generic;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class ReferenceCamera : ReferenceCameraBase
    {
        private UnityEngine.Camera _camera;

        private Dictionary<object, float> _virtualFov;

        private void Awake()
        {
            _virtualFov = new Dictionary<object, float>();

            _camera = GetComponent<UnityEngine.Camera>();
        }

        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);


        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var virtualFov in _virtualFov)
            {
                fovScale *= virtualFov.Value;
            }

            _camera.fieldOfView = fovScale * FieldOfView.Vertical;
        }

        public override Vector3 Center => transform.position;
        public override Quaternion Rotation => transform.rotation;
        public override IDictionary<object, float> VirtualFov => _virtualFov;
    }
}