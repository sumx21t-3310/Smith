using Cinemachine;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.Support.Cinemachine
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CinemachineVirtualReferenceCamera : ReferenceCameraBase
    {
        [SerializeField] private Camera mainCamera;
        private CinemachineVirtualCamera _virtualCamera;
        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);

        private void Awake() => _virtualCamera = GetComponent<CinemachineVirtualCamera>();

        public override float FovScale
        {
            get => _fovScale;
            set => _fovScale = Mathf.Abs(value);
        }

        private float _fovScale = 1f;

        public override Camera Camera => mainCamera;
        public override Vector3 Center => _virtualCamera.State.RawPosition;
        public override Quaternion Rotation => _virtualCamera.State.RawOrientation;

        private void LateUpdate() => _virtualCamera.m_Lens.FieldOfView = FieldOfView * FovScale;
    }
}