using NebusokuDev.ShooterWeaponSystem.Core.Input.Legacy;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Sample.Script.Mover
{
    public class KeyboardMoverInput : MonoBehaviour, IMoverInput
    {
        [SerializeField] private InputKeys forward = new InputKeys(KeyCode.W);
        [SerializeField] private InputKeys backward = new InputKeys(KeyCode.S);
        [SerializeField] private InputKeys left = new InputKeys(KeyCode.A);
        [SerializeField] private InputKeys right = new InputKeys(KeyCode.D);
        [SerializeField] private InputKeys jump = new InputKeys(KeyCode.Space);
        [SerializeField] private InputKeys crouch = new InputKeys(KeyCode.LeftControl);

        public Vector3 Direction => new Vector3(Horizontal, 0f, Vertical);

        public float Vertical
        {
            get
            {
                if (forward.IsAnyKeyPressed) return 1f;
                if (backward.IsAnyKeyPressed) return -1f;

                return 0f;
            }
        }

        public float Horizontal
        {
            get
            {
                if (left.IsAnyKeyPressed) return -1f;
                if (right.IsAnyKeyPressed) return 1f;

                return 0f;
            }
        }

        public bool IsJump => jump.IsAnyKeyPressed;
        public bool IsCrouch => crouch.IsAnyKeyPressed;
    }
}