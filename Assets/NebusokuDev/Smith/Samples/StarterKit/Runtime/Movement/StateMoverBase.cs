using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.Input;
using NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement.State;
using UnityEngine;

namespace NebusokuDev.Smith.Samples.StarterKit.Runtime.Movement
{
    [RequireComponent(typeof(CharacterController))]
    public abstract class StateMoverBase : MonoBehaviour
    {
        [SerializeField] private float groundDistance = .1f;
        [SerializeField] private LayerMask groundLayer = -1;

        private IMoverInput _input;
        private CharacterController _controller;


        private Vector3 _moveVelocity;
        private Vector3 _fallVelocity;

        private IMoverState _currentState;

        public virtual bool IsGrounded
        {
            get
            {
                var bottom = _controller.BottomPoint();

                var ray = new Ray(bottom + new Vector3(0f, _controller.radius), Vector3.down);

                if (Physics.SphereCast(ray, _controller.radius, out var hit, 10f, groundLayer) == false)
                    return false;
                return hit.distance < groundDistance;
            }
        }

        private void Start()
        {
            _controller = GetComponent<CharacterController>();

            _input = GetInput();
        }

        protected virtual IMoverInput GetInput()
        {
            var sceneAllComponents = FindObjectsOfType<Component>();


            foreach (var checkComponent in sceneAllComponents)
            {
                if (checkComponent is IMoverInput matched) return matched;
            }

            return null;
        }

        private void Update()
        {
            if (_input == null) return;

            var isGrounded = IsGrounded;

            var nextState = GetState(_input, isGrounded);

            var height = _controller.height;

            if (_currentState != nextState)
            {
                OnStateChanged(nextState);

                _currentState?.OnExit(ref _moveVelocity, ref _fallVelocity, ref height, isGrounded, _input);
                _currentState = nextState;
                _currentState?.OnEnter(ref _moveVelocity, ref _fallVelocity, ref height, isGrounded, _input);
            }

            _currentState?.OnUpdate(ref _moveVelocity, ref _fallVelocity, ref height, isGrounded, _input);


            _controller.Move((_moveVelocity + _fallVelocity) * Time.deltaTime);
        }

        protected abstract IMoverState GetState(IMoverInput input, bool isGrounded);

        protected virtual void OnStateChanged(IMoverState nextState)
        {
#if UNITY_EDITOR

            UnityEngine.Debug.Log(
                $"StateChanged: {_currentState?.GetType().Name ?? "None"} -> {nextState.GetType().Name}");
#endif
        }
    }
}