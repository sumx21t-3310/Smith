using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    public class SimpleStateMover : StateMoverBase
    {
        [SerializeField] private MoveState moveState;
        [SerializeField] private MoveState fallState;
        [SerializeField] private JumpState jumpState;


        protected override IMoverState GetState(IMoverInput input, bool isGrounded)
        {
            Debug.Log($"isGrounded: {isGrounded}");

            if (isGrounded == false) return fallState;

            if (input.IsJump) return jumpState;

            return moveState;
        }
    }
}