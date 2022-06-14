using UnityEngine;
using static NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.CharacterMovementHelper;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class MonolithicPlayerMover : MonoBehaviour
    {
        [SerializeField] private Transform directionReference;
        [SerializeField] private float speed = 5f;
        [SerializeField] private float friction = 5f;
        [SerializeField] private float groundAccel = 5f;
        [SerializeField] private float airAccel = 1f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float jumpHeight = 1f;
        [SerializeField] private float groundDistance = .1f;
        [SerializeField] private LayerMask groundLayer = -1;

        private IMoverInput _input;
        private CharacterController _controller;


        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;

        public bool IsGrounded
        {
            get
            {
                var bottom = _controller.BottomPoint();

                var ray = new Ray(bottom + new Vector3(0f, _controller.radius), Vector3.down);

                if (Physics.SphereCast(ray, _controller.radius, out var hit, 10f, groundLayer) == false) return false;
                return hit.distance < groundDistance;
            }
        }

        // Start is called before the first frame update
        private void Start()
        {
            _controller = GetComponent<CharacterController>();

            _input = GetInput();

            if (directionReference == null) directionReference = transform;
        }

        private IMoverInput GetInput()
        {
            var sceneAllComponents = FindObjectsOfType<Component>();


            foreach (var checkComponent in sceneAllComponents)
            {
                if (checkComponent is IMoverInput matched) return matched;
            }

            return null;
        }


        // Update is called once per frame
        private void Update()
        {
            if (_input == null) return;

            var direction = directionReference.rotation * new Vector3(_input.Horizontal, 0f, _input.Vertical);

            direction = Vector3.ProjectOnPlane(direction, Vector3.up);

            _fallVelocity += Vector3.up * gravity * Time.deltaTime;


            if (IsGrounded)
            {
                GroundMove(direction);
            }
            else
            {
                AirMove(direction);
            }
        }

        private void AirMove(Vector3 direction)
        {
            // Air Control
            _moveVelocity = Accelerate(_moveVelocity, direction, speed, airAccel);
            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }

        private void GroundMove(Vector3 direction)
        {
            _moveVelocity = Friction(_moveVelocity, friction);
            _moveVelocity = Accelerate(_moveVelocity, direction, speed, groundAccel);

            _fallVelocity = Vector3.zero;

            if (_input.IsJump)
            {
                _fallVelocity = Jump(Vector3.up, jumpHeight, gravity);
            }

            var ray = new Ray(transform.position, Vector3.down);

            if (Physics.Raycast(ray, out var hit))
            {
                _moveVelocity = Vector3.ProjectOnPlane(_moveVelocity, hit.normal);
            }

            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }
        
    }
}