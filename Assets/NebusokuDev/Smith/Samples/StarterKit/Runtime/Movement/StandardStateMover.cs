using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public class StandardStateMover : StateMoverBase
    {
        [SerializeField] private MoveState moveState = new MoveState();
        [SerializeField] private MoveState fallState = new MoveState();
        [SerializeField] private JumpState jumpState = new JumpState();


        protected override IMoverState GetState(IMoverInput input, bool isGrounded)
        {
            if (isGrounded == false) return fallState;

            if (input.IsJump) return jumpState;

            return moveState;
        }
    }
}