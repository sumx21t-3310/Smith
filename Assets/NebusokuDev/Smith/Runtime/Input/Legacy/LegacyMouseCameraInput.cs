using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Input.Legacy
{
    public class LegacyMouseCameraInput : MonoBehaviour, ICameraInput
    {
        [SerializeField] private string verticalAxisName = "Mouse X";
        [SerializeField] private string horizontalAxisName = "Mouse Y";

        public float Horizontal => UnityEngine.Input.GetAxisRaw(verticalAxisName) *
            Locator<LegacyMouseSensitivity>.Instance.Current.Value.x * Mathf.Deg2Rad / Time.deltaTime;

        public float Vertical => UnityEngine.Input.GetAxisRaw(horizontalAxisName) *
            Locator<LegacyMouseSensitivity>.Instance.Current.Value.x * Mathf.Deg2Rad / Time.deltaTime;
    }
}