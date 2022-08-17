using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("Fixed")]
    public class FixedRpmTimer : IRpmTimer
    {
        [SerializeField, Range(10f, 2000f)] private float rpm = 600f;
        private const float Minute = 60f;

        private float _elapsedTime;
        public bool IsOverTime => Time.time - _elapsedTime > Minute / rpm;

        public void Update()
        {
        }

        public void Reset()
        {
        }

        public void Lap() => _elapsedTime = Time.time;
    }
}