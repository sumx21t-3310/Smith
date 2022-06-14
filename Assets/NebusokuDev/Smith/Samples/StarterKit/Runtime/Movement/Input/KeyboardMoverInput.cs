using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public class KeyboardMoverInput : MonoBehaviour, IMoverInput
    {
        public float Vertical => UnityEngine.Input.GetAxisRaw("Vertical");
        public float Horizontal => UnityEngine.Input.GetAxisRaw("Horizontal");
        public bool IsJump => UnityEngine.Input.GetKey(KeyCode.Space);

        public bool IsCrouch => UnityEngine.Input.GetKey(KeyCode.LeftControl);
        public bool IsSprint => UnityEngine.Input.GetKey(KeyCode.LeftShift);
    }
}