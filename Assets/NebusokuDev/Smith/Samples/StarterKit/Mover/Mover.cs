using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Samples.StarterKit.Mover.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Mover
{
    public sealed class Mover : MonoBehaviour, IPlayerState
    {
        [SerializeField] private Transform rotateReference;
        [SerializeField] private float gravity = -9.81f;

        [SerializeField] private CharacterHeight height;
        [SerializeField] private CharacterSpeedProfile speedProfile;
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
            var characterSpeed = speedProfile[IsGrounded, _input.IsCrouch, _input.IsSprint];
            var wishDirection = rotateReference.rotation * _input.Direction.normalized;

            wishDirection = Vector3.ProjectOnPlane(wishDirection, Vector3.up);

            _fallVelocity = FallGravity(_fallVelocity, IsGrounded);
            _fallVelocity = Jump(_fallVelocity, IsGrounded, _input.IsJump);

            _moveVelocity = Friction(_moveVelocity, characterSpeed.Friction);
            _moveVelocity = Accelerate(_moveVelocity, wishDirection, characterSpeed.Speed, characterSpeed.Accel);

            _controller.height = height.CalcHeight(_controller.height, _input.IsCrouch);

            var ray = new Ray(transform.position + wishDirection * Time.deltaTime, Vector3.down);


            if (Physics.Raycast(ray, out var hit) && IsGrounded)
            {
                _moveVelocity = Vector3.ProjectOnPlane(_moveVelocity, hit.normal);
            }

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

        private Vector3 Friction(Vector3 velocity, float friction) => velocity - velocity * Time.deltaTime * friction;


        // I referred to quake movement
        // https://github.com/id-Software/Quake/blob/bf4ac424ce754894ac8f1dae6a3981954bc9852d/WinQuake/sv_user.c#L190
        private Vector3 Accelerate(Vector3 velocity, Vector3 wishDirection, float wishSpeed, float accel)
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
}