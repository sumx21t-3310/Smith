using System.Collections.Generic;
using NebusokuDev.Smith.Runtime.Dependency;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Camera
{
    public abstract class ReferenceCameraBase : MonoBehaviour, IReferenceCamera
    {
        [SerializeField, Range(10f, 120f)] private float fieldOfView = 90f;


        #region UnityEventFunctions

        protected virtual void OnEnable() => Locator<IReferenceCamera>.Instance.Bind(this);

        protected virtual void OnDisable() => Locator<IReferenceCamera>.Instance.Unbind(this);

        protected virtual void Awake()
        {
            _virtualFov = new Dictionary<object, float>();
        }

        #endregion


        private Dictionary<object, float> _virtualFov;

        public float BaseFieldOfView
        {
            get => fieldOfView;
            set => fieldOfView = Mathf.Clamp(value, 30f, 120f);
        }


        public abstract Vector3 Center { get; }

        public abstract Quaternion Rotation { get; }
        public IDictionary<object, float> VirtualFov => _virtualFov;
    }
}