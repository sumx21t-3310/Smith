using NebusokuDev.Smith.Runtime.State.Player;
using UnityEngine;

namespace NebusokuDev.Smith.Sample.Script.Mover
{
    public class Mover : MonoBehaviour, IPlayerState
    {
        [SerializeField] private Transform rotateReference;
        [SerializeField] private float walkSpeed = 10f;
        [SerializeField] private float sprintSpeed = 15f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float dumpTime = .1f;
        [SerializeField] private float crouchHeight = 1.4f;
        [SerializeField] private float standHeight = 2f;
        [SerializeField] private Transform checkGroundPosition;
        [SerializeField] private LayerMask checkMask = -1;

        private bool IsGrounded
        {
            get
            {
                return Physics.CheckSphere(checkGroundPosition.position - Vector3.down * .1f, _controller.radius,
                    checkMask);
            }
        }

        private CharacterController _controller;
        private IMoverInput _input;

        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;

        private void Awake()
        {
            _input = GetComponent<IMoverInput>();
            _controller = GetComponent<CharacterController>();

            if (rotateReference == null) rotateReference = transform;
        }

        private void Update()
        {
            var direction = rotateReference.rotation * _input.Direction;

            direction = Vector3.ProjectOnPlane(direction, Vector3.up);
            var speed = _input.IsSprint ? sprintSpeed : walkSpeed;

            _controller.height = Mathf.Lerp(_controller.height, _input.IsCrouch ? crouchHeight : standHeight,
                Time.deltaTime / .1f);

            _fallVelocity += Vector3.up * (gravity * Time.deltaTime);

            if (IsGrounded)
            {
                _moveVelocity += (direction * speed - _moveVelocity) * (Time.deltaTime / dumpTime);
                _fallVelocity = Vector3.down;
                if (_input.IsJump)
                {
                    _fallVelocity = Vector3.up * Mathf.Sqrt(-gravity * 2f * jumpHeight);
                }
            }

            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);

            Context = UpdatePlayerMovementContext();
        }

        private PlayerMovementContext UpdatePlayerMovementContext()
        {
            if (IsGrounded == false) return PlayerMovementContext.Air;
            if (_input.IsCrouch) return PlayerMovementContext.Crouch;
            if (_input.IsSprint) return PlayerMovementContext.Sprint;
            if (_moveVelocity.sqrMagnitude > Mathf.Epsilon) return PlayerMovementContext.Walk;

            return PlayerMovementContext.Rest;
        }

        public PlayerMovementContext Context { get; private set; }
    }
}