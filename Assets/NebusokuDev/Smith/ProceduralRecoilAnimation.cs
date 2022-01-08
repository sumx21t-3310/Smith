using System;
using UnityEngine;

namespace NebusokuDev.Smith
{
    public class ProceduralRecoilAnimation : MonoBehaviour
    {
        [SerializeField] private Kickback config;

        [SerializeField, Range(Single.Epsilon, 6000f)]
        private float duration = 100f;

        private Transform _self;

        private Vector3 _kickbackOffsetPoint;
        private Vector3 _kickbackRotation;
        private Vector3 _defaultPosition;
        private Quaternion _defaultRotation;

        private void Start()
        {
            _self = transform;
            _defaultPosition = _self.localPosition;
            _defaultRotation = _self.rotation;
        }

        private void LateUpdate()
        {
            _kickbackOffsetPoint = Vector3.Lerp(_kickbackOffsetPoint, Vector3.zero, Time.deltaTime / (duration / 1000f));
            _kickbackRotation = Vector3.Slerp(_kickbackRotation, Vector3.zero, Time.deltaTime / (duration / 1000f));
            
            _self.localPosition = _defaultPosition + _kickbackOffsetPoint;
            _self.localRotation = _defaultRotation * Quaternion.Euler(_kickbackRotation);
        }

        public void Fire()
        {
            var kickBack = config[0];
            _kickbackOffsetPoint += transform.localRotation * kickBack.position;
            _kickbackRotation += kickBack.rotate;
        }
    }
}