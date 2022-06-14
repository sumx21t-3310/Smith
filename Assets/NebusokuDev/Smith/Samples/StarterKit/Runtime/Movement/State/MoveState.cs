using System;
using UnityEngine;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State
{
    [Serializable]
    public class MoveState : IMoverState
    {
        [SerializeField] private Transform directionReference;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float friction = 5f;
        [SerializeField] private float accel = 7f;
        [SerializeField] private float characterHeight = 2f;
        [SerializeField] private bool clampDirection;
        [SerializeField] private bool resetGravity = true;

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


            fallVelocity += Vector3.up * gravity * Time.deltaTime;

            moveVelocity = CharacterControllerHelper.Friction(moveVelocity, friction);

            // moveVelocity = CharacterMovementHelper.Accelerate(moveVelocity, direction, speed, accel);

            height = characterHeight;
        }

        public void OnExit(ref Vector3 moveVelocity, ref Vector3 fallVelocity, ref float height, bool isGrounded,
            IMoverInput input) { }
    }
}