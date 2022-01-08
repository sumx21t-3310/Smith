using Cinemachine;
using NebusokuDev.Smith.Runtime;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.CinemachineSupport
{
    public class CinemachineVirtualReferenceCamera : ReferenceCameraBase
    {
        private CinemachineVirtualCamera _virtualCamera;
        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);

        private void Awake()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public override float FovScale
        {
            get => _fovScale;
            set => _fovScale = Mathf.Abs(value);
        }

        private float _fovScale;

        public override Camera Camera { get; }
        public override Transform Center => transform;

        private void LateUpdate() => _virtualCamera.m_Lens.FieldOfView = FieldOfView * FovScale;
    }
}