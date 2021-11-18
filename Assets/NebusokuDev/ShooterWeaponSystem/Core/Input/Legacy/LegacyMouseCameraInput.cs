using NebusokuDev.ShooterWeaponSystem.Core.Camera;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Input.Legacy
{
    public class LegacyMouseCameraInput : MonoBehaviour, ICameraInput
    {
        [SerializeField, Range(0f, 100f)] private float sensitivity = 10f;
        [SerializeField] private string verticalAxisName = "Mouse X";
        [SerializeField] private string horizontalAxisName = "Mouse Y";

        public float Horizontal => UnityEngine.Input.GetAxisRaw(verticalAxisName) * Mathf.Deg2Rad * sensitivity;
        public float Vertical => UnityEngine.Input.GetAxisRaw(horizontalAxisName) * Mathf.Deg2Rad * sensitivity;
    }
}