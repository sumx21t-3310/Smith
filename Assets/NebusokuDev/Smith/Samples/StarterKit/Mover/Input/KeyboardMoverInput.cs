using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover.Input
{
    public class KeyboardMoverInput : MonoBehaviour, IMoverInput
    {
        [SerializeReference, SubclassSelector] private IInputButton _forward = new InputKeyButton(KeyCode.W);
        [SerializeReference, SubclassSelector] private IInputButton _backward = new InputKeyButton(KeyCode.S);
        [SerializeReference, SubclassSelector] private IInputButton left = new InputKeyButton(KeyCode.A);
        [SerializeReference, SubclassSelector] private IInputButton right = new InputKeyButton(KeyCode.D);
        [SerializeReference, SubclassSelector] private IInputButton jump = new InputKeyButton(KeyCode.Space);
        [SerializeReference, SubclassSelector] private IInputButton crouch = new InputKeyButton(KeyCode.LeftControl);
        [SerializeReference, SubclassSelector] private IInputButton sprint = new InputKeyButton(KeyCode.LeftShift);

        public Vector3 Direction => new Vector3(Horizontal, 0f, Vertical);

        public float Vertical
        {
            get
            {
                if (_forward.IsPressed) return 1f;
                if (_backward.IsPressed) return -1f;

                return 0f;
            }
        }

        public bool IsSprint => sprint.IsPressed;

        public float Horizontal
        {
            get
            {
                if (left.IsPressed) return -1f;
                if (right.IsPressed) return 1f;

                return 0f;
            }
        }

        public bool IsJump => jump.IsPressDown;
        public bool IsCrouch => crouch.IsPressed;
    }
}