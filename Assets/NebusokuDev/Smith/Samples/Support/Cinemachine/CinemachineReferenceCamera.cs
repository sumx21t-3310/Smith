using Cinemachine;
using NebusokuDev.Smith.Runtime.Camera;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.Support.Cinemachine
{
    public class CinemachineReferenceCamera : ReferenceCameraBase
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera _inFocusVirtualCamera;

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

        public override float FovScale
        {
            get => _fovScale;
            set => _fovScale = Mathf.Abs(value);
        }

        private float _fovScale = 1f;

        public override Vector3 Center => _inFocusVirtualCamera.State.RawPosition;
        public override Quaternion Rotation => _inFocusVirtualCamera.State.RawOrientation;

        private void LateUpdate() => InFocusVirtualCamera.m_Lens.FieldOfView = FieldOfView * FovScale;
    }
}