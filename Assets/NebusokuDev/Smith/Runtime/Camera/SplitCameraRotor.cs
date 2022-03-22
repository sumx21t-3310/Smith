using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public class SplitCameraRotor : MonoBehaviour, ICameraRotor
    {
        [SerializeField] private Transform main;
        [SerializeField] private Transform sub;

        [Header("Rotate Settings")] [SerializeField]
        private DegreeAxis verticalAxis = new DegreeAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField]
        private DegreeAxis verticalOffsetAxis = new DegreeAxis(minAngle: -89f, maxAngle: 89f, isClamp: true);

        [SerializeField] private DegreeAxis horizontalAxis;
        [SerializeField] private DegreeAxis horizontalOffsetAxis;
        [SerializeField] private Vector3 yaw = Vector3.up;


        private ICameraInput _input;


        private void OnEnable() => Locator<ICameraRotor>.Instance.Bind(this);


        private void OnDisable() => Locator<ICameraRotor>.Instance.Unbind(this);


        private void Awake()
        {
            if (main == null)
            {
                main = transform;
            }

            if (sub == null)
            {
                sub = main;
            }

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
            main.localRotation = horizontalAxis[yaw] * verticalAxis[Pitch];
            sub.localRotation = horizontalOffsetAxis[main.up] * verticalOffsetAxis[-main.right];
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
    }
}