using System;
using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Samples.StarterKit.Mover.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    public sealed class Mover : MonoBehaviour, IPlayerState
    {
        [SerializeField] private Transform rotateReference;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float groundFriction = 20f;

        [SerializeField] private CharacterHeight height;
        [SerializeField] private CharacterSpeed characterSpeed;

        [SerializeField] private float accel = 10f;
        [SerializeField] private float jumpHeight = 1.5f;
        [SerializeField] private float minMoveMagnitude = .5f;
        [SerializeField] private float groundDistance;
        [SerializeField] private LayerMask groundLayer = -1;

        private CharacterController _controller;
        private IMoverInput _input;

        public bool IsGrounded
        {
            get
            {
                if (_controller == null) return false;

                var radius = _controller.radius;
                var centerHeight = _controller.height / 2f - radius + groundDistance;
                var position = _controller.transform.position - Vector3.up * centerHeight;

                return Physics.CheckSphere(position, _controller.radius, groundLayer);
            }
        }

        public Vector3 Velocity => _moveVelocity + _fallVelocity;

        private void Start()
        {
            _input = GetComponent<IMoverInput>();
            _controller = GetComponent<CharacterController>();

            if (rotateReference == null) rotateReference = transform;
        }

        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;


        private void Update()
        {
            var speed = characterSpeed.CalcSpeed(_input.IsSprint, _input.IsCrouch, IsGrounded);
            var wishDirection = rotateReference.rotation * _input.Direction.normalized;

            wishDirection = Vector3.ProjectOnPlane(wishDirection, Vector3.up);

            _fallVelocity = FallGravity(_fallVelocity, IsGrounded);
            _fallVelocity = Jump(_fallVelocity, IsGrounded, _input.IsJump);

            if (IsGrounded) _moveVelocity = Friction(_moveVelocity);
            _moveVelocity = Accelerate(_moveVelocity, wishDirection, speed);

            _controller.height = height.CalcHeight(_controller.height, _input.IsCrouch);


            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }

        private Vector3 Jump(Vector3 velocity, bool isGrounded, bool isJump)
        {
            if ((isJump && isGrounded) == false) return velocity;

            return velocity + Vector3.up * Mathf.Sqrt(-2f * gravity * jumpHeight);
        }

        private Vector3 FallGravity(Vector3 velocity, bool isGrounded)
        {
            if (isGrounded) return Vector3.zero;

            return velocity + Vector3.up * gravity * Time.deltaTime;
        }

        private Vector3 Friction(Vector3 velocity) => velocity - velocity * Time.deltaTime * groundFriction;


        // I referred to quake movement
        // https://github.com/id-Software/Quake/blob/bf4ac424ce754894ac8f1dae6a3981954bc9852d/WinQuake/sv_user.c#L190
        private Vector3 Accelerate(Vector3 velocity, Vector3 wishDirection, float wishSpeed)
        {
            var currentSpeed = Vector3.Dot(velocity, wishDirection);

            var addSpeed = wishSpeed - currentSpeed;
            var accelSpeed = wishSpeed * Time.deltaTime * accel;

            if (accelSpeed > addSpeed) accelSpeed = addSpeed;

            return velocity + wishDirection * accelSpeed;
        }


        public PlayerMovementContext Context
        {
            get
            {
                if (IsGrounded == false) return PlayerMovementContext.Air;

                if (_input.IsSprint) return PlayerMovementContext.Sprint;

                if (_input.IsCrouch) return PlayerMovementContext.Crouch;
                if (_moveVelocity.magnitude > minMoveMagnitude) return PlayerMovementContext.Walk;

                return PlayerMovementContext.Rest;
            }
        }

        private void OnDrawGizmos()
        {
            if (_controller == null)
            {
                if (TryGetComponent(out _controller) == false)
                    _controller = gameObject.AddComponent<CharacterController>();
            }

            var radius = _controller.radius;
            var centerHeight = _controller.height / 2f - radius + groundDistance;
            var position = _controller.transform.position - Vector3.up * centerHeight;

            Gizmos.DrawWireSphere(position, radius);
        }
    }

    [Serializable]
    public class CharacterSpeed
    {
        [SerializeField] private float crouchSpeed = 3.5f;
        [SerializeField] private float walkSpeed = 7f;
        [SerializeField] private float sprintSpeed = 20f;
        [SerializeField] private float airSpeed = 10f;

        public float CalcSpeed(bool isSprint, bool isCrouch, bool isGrounded)
        {
            if (isGrounded == false) return airSpeed;
            if (isSprint) return sprintSpeed;
            if (isCrouch) return crouchSpeed;
            return walkSpeed;
        }
    }

    [Serializable]
    public class CharacterHeight
    {
        [SerializeField] private float crouchHeight = 1.2f;
        [SerializeField] private float standHeight = 2f;
        [SerializeField] private float switchTime = 0.05f;

        public float CalcHeight(float current, bool isCrouch)
        {
            var toHeight = isCrouch ? crouchHeight : standHeight;
            return Mathf.SmoothStep(current, toHeight, Time.deltaTime / switchTime);
        }
    }
}