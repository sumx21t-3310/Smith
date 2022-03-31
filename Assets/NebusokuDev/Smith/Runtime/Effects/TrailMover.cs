using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Effects
{
    public class TrailMover : MonoBehaviour
    {
        [SerializeField] private float speed = 300f;
        [SerializeField] private float smoothTime = .01f;

        public void SetPosition(Vector3 start, Vector3 end)
        {
            transform.position = start;
            _end = end;
        }

        private void Awake() => _self = transform;

        private Transform _self;

        private Vector3 _end;
        private Vector3 _vel;

        private void FixedUpdate()
        {
            transform.position =
                Vector3.SmoothDamp(_self.position, _end, ref _vel, smoothTime, speed, Time.deltaTime);
        }
    }
}