using NebusokuDev.Smith.Runtime.Dependency;
using NebusokuDev.Smith.Runtime.Input;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public class SplitCameraRotor : MonoBehaviour, ICameraRotor
    {
        [SerializeField] private Transform recoilTarget;

        [Header("Rotate Settings")] [SerializeField]
        private DegreeAxis verticalAxis = new DegreeAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField]
        private DegreeAxis verticalOffsetAxis = new DegreeAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField] private DegreeAxis horizontalAxis;
        [SerializeField] private DegreeAxis horizontalOffsetAxis;
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
            if (_input == null) return;

            horizontalAxis.Current += _input.Horizontal;
            verticalAxis.Current += _input.Vertical;
        }


        private void LateUpdate()
        {
            _self.localRotation = horizontalAxis[yaw] * verticalAxis[Pitch];
            recoilTarget.localRotation = horizontalOffsetAxis[yaw] * verticalOffsetAxis[Pitch];
        }


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

        public void AddHorizontalOffset(float degree)
        {
            horizontalOffsetAxis.Current += degree;
        }

        public void AddVerticalOffset(float degree)
        {
        }
    }
}