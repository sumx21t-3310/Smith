using NebusokuDev.Smith.Runtime.Camera;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Input
{
    public class LegacyMouseCameraInput : MonoBehaviour, ICameraInput
    {
        public static Vector2 Sensitivity = Vector2.one * .1f;

        [SerializeField] private string verticalAxisName = "Mouse X";
        [SerializeField] private string horizontalAxisName = "Mouse Y";

        public float Horizontal => UnityEngine.Input.GetAxisRaw(verticalAxisName) * Sensitivity.x * Mathf.Deg2Rad /
                                   Time.deltaTime;

        public float Vertical => UnityEngine.Input.GetAxisRaw(horizontalAxisName) * Sensitivity.y * Mathf.Deg2Rad /
                                 Time.deltaTime;
    }
}