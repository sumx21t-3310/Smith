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


        protected override void Awake()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        public override Vector3 Center => _virtualCamera.State.RawPosition;
        public override Quaternion Rotation => _virtualCamera.State.RawOrientation;


        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var virtualFov in VirtualFov)
            {
                fovScale *= virtualFov.Value;
            }

            _virtualCamera.m_Lens.FieldOfView = BaseFieldOfView * fovScale;
        }
    }
}