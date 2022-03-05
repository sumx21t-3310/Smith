using NebusokuDev.Smith.Runtime.State.Player;
using NebusokuDev.Smith.Samples.StarterKit.Movement.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Movement
{
    public sealed class Mover : MonoBehaviour, IPlayerState
    {
        [SerializeField] private Transform rotateReference;
        [SerializeField] private CharacterHeight height;
        [SerializeField] private CharacterMovementProfile movementProfile;
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
        private Vector3 _slipVelociy;


        private void Update()
        {
            var characterSpeed = movementProfile[IsGrounded, _input.IsCrouch, _input.IsSprint];
            var wishDirection = rotateReference.rotation * _input.Direction.normalized;

            wishDirection = Vector3.ProjectOnPlane(wishDirection, Vector3.up);

            _fallVelocity = FallGravity(_fallVelocity, movementProfile.Gravity, IsGrounded);
            _fallVelocity = Jump(_fallVelocity, movementProfile.Gravity, movementProfile.JumpHeight, IsGrounded,
                _input.IsJump);

            _moveVelocity = Friction(_moveVelocity, characterSpeed.Friction);
            _slipVelociy = Friction(_slipVelociy, 5f);
            _moveVelocity = Accelerate(_moveVelocity, wishDirection, characterSpeed.Speed, characterSpeed.Accel);

            _controller.height = height.CalcHeight(_controller.height, _input.IsCrouch);

            var ray = new Ray(transform.position + wishDirection.normalized * _controller.radius, Vector3.down);


            if (Physics.Raycast(ray, out var hit) && IsGrounded)
            {
                _moveVelocity = Vector3.ProjectOnPlane(_moveVelocity, hit.normal);
                var angle = Vector3.Angle(hit.normal, Vector3.up);

                _slipVelociy = Slip(_slipVelociy, hit.normal, movementProfile.Gravity, _controller.slopeLimit);
            }

            _controller.Move((_moveVelocity + _fallVelocity + _slipVelociy) * Time.deltaTime);
        }

        private Vector3 Slip(Vector3 velocity, Vector3 normal, float gravity, float limitAngle)
        {
            if (Vector3.Angle(normal, Vector3.up) < limitAngle) return _slipVelociy;


            return velocity + Vector3.ProjectOnPlane(Vector3.up * gravity, normal) * Time.deltaTime;
        }

        private Vector3 Jump(Vector3 velocity, float gravity, float jumpHeight, bool isGrounded, bool isJump)
        {
            if ((isJump && isGrounded) == false) return velocity;

            return velocity + Vector3.up * Mathf.Sqrt(-2f * gravity * jumpHeight);
        }

        private Vector3 FallGravity(Vector3 velocity, float gravity, bool isGrounded)
        {
            if (isGrounded) return Vector3.down;

            return velocity + Vector3.up * gravity * Time.deltaTime;
        }

        private Vector3 Friction(Vector3 velocity, float friction) => velocity - velocity * Time.deltaTime * friction;


        // I referred to quake movement
        // https://github.com/id-Software/Quake/blob/bf4ac424ce754894ac8f1dae6a3981954bc9852d/WinQuake/sv_user.c#L190
        private Vector3 Accelerate(Vector3 velocity, Vector3 wishDirection, float wishSpeed, float accel)
        {
            var currentSpeed = Vector3.Dot(velocity, wishDirection);

            var addSpeed = wishSpeed - currentSpeed;
            var accelSpeed = Mathf.Clamp(wishSpeed * Time.deltaTime * accel, 0f, addSpeed);

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

#if UNITY_EDITOR
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
#endif
    }
}