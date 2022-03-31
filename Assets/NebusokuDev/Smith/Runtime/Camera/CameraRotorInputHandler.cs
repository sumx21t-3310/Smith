using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public class CameraRotorInputHandler : MonoBehaviour
    {
        private ICameraRotor _cameraRotor;
        private ICameraInput _cameraInput;

        private void Start()
        {
            _cameraRotor = GetComponent<ICameraRotor>();
            _cameraInput = GetComponent<ICameraInput>();
        }

        private void Update()
        {
            _cameraRotor.HorizontalInput += _cameraInput.Horizontal;
            _cameraRotor.VerticalInput += _cameraInput.Vertical;
        }
    }
}