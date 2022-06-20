using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    public interface IMoverState
    {
        void OnEnter(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input);

        void OnUpdate(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input);

        void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input);
    }
}