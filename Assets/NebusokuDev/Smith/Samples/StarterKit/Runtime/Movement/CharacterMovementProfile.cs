using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    [CreateAssetMenu(menuName = "Smith/Samples/Mover/" + nameof(CharacterMovementProfile))]
    public class CharacterMovementProfile : ScriptableObject
    {
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 1.5f;
        [SerializeField] private CharacterSpeed walkSpeed;
        [SerializeField] private CharacterSpeed sprintSpeed;
        [SerializeField] private CharacterSpeed crouchSpeed;
        [SerializeField] private CharacterSpeed airSpeed;

        public float Gravity => gravity;
        public float JumpHeight => jumpHeight;

        public CharacterSpeed this[bool isGrounded, bool isCrouch, bool isSprint]
        {
            get
            {
                if (isGrounded == false) return airSpeed;
                if (isSprint) return sprintSpeed;
                if (isCrouch) return crouchSpeed;

                return walkSpeed;
            }
        }
    }
}