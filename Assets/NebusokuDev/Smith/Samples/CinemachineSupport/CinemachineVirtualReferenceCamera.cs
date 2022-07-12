using System.Collections.Generic;
using Cinemachine;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.CinemachineSupport
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CinemachineVirtualReferenceCamera : ReferenceCameraBase
    {
        private CinemachineVirtualCamera _virtualCamera;

        private IDictionary<object, float> _virtualFov;

        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);

        private void Awake()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _virtualFov ??= new Dictionary<object, float>();
        }


        public override Vector3 Center => _virtualCamera.State.RawPosition;
        public override Quaternion Rotation => _virtualCamera.State.RawOrientation;

        public override IDictionary<object, float> VirtualFov => _virtualFov;

        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var virtualFov in _virtualFov)
            {
                fovScale *= virtualFov.Value;
            }

            _virtualCamera.m_Lens.FieldOfView = FieldOfView.Vertical * fovScale;
        }
    }
}