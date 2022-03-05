using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;
using static UnityEngine.Mathf;

namespace NebusokuDev.Smith.Runtime.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class ReferenceCamera : ReferenceCameraBase
    {
        private UnityEngine.Camera _camera;
        private void Awake() => _camera = GetComponent<UnityEngine.Camera>();

        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);

        public override float FovScale
        {
            get => _fovMultiple;
            set => _fovMultiple = Abs(value);
        }

        private float _fovMultiple = 1f;

        private void LateUpdate() => _camera.fieldOfView = FovScale * FieldOfView;

        public override Vector3 Center => transform.position;
        public override Quaternion Rotation => transform.rotation;
    }
}