using NebusokuDev.Smith.Runtime.Input.Legacy;
using NebusokuDev.Smith.Runtime.Input.Legacy.Button;
using NebusokuDev.Smith.Samples.StarterKit.Mover.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    public class KeyboardMoverInput : MonoBehaviour, IMoverInput
    {
        [SerializeField] private InputButtons forward = new InputButtons(KeyCode.W);
        [SerializeField] private InputButtons backward = new InputButtons(KeyCode.S);
        [SerializeField] private InputButtons left = new InputButtons(KeyCode.A);
        [SerializeField] private InputButtons right = new InputButtons(KeyCode.D);
        [SerializeField] private InputButtons jump = new InputButtons(KeyCode.Space);
        [SerializeField] private InputButtons crouch = new InputButtons(KeyCode.LeftControl);
        [SerializeField] private InputButtons sprint = new InputButtons(KeyCode.LeftShift);

        public Vector3 Direction => new Vector3(Horizontal, 0f, Vertical);

        public float Vertical
        {
            get
            {
                if (forward.IsPressed) return 1f;
                if (backward.IsPressed) return -1f;

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

        public bool IsJump => jump.IsPressed;
        public bool IsCrouch => crouch.IsPressed;
    }
}