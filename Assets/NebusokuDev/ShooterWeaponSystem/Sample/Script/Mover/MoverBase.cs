using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Sample.Script.Mover
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class MoverBase : MonoBehaviour
    {
        private CharacterController _controller;

        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;
        private Vector3 _moveDirection;

        public bool IsGrounded => CalcIsGrounded();


        private void Start()
        {
            if (TryGetComponent(out _controller) == false)
            {
                _controller = gameObject.AddComponent<CharacterController>();
            }

            SetUp();
        }


        private void Update()
        {
            _controller.height = CalcCharacterHeight(_controller.height);
            _moveDirection = CalcMoveDirection();
        }


        private void FixedUpdate()
        {
            CalcIsGrounded();
            _moveVelocity = CalcMoveVelocity(_moveVelocity, IsGrounded);
            _fallVelocity = CalcFallVelocity(_fallVelocity, _moveDirection, IsGrounded);

            _controller.Move((_moveDirection + _fallVelocity) * Time.deltaTime);
        }


        protected virtual float CalcCharacterHeight(float beforeHeight) => beforeHeight;

        protected virtual void SetUp() { }


        protected virtual bool CalcIsGrounded()
        {
            if (_controller == null) return false;

            return _controller.isGrounded;
        }


        protected abstract Vector3 CalcMoveDirection();

        protected abstract Vector3 CalcFallVelocity(Vector3 velocity, Vector3 direction, bool isGrounded);

        protected abstract Vector3 CalcMoveVelocity(Vector3 velocity, bool isGrounded);
    }
}