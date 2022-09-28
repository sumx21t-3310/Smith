using UnityEngine;

namespace NebusokuDev.Smith.Runtime.ProceduralAnimation.BobbingAnimation
{
    public class Bobbing : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float weight = 1f;
        [SerializeField, Range(.01f, 2f)] private float speed = 1f;
        [SerializeField] private WeaponBobbingProfileBase profile;

        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;
        private Transform _self;

        public float Weight
        {
            get => weight;
            set => weight = Mathf.Clamp01(value);
        }


        private void Awake()
        {
            _self = transform;
            _defaultPosition = _self.localPosition;
            _defaultRotation = _self.localRotation;
        }

        private void Update()
        {
            var (rotation, position) = profile[Time.time * speed];

            _self.localPosition = _defaultPosition + position * weight;
            _self.localRotation = _defaultRotation * Quaternion.Euler(rotation * weight);
        }
    }
}