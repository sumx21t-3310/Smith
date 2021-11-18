using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Sample.Script.Mover
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Transform rotateReference;
        [SerializeField] private float damping = 5f;
        [SerializeField] private float speed = 12f;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float gravity = -9.81f;
        [SerializeField] private float constantGravity = -2f;
        [SerializeField] private bool clampDirection = true;
        [SerializeField] private bool useGravity = true;
        [SerializeField] private float standHeight = 2f;
        [SerializeField] private float crouchHeight = 1.4f;
        

        private IMoverInput _input;
        private CharacterController _controller;

        private Vector3 _fallVelocity;
        private Vector3 _moveVelocity;


        // input caches
        private bool _isJump;
        private Vector3 _direction;

        public bool IsGrounded
        {
            get
            {
                if (_controller == null) return false;

                return _controller.isGrounded;
            }
        }


        private void Start()
        {
            _input = GetComponent<IMoverInput>();


            if (TryGetComponent(out _controller) == false)
            {
                _controller = gameObject.AddComponent<CharacterController>();
            }

            if (rotateReference == null) rotateReference = transform;
        }


        private void Update()
        {
            if (_input == null) return;

            // jump input
            _isJump = _input.IsJump;

            var height = _input.IsCrouch ? crouchHeight : standHeight;

            _controller.height = Mathf.SmoothStep(_controller.height, height, Time.deltaTime);
            
            // direction input
            _direction = rotateReference.rotation * _input.Direction;

            if (_direction.magnitude > 1f) _direction.Normalize();
            if (clampDirection) _direction = Vector3.ProjectOnPlane(_direction, Vector3.up);
        }


        private void FixedUpdate()
        {
            // null check and attach "Character Controller" Component 
            if (_controller == null)
            {
                if (TryGetComponent(out _controller) == false)
                {
                    _controller = gameObject.AddComponent<CharacterController>();
                }
            }

            if (IsGrounded)
            {
                _moveVelocity += ((_direction * speed) - _moveVelocity) * (Time.deltaTime * damping);
                _fallVelocity = useGravity ? Vector3.up * constantGravity : Vector3.zero;
            }
            else
            {
                _moveVelocity += ((_direction * speed) - _moveVelocity) * Time.deltaTime;

                if (useGravity) _fallVelocity += Vector3.up * gravity * Time.deltaTime;
            }


            if (_isJump && IsGrounded) HandleJump();


            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }


        private void HandleJump() => _fallVelocity = Vector3.up * Mathf.Sqrt(jumpHeight * gravity * -2f);
    }
}