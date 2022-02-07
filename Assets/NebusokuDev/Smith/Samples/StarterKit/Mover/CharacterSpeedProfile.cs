using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    [CreateAssetMenu(menuName = "Smith/Samples/Mover/" + nameof(CharacterSpeedProfile))]
    public class CharacterSpeedProfile : ScriptableObject
    {
        [SerializeField] private CharacterSpeed walkSpeed;
        [SerializeField] private CharacterSpeed sprintSpeed;
        [SerializeField] private CharacterSpeed crouchSpeed;
        [SerializeField] private CharacterSpeed airSpeed;

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