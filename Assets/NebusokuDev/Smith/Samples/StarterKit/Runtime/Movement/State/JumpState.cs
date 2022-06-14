using System;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    [Serializable]
    public class JumpState : IMoverState
    {
        [SerializeField] private float jumpHeight = 1f;
        [SerializeField] private float gravity = -9.81f;

        public void OnEnter(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input)
        {
            fallVelocity = CharacterMovementHelper.Jump(Vector3.up, jumpHeight, gravity);
        }

        public void OnUpdate(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }

        public void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }
    }
}