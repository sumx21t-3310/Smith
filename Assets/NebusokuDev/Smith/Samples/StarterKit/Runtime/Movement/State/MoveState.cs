using System;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using UnityEngine;
using static NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.CharacterControllerHelper;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    [Serializable]
    public class MoveState : IMoverState
    {
        [SerializeField] private Transform directionReference;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float accel = 7f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float friction = 5f;
        [SerializeField] private float characterHeight = 2f;
        [SerializeField] private float duckDuration = .25f;
        [SerializeField] private bool clampDirection = true;
        [SerializeField] private bool resetGravity = true;
        [SerializeField] private bool useGravity = true;

        public void OnEnter(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input)
        {
            if (resetGravity) fallVelocity = Vector3.zero;
        }

        public void OnUpdate(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input)
        {
            var direction = new Vector3(input.Horizontal, 0f, input.Vertical);

            if (directionReference != null)
            {
                direction = directionReference.rotation * direction;

                if (clampDirection) direction = Vector3.ProjectOnPlane(direction, Vector3.up);
            }

            if (useGravity) fallVelocity = Fall(fallVelocity, gravity);

            moveVelocity = Accelerate(moveVelocity, direction, speed, accel);
            moveVelocity = Friction(moveVelocity, friction);

            height = Mathf.Lerp(height, characterHeight, duckDuration);
        }

        public void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }
    }
}