using System;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    [Serializable]
    public class JumpState : IMoverState
    {
        public void OnEnter(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }

        public void OnUpdate(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }

        public void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }
    }
}