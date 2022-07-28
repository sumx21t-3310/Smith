using NebusokuDev.Smith.Runtime.Camera;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Input
{
    public class LegacyMouseCameraInput : MonoBehaviour, ICameraInput
    {
        [SerializeField] private float sensitivity = 1f;
        [SerializeField] private string verticalAxisName = "Mouse X";
        [SerializeField] private string horizontalAxisName = "Mouse Y";

        public float Horizontal => UnityEngine.Input.GetAxisRaw(verticalAxisName) * sensitivity;

        public float Vertical => UnityEngine.Input.GetAxisRaw(horizontalAxisName) * sensitivity;
    }
}