using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation
{
    public class BoltAnimation : MonoBehaviour, IProceduralAnimation
    {
        [SerializeField] private Vector3 offset = Vector3.back * .1f;
        [SerializeField] private float rollbackTime = .1f;

        private Vector3 _defaultPosition;

        private Transform _self;

        private void Awake()
        {
            _self = transform;
            _defaultPosition = _self.localPosition;
        }


        private void LateUpdate()
        {
            _self.localPosition =
                Vector3.Lerp(transform.localPosition, _defaultPosition, Time.deltaTime / rollbackTime);
        }

        public void Play()
        {
            _self.localPosition = _defaultPosition + offset;
        }
    }
}