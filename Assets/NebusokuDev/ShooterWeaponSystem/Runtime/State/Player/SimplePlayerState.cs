using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Runtime.State.Player
{
    public class SimplePlayerState : MonoBehaviour, IPlayerState
    {
        public bool IsMove { get; set; } = false;
        public bool IsGrounded { get; set; } = false;
        public bool IsSprint { get; set; } = false;
        public bool IsCrouch { get; set; } = false;

        public PlayerMovementContext Context
        {
            get
            {
                if (IsGrounded == false) return PlayerMovementContext.Air;
                if (IsSprint == false) return PlayerMovementContext.Sprint;
                if (IsMove) return PlayerMovementContext.Walk;
                if (IsCrouch) return PlayerMovementContext.Crouch;

                return PlayerMovementContext.Rest;
            }
        }

        public bool IsAiming { get; set; }
    }
}