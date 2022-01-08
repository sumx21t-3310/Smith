using UnityEngine;

namespace NebusokuDev.Smith.Sample
{
    public class CursorSetter : MonoBehaviour
    {
        private void OnEnable() => Cursor.lockState = CursorLockMode.Locked;


        private void OnDisable() => Cursor.lockState = CursorLockMode.None;
    }
}