using System;
using UnityEngine;


namespace NebusokuDev.ShooterWeaponSystem.Core.Camera
{
    [Serializable]
    public struct AngleAxis
    {
        [SerializeField] private float maxAngle;
        [SerializeField] private float minAngle;
        [SerializeField] private bool isClamp;
        private float _current;

        public float Current
        {
            get => _current;
            set => _current = isClamp ? Mathf.Clamp(value, minAngle, maxAngle) : value;
        }

        public AngleAxis(float value = 0f, float minAngle = 0f, float maxAngle = 0f, bool isClamp = false)
        {
            this.minAngle = minAngle;
            this.maxAngle = maxAngle;
            this.isClamp = isClamp;
            _current = Mathf.Clamp(value, this.minAngle, this.maxAngle);
        }

        public Quaternion this[Vector3 axis] => Quaternion.AngleAxis(_current, axis);
    }
}