using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public class CameraRotor : MonoBehaviour, ICameraRotor
    {
        [Header("Rotate Settings")] [SerializeField]
        private AngleAxis verticalAxis = new AngleAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField]
        private AngleAxis verticalOffsetAxis = new AngleAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField] private AngleAxis horizontalAxis;
        [SerializeField] private AngleAxis horizontalOffsetAxis;
        [SerializeField] private Vector3 yaw = Vector3.up;


        private Transform _self;
        private ICameraInput _input;


        private void OnEnable() => Locator<ICameraRotor>.Instance.Bind(this);


        private void OnDisable() => Locator<ICameraRotor>.Instance.Unbind(this);


        private void Awake()
        {
            _self = transform;
            _input = GetComponent<ICameraInput>();
        }


        private void Update()
        {
            if (_input != null)
            {
                horizontalAxis.Current += _input.Horizontal;
                verticalAxis.Current += _input.Vertical;
            }

            var horizontal = horizontalAxis[yaw] * horizontalOffsetAxis[yaw];
            var vertical = verticalAxis[Pitch] * verticalOffsetAxis[Pitch];
            FinalRotate = horizontal * vertical;
        }


        private void LateUpdate() => _self.localRotation = FinalRotate;

        public Quaternion FinalRotate { get; set; }

        public Vector3 Yaw
        {
            get => yaw;
            set => yaw = value.normalized;
        }

        public Vector3 Pitch => Vector3.ProjectOnPlane(Vector3.left, yaw);

        public float VerticalInput
        {
            get => verticalAxis.Current;
            set => verticalAxis.Current = value;
        }

        public float VerticalOffset
        {
            get => verticalOffsetAxis.Current;
            set => verticalOffsetAxis.Current = value;
        }

        public float HorizontalInput
        {
            get => horizontalAxis.Current;
            set => horizontalAxis.Current = value;
        }

        public float HorizontalOffset
        {
            get => horizontalOffsetAxis.Current;
            set => horizontalOffsetAxis.Current = value;
        }
    }
}