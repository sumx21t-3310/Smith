using System;
using UnityEngine;

namespace NebusokuDev.Smith.Runtime.Sequence.Timer
{
    [Serializable, AddTypeMenu("Fixed")]
    public class FixedRpmTimer : IRpmTimer
    {
        [SerializeField, Range(10f, 2000f)] private float rpm = 600f;
        private const float Minute = 60f;

        private float _intervalCounter;
        public bool IsOverTime => _intervalCounter > Minute / rpm;

        public void Update() => _intervalCounter += IsOverTime ? 0f : Time.deltaTime;

        public void Reset() { }

        public void Lap() => _intervalCounter = 0f;
    }
}