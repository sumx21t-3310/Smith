using UnityEngine;
using static UnityEngine.Mathf;

namespace NebusokuDev.ShooterWeaponSystem.Runtime.Camera
{
    [RequireComponent(typeof(UnityEngine.Camera))]
    public class ReferenceCamera : ReferenceCameraBase
    {
        private UnityEngine.Camera _camera;
        private void Awake() => _camera = GetComponent<UnityEngine.Camera>();

        private void OnEnable() => Locator<ReferenceCameraBase>.Instance.Bind(this);

        private void OnDisable() => Locator<ReferenceCameraBase>.Instance.Unbind(this);

        public override float FovScale
        {
            get => _fovMultiple;
            set => _fovMultiple = Abs(value);
        }

        private float _fovMultiple = 1f;

        private void LateUpdate() => _camera.fieldOfView = FovScale * FieldOfView;

        public override UnityEngine.Camera Camera => _camera;

        public override Transform Center => transform;
    }
}