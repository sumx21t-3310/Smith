using System.Collections.Generic;
using Cinemachine;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.CinemachineSupport
{
    public class CinemachineReferenceCamera : ReferenceCameraBase
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera _inFocusVirtualCamera;

        private IDictionary<object, float> _virtualFov;

        private void Awake() => _brain = GetComponent<CinemachineBrain>();

        private CinemachineVirtualCamera InFocusVirtualCamera
        {
            get
            {
                if (ReferenceEquals(_inFocusVirtualCamera, _brain.ActiveVirtualCamera) && _inFocusVirtualCamera != null)
                {
                    return _inFocusVirtualCamera;
                }

                var activeCamera = _brain.ActiveVirtualCamera.VirtualCameraGameObject;
                _inFocusVirtualCamera = activeCamera.GetComponent<CinemachineVirtualCamera>();

                return _inFocusVirtualCamera;
            }
        }

        private void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        private void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);
        

        public override Vector3 Center => _inFocusVirtualCamera.State.RawPosition;
        public override Quaternion Rotation => _inFocusVirtualCamera.State.RawOrientation;
        public override IDictionary<object, float> VirtualFov => _virtualFov;

        private void Start() => _virtualFov = new Dictionary<object, float>();

        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var fov in _virtualFov) fovScale *= fov.Value;


            InFocusVirtualCamera.m_Lens.FieldOfView = FieldOfView.Vertical * fovScale;
        }
    }
}