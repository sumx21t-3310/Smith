using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy
{
    public class LegacyMouseCameraInput : MonoBehaviour, ICameraInput
    {
        [SerializeField, Range(0f, 100f)] private float sensitivity = 10f;
        [SerializeField] private string verticalAxisName = "Mouse X";
        [SerializeField] private string horizontalAxisName = "Mouse Y";

        public float Horizontal => UnityEngine.Input.GetAxisRaw(verticalAxisName) * sensitivity;
        public float Vertical => UnityEngine.Input.GetAxisRaw(horizontalAxisName) * sensitivity;
    }
}