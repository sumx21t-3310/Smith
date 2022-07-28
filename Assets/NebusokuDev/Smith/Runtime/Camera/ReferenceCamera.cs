using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class ReferenceCamera : ReferenceCameraBase
    {
        private UnityEngine.Camera _camera;

        protected override void Awake()
        {
            base.Awake();
            _camera = GetComponent<UnityEngine.Camera>();
        }

        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var virtualFov in VirtualFov) fovScale *= virtualFov.Value;

            _camera.fieldOfView = fovScale * BaseFieldOfView;
        }


        public override Vector3 Center => transform.position;
        public override Quaternion Rotation => transform.rotation;
    }
}