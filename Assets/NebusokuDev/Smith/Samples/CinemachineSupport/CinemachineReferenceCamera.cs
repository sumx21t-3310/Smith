using Cinemachine;
using NebusokuDev.Smith.Runtime.Camera;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.CinemachineSupport
{
    [RequireComponent(typeof(CinemachineBrain))]
    public class CinemachineReferenceCamera : ReferenceCameraBase
    {
        private CinemachineBrain _brain;
        private CinemachineVirtualCamera _currentFocusVirtualCamera;

        protected override void Awake()
        {
            base.Awake();
            _brain = GetComponent<CinemachineBrain>();
        }

        private CinemachineVirtualCamera CurrentFocusVirtualCamera
        {
            get
            {
                if (ReferenceEquals(_currentFocusVirtualCamera, _brain.ActiveVirtualCamera) && _currentFocusVirtualCamera != null)
                {
                    return _currentFocusVirtualCamera;
                }

                var activeCamera = _brain.ActiveVirtualCamera.VirtualCameraGameObject;
                _currentFocusVirtualCamera = activeCamera.GetComponent<CinemachineVirtualCamera>();

                return _currentFocusVirtualCamera;
            }
        }

        public override Vector3 Center => _currentFocusVirtualCamera.State.RawPosition;
        public override Quaternion Rotation => _currentFocusVirtualCamera.State.RawOrientation;

        private void LateUpdate()
        {
            var fovScale = 1f;

            foreach (var fov in VirtualFov) fovScale *= fov.Value;


            CurrentFocusVirtualCamera.m_Lens.FieldOfView = BaseFieldOfView * fovScale;
        }
    }
}