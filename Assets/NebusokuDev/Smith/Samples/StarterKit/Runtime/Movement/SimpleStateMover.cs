using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    public class SimpleStateMover : StateMoverBase
    {
        [SerializeField] private MoveState moveState;
        [SerializeField] private MoveState fallState;
        [SerializeField] private JumpState jumpState;


        protected override IMoverState GetState(IMoverInput input, bool isGrounded)
        {
            if (isGrounded == false) return fallState;

            if (input.IsJump) return jumpState;

            return moveState;
        }
    }
}